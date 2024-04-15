using System;
using APBD4.Models;
using APBD4.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace APBD4.Controllers;

[ApiController]
[Route("[api/animalVisits]")]
public class AnimalVisitController : ControllerBase
{
    [HttpGet("{animal:Animal}")]
    public IActionResult GetAnimalVisit(Animal animal)
    {
        if (animal != null)
        {
            var visit = AnimalRepo.visits.FindAll(visit => visit.animal == animal);
            if (visit == null)
            {
                return NotFound($"Visit not found!");
            }
            return Ok(visit);
        }
        throw new ArgumentException();
    }

    [HttpPost]
    public IActionResult CreateVisit(AnimalVisit visit)
    {
            AnimalRepo.visits.Add(visit);
            return StatusCode(StatusCodes.Status201Created);
    }
}

