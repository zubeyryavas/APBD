using APBD4.Models;
using APBD4.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace APBD4.Controllers;

[ApiController]
[Route("[api/animals]")]
public class AnimalController : ControllerBase
{

    [HttpGet]
    public IActionResult GetAnimals()
    {
        return Ok(AnimalRepo.animals);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetAnimal(int id)
    {
        var animal = AnimalRepo.animals.FirstOrDefault(animal => animal.id == id);
        if (animal == null)
        {
            return NotFound($"Animal not found!");
        }

        return Ok(animal);
    }

    [HttpPost]
    public IActionResult CreateAnimal (Animal animal)
    {   
        AnimalRepo.animals.Add(animal);
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateAnimal(int id, Animal animal)
    {
        var animalToEdit = AnimalRepo.animals.FirstOrDefault(animal => animal.id == id);

        if (animalToEdit == null)
        {
            return NotFound($"Student with id {id} was not found");
        }

        AnimalRepo.animals.Remove(animal);
        AnimalRepo.animals.Add(animal);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteAnimal(int id)
    {
        var animalToDelete = AnimalRepo.animals.FirstOrDefault(animal => animal.id == id);
        if (animalToDelete == null)
        {
            return NoContent();
        }

        AnimalRepo.animals.Remove(animalToDelete);
        return NoContent();
    }
}

