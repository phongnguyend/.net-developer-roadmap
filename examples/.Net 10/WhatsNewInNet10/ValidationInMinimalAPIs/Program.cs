using ValidationInMinimalAPIs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidation();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapPost("/api/persons", (Person person) =>
{
    return person;
})
.WithName("Create Person");

app.Run();
