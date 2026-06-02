using DemonBackProjectSystems.Api.Middlewares;
using DemonBackProjectSystems.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Đăng ký các dịch vụ vào Container (Dependency Injection)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
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

// Nếu dùng Controller, hãy mở comment dòng dưới để map các Route từ Controller:
// app.MapControllers();

// --- HEALTH CHECK ENDPOINT (Task 3) ---
app.MapGet("/api/system/health", async (ApplicationDbContext db) =>
{
    // Bắt mạch xem C# có chạm được vào PostgreSQL không
    bool isDbConnected = await db.Database.CanConnectAsync();

    // Format chuẩn xác theo JSON em yêu cầu
    var healthStatus = new
    {
        api = "running",
        database = isDbConnected ? "connected" : "disconnected",
        python_service = "pending"
    };

    if (!isDbConnected)
    {
        return Results.StatusCode(503);
    }

    return Results.Ok(healthStatus);
})
.WithName("GetSystemHealth")
.WithTags("System");

app.Run();


