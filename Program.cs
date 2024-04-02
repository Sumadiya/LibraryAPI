using Microsoft.EntityFrameworkCore;
using LibraryAPI.Models;
using LibraryAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Adding services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("BookLibrary"));

var app = builder.Build();

// Configuring the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    DataSeeder.SeedData(context); // Seed the database
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
