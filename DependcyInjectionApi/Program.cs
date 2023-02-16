using DiApi.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IDataRepo, NoSqlDataRepo>();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/getdata", (IDataRepo repo) =>
{
    //var repo = new SqlDataRepo();
    //var repo = new NoSqlDataRepo();

    repo.ReturnData();

    return Results.Ok();
});

app.Run();

