using System;
using APBD4.Models;
using APBD4.Repositories;

namespace APBD4.Configurations;

public static class VisitConfiguration
{
    public static void EndpointsForVisits(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/visit/{idAnimal:int}", (int idAnimal, IAnimalRepo animalRepo) => {
            return TypedResults.Ok(animalRepo.GetAnimalVisits(idAnimal));
        });

        app.MapPut("/api/visit", (AnimalVisit newVisit, IAnimalRepo animalRepo) => {
            animalRepo.CreateVisit(newVisit);
            return TypedResults.Ok();
        });
    }
}
