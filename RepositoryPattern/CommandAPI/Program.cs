using CommandAPI.Data;
using CommandAPI.Models;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>
    (opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("SQLDbConnection")));

builder.Services.AddSingleton<IConnectionMultiplexer>(opt =>
    ConnectionMultiplexer.Connect(builder.Configuration.GetConnectionString("RedisConnection")));

//builder.Services.AddScoped<ICommandRepo, SqlCommandRepo>();
builder.Services.AddScoped<ICommandRepo, SqlCommandRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("api/v1/commands", async (ICommandRepo repo) =>
{
    //var commands = await context.Commands.ToListAsync();
    var commands = await repo.GetAllCommandsAsync();
    return Results.Ok(commands);
});

app.MapGet("api/v1/commands/{commandId}", async (ICommandRepo repo, string commandId) =>
{
    var command = await repo.GetCommandByIdAsync(commandId);

    if (command != null)
    {
        return Results.Ok(command);
    }
    return Results.NotFound();
});

app.MapPost("api/v1/commands", async (ICommandRepo repo, Command cmd) =>
{
    await repo.CreateCommandAsync(cmd);
    await repo.SaveChangesAsync();

    return Results.Created($"/api/v1/commands/{cmd.CommandId}", cmd);
});

app.MapPut("api/v1/commands/{commandId}",
async (ICommandRepo repo, string commandId, Command cmd) =>
{
    var command = await repo.GetCommandByIdAsync(commandId);

    if (command is null) return Results.NotFound();

    command.HowTo = cmd.HowTo;
    command.CommandLine = cmd.CommandLine;
    command.Platform = cmd.Platform;

    await repo.UpdateCommandAsync(command);
    await repo.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("api/v1/commands/{commandId}", async (ICommandRepo repo, string commandId) =>
{
    var command = await repo.GetCommandByIdAsync(commandId);

    if (command is null) return Results.NotFound();

    repo.DeleteCommand(command);
    await repo.SaveChangesAsync();

    return Results.Ok(command);
});



app.Run();

