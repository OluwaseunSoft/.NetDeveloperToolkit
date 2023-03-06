using Microsoft.EntityFrameworkCore;
using PersonAPI.Data;
using PersonAPI.Dtos;
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
    var personModel = await context.People.FindAsync(id);

    if (personModel == null)
        return Results.NotFound();

    var personDto = new PersonDto{
        Id = personModel.Id,
        FullName = personModel.FullName,
        Telephone = personModel.Telephone
    };
    return Results.Ok(personDto);
});

app.MapPost("api/v1/people", async (AppDbContext context, Person person) =>
{
    await context.People.AddAsync(person);
    await context.SaveChangesAsync();
    return Results.Created($"/api/v1/people/{person.Id}", person);
});

app.MapPut("api/v1/people/{id}", async (AppDbContext context, int id, Person person) =>
{
    var personModel = await context.People.FindAsync(id);

    if (personModel == null)
        return Results.NotFound();

    personModel.FullName = person.FullName;
    personModel.Telephone = person.Telephone;
    personModel.DoB = person.DoB;

    await context.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("api/v1/people/{id}", async (AppDbContext context, int id) =>
{
    var personModel = await context.People.FindAsync(id);

    if (personModel == null)
        return Results.NotFound();

    context.People.Remove(personModel);
    await context.SaveChangesAsync();

    return Results.Ok(personModel);
});

app.UseHttpsRedirection();

app.Run();

