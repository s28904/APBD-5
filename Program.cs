using FirstApi;
using FirstApi.Classes;
using FirstApi.interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IMockDb, MockDb>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/animals", (IMockDb mockDb) =>
{
    return TypedResults.Ok(mockDb.GetAllAnimals());
});

app.MapGet("/animals/{id}", (IMockDb mockDb,int id) =>
{
    var animal = mockDb.GetAnimalById(id);
    if (animal is null) return Results.NotFound();
    return TypedResults.Ok(animal);
});


app.MapPost("/animals", (IMockDb mockDb,Animal animal) =>
{
    var result = mockDb.AddAnimal(animal);
    if (!result) return Results.Problem();
    return Results.Created();
});

app.MapDelete("/animals", (IMockDb mockDb,int animalId) =>
{
    var result = mockDb.DeleteAnimal(animalId);
    if (!result) return Results.NotFound();
    return TypedResults.Ok();
});

app.MapPut("/animals/{animalId}/update", (IMockDb mockDb,int animalId,Animal animal) =>
{
    var result = mockDb.EditAnimal(animalId,animal);
    if (!result) return Results.NotFound();
    return TypedResults.Ok();
});

app.MapGet("/visits/{animalId}", (IMockDb mockDb, int animalId) =>
{
    var animalVisits = mockDb.GetAnimalVisit(animalId);
    if (animalVisits is null) return Results.NotFound();
    return TypedResults.Ok(animalVisits);
});


app.MapPost("/visits", (IMockDb mockDb, Visit visit) =>
{
    var result = mockDb.AddVisit(visit);
    if(result) return Results.Created();
    return Results.NotFound();
});

app.Run();
