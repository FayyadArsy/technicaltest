using FayyadTechnicalBackend.Context;
using FayyadTechnicalBackend.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MyContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("APIContext")));
builder.Services.AddScoped<ItemsRepository>();
builder.Services.AddScoped<CartRepository>();

builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options => options
     .AllowAnyOrigin()
     .AllowAnyHeader()
     .AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(options => options
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod());

app.MapControllers();

app.Run();
