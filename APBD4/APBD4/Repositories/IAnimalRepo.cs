using System;
using APBD4.Models;

namespace APBD4.Repositories;

public interface IAnimalRepo
{
    public ICollection<Animal> GetAnimals();
    public Animal GetAnimal(int id);
    public void AddAnimal(Animal animal);
    public void UpdateAnimal(int id, Animal animal);
    public void DeleteAnimal(int id);
    public ICollection<AnimalVisit> GetAnimalVisits(int animalId);
    public void CreateVisit(AnimalVisit visit);
}

