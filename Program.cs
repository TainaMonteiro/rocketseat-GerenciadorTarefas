using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configuração do DbContext com banco em memória
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("TaskDb"));

// Registra serviços
builder.Services.AddScoped<TaskRepository>();
builder.Services.AddScoped<TaskService>();
builder.Services.AddControllers();

// Configuração do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Task API", Version = "v1" });
});

var app = builder.Build();

// Configuração do middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Task API v1"));
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
