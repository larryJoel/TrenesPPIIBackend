using Microsoft.EntityFrameworkCore;
using TrenesPPII.data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TrenesContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("conexionSql")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(options =>
{
    options.AddPolicy("NUevaPolitica", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("NUevaPolitica");

app.UseAuthorization();

app.MapControllers();

app.Run();
