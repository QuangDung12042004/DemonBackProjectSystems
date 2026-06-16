using DemonBackProjectSystems.Api.Middlewares;
using DemonBackProjectSystems.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
var builder = WebApplication.CreateBuilder(args);

// 1. Đăng ký các dịch vụ vào Container (Dependency Injection)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Nhập JWT theo dạng: Bearer {token}",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            },
            new List<string>()
        }
    });
});
builder.Services.AddHttpClient();

// Cấu hình kết nối Database PostgreSQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Cấu hình CORS cho phép gọi API từ bên ngoài
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});
// --- SETUP JWT AUTHENTICATION (Task 9.2) ---
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = Encoding.UTF8.GetBytes(jwtSettings["Key"]!);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(secretKey)
    };
});
builder.Services.AddAuthorization();

// Nếu bạn chuyển sang dùng Controller thay vì Minimal API, hãy mở comment dòng dưới:
// builder.Services.AddControllers();

var app = builder.Build();

// 2. Cấu hình HTTP Request Pipeline (Middleware)
//app.UseMiddleware<ExceptionMiddleware>();
//app.UseMiddleware<RequestLoggingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();

// --- API 1: ĐĂNG KÝ (REGISTER) ---
app.MapPost("/api/auth/register", async (AuthRequest req, ApplicationDbContext db) =>
{
    // 1. Kiểm tra xem email đã có ai xài chưa
    if (db.Users.Any(u => u.Email == req.Email))
    {
        return Results.BadRequest(new { success = false, message = "Email này đã được sử dụng!" });
    }

    // 2. Băm nát mật khẩu bằng BCrypt trước khi lưu
    string passwordHash = BCrypt.Net.BCrypt.HashPassword(req.Password);

    // 3. Tạo chiến binh mới
    // (Lưu ý: Nếu class User của em khác Namespace, hãy hover chuột vào chữ User và bấm Ctrl + . để Visual Studio tự using nhé)
    var newUser = new DemonBackProjectSystems.Domain.Entities.User
    {
        Id = Guid.NewGuid(),
        Email = req.Email,
        PasswordHash = passwordHash,
        Role = "User", // Role mặc định
        IsActive = true,
        CreatedAt = DateTime.UtcNow,
        UpdatedAt = DateTime.UtcNow
    };

    db.Users.Add(newUser);
    await db.SaveChangesAsync();

    return Results.Ok(new { success = true, message = "Đăng ký chiến binh thành công!" });
})
.WithName("Register")
.WithTags("Auth");

// --- API 2: ĐĂNG NHẬP & CẤP TOKEN (LOGIN) ---
app.MapPost("/api/auth/login", async (AuthRequest req, ApplicationDbContext db, IConfiguration config) =>
{
    // 1. Tìm user trong Database
    var user = db.Users.FirstOrDefault(u => u.Email == req.Email);
    if (user == null)
    {
        return Results.BadRequest(new { success = false, message = "Tài khoản hoặc mật khẩu không chính xác!" });
    }

    // 2. Kiểm tra mật khẩu (So khớp bản rõ và bản băm)
    bool isPasswordValid = BCrypt.Net.BCrypt.Verify(req.Password, user.PasswordHash);
    if (!isPasswordValid)
    {
        return Results.BadRequest(new { success = false, message = "Tài khoản hoặc mật khẩu không chính xác!" });
    }

    // 3. Tiến hành đúc thẻ JWT
    var jwtSettings = config.GetSection("JwtSettings");
    var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]!);

    // Chứa các thông tin cơ bản vào Token (Không chứa Password!)
    var claims = new List<Claim>
    {
        new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
        new Claim(JwtRegisteredClaimNames.Email, user.Email),
        new Claim(ClaimTypes.Role, user.Role),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

    var tokenDescriptor = new SecurityTokenDescriptor
    {
        Subject = new ClaimsIdentity(claims),
        Expires = DateTime.UtcNow.AddHours(2), // Thẻ có hạn sử dụng 2 tiếng
        Issuer = jwtSettings["Issuer"],
        Audience = jwtSettings["Audience"],
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
    };

    var tokenHandler = new JwtSecurityTokenHandler();
    var token = tokenHandler.CreateToken(tokenDescriptor);
    var jwt = tokenHandler.WriteToken(token);

    // Trả Token về cho React
    return Results.Ok(new
    {
        success = true,
        message = "Đăng nhập thành công!",
        token = jwt,
        userId = user.Id,
        email = user.Email
    });
})
.WithName("Login")
.WithTags("Auth");
// --- API 3: LƯU GIÁO ÁN (YÊU CẦU ĐĂNG NHẬP) ---
app.MapPost("/api/workouts/save", async (SaveWorkoutRequest req, System.Security.Claims.ClaimsPrincipal user, ApplicationDbContext db) =>
{
    // 1. Đọc ID của User từ chính cái thẻ JWT họ gửi lên
    var userIdString = user.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userIdString))
    {
        return Results.Unauthorized();
    }

    Guid userId = Guid.Parse(userIdString);

    // 2. Khởi tạo Giáo án mới (Map data vào Entity)
    var plan = new DemonBackProjectSystems.Domain.Entities.WorkoutPlan
    {
        Id = Guid.NewGuid(),
        UserId = userId,
        PlanName = req.PlanName,
        // Nếu Entity WorkoutPlan của em có các trường khác (Goal, Level...), em cứ bổ sung vào đây nhé
        CreatedAt = DateTime.UtcNow
    };

    // 3. Lưu vào Database
    db.WorkoutPlans.Add(plan);
    await db.SaveChangesAsync();

    return Results.Ok(new { success = true, message = "Đã lưu bí kíp vào tàng thư các!", planId = plan.Id });
})
.RequireAuthorization() // <--- LÁ CHẮN JWT NẰM Ở ĐÂY
.WithName("SaveWorkout")
.WithTags("Workout");
app.Run();
public record AuthRequest(string Email, string Password);
// ĐỂ CÙNG CHỖ VỚI AuthRequest Ở CUỐI FILE:
public record WorkoutDayDto(string Day, string Focus, List<string> Exercises);
public record SaveWorkoutRequest(string PlanName, string AnimeStyle, int DaysPerWeek, List<WorkoutDayDto> Days);