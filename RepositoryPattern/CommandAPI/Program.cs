using CommandAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>
(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("SQLDbConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("api/v1/commands", async (AppDbContext context) =>
{
    var commands = await context.Commands.ToListAsync();
    return Results.Ok(commands);
});

app.MapGet("api/v1/commands", async (AppDbContext context) =>
{
    
});

// app.MapGet("api/v1/commands", async (AppDbContext context) =>
// {

// });

// app.MapGet("api/v1/commands", async (AppDbContext context) =>
// {

// });

// app.MapGet("api/v1/commands", async (AppDbContext context) =>
// {

// });



app.Run();

