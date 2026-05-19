var builder = WebApplication.CreateBuilder(args);

// 1. Đăng ký các dịch vụ của Swagger vào Container
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Đăng ký HttpClient và CORS
builder.Services.AddHttpClient();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// 2. Cấu hình HTTP Request Pipeline
if (app.Environment.IsDevelopment())
{
    // Kích hoạt Swagger middleware để sinh file JSON (swagger.json)
    app.UseSwagger();
    
    // Kích hoạt giao diện đồ họa Swagger UI tại đường dẫn /swagger
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll"); // Bật CORS cho Frontend gọi

// 3. Khai báo các API Endpoints
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

// 1. API Health Check
app.MapGet("/api/health", () =>
{
    return Results.Ok(new { service = "AnimeFitPro API", status = "running" });
})
.WithName("HealthCheck");

// 2. API Forward to Python Service
app.MapPost("/api/workout/generate", async (System.Text.Json.JsonElement body, IHttpClientFactory httpClientFactory) =>
{
    var client = httpClientFactory.CreateClient();
    // Gọi sang Python chạy ở port 8001
    var response = await client.PostAsJsonAsync("http://localhost:8001/generate-plan", body);
    
    if (response.IsSuccessStatusCode)
    {
        var content = await response.Content.ReadFromJsonAsync<object>();
        return Results.Ok(content);
    }
    return Results.StatusCode((int)response.StatusCode);
})
.WithName("GenerateWorkout");

app.Run();

// 4. Định nghĩa Data Model (Record)
record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}