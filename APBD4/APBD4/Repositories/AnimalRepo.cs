using System;
using APBD4.Models;

namespace APBD4.Repositories;

public class AnimalRepo : IAnimalRepo
{
    private ICollection<Animal> animals;
    private ICollection<AnimalVisit> visits;

    public AnimalRepo()
    {
        animals = new List<Animal>
        {
            new Animal("Max", Category.Dog, 8f, "Black"),
            new Animal("Rocky", Category.Cat, 3f, "Orange"),
            new Animal("Bixie", Category.Bird, 0.5f, "White")
        };

        visits = new List<AnimalVisit>
        {
        new AnimalVisit(1, 200, "Vaccine"),
        new AnimalVisit(3, 100, "Treatment"),
        new AnimalVisit(1, 300, "Vaccine"),
        new AnimalVisit(2, 150, "Vaccine")
        };

    }

    public ICollection<Animal> GetAnimals()
    {
        return animals;
    }

    public Animal GetAnimal(int id)
    {
        return animals.FirstOrDefault(animal => animal.id == id);

    }

    public void AddAnimal(Animal animal)
    {
        animals.Add(animal);
    }

    public void UpdateAnimal(int id, Animal animal)
    {
        var animalToEdit = animals.FirstOrDefault(animal => animal.id == id);

        if(animalToEdit != null)
        {
            animals.Remove(animalToEdit);
            animals.Add(animal);
        }
    }

    public void DeleteAnimal(int id)
    {
        var animal = animals.FirstOrDefault(animal => animal.id == id);
        if(animal != null)
        {
            animals.Remove(animal);
        }
    }

    public ICollection<AnimalVisit> GetAnimalVisits(int animalId)
    {
        List<AnimalVisit> requiredVisits = new List<AnimalVisit>();

        foreach(AnimalVisit visit in visits)
        {
            if(visit.animalId == animalId)
            {
                requiredVisits.Add(visit);
            }
        }

        return requiredVisits;  
    }

    public void CreateVisit(AnimalVisit visit) {
        visits.Add(visit);
    }

}

