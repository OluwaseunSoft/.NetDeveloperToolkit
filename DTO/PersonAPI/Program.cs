using Microsoft.EntityFrameworkCore;
using PersonAPI.Data;
using PersonAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(opt => opt
.UseSqlServer(builder.Configuration.GetConnectionString("SqlDbConnection")
));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("api/v1/people", async (AppDbContext context) =>
{
    var people = await context.People.ToListAsync();

    return Results.Ok(people);
});

app.MapGet("api/v1/people/{id}", async (AppDbContext context, int id) =>
{
    var person = await context.People.FindAsync(id);

    if (person == null)
        return Results.NotFound();
        
    return Results.Ok(person);
});

app.MapPost("api/v1/people", async (AppDbContext context, Person person) =>
{
    await context.People.AddAsync(person);
    await context.SaveChangesAsync();        
    return Results.Created($"/api/v1/people/{person.Id}", person);
});


app.UseHttpsRedirection();

app.Run();

