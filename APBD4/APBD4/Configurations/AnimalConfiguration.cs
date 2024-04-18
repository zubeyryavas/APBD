using System;
using APBD4.Models;
using APBD4.Repositories;

namespace APBD4.Configurations;

public static class AnimalConfiguration
{
    public static void EndpointsForAnimals(this IEndpointRouteBuilder app)
    {

        app.MapGet("/api/animal", (IAnimalRepo animalRepo) => {
            return TypedResults.Ok(animalRepo.GetAnimals());
        });

        app.MapGet("/api/animal/{id::int}", (int id, IAnimalRepo animalRepo) => {
            return TypedResults.Ok(animalRepo.GetAnimal(id));
        });


        app.MapPut("/api/animal", (Animal newAnimal, IAnimalRepo animalRepo) => {
            animalRepo.AddAnimal(newAnimal);
            return Results.Ok("Animal added");
        });

        app.MapDelete("/api/animal", (int id, IAnimalRepo animalRepo) => {
            animalRepo.DeleteAnimal(id);
            return TypedResults.Ok("Animal deleted");
        });
        app.MapPost("/api/v1/animal/{id::int}", (int id, Animal newAnimal, IAnimalRepo animalRepo) => {
            animalRepo.UpdateAnimal(id, newAnimal);
            return TypedResults.Ok("Animal info changed");
        });
    }
}

