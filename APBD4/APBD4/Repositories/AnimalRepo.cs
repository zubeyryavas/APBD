using System;
using APBD4.Models;

namespace APBD4.Repositories;

public class AnimalRepo
{
	public AnimalRepo()
	{
	}

    public static List<Animal> animals = new List<Animal>
    {
        new Animal("Max", Category.Dog, 8f, "Black"),
        new Animal("Rocky", Category.Cat, 3f, "Orange"),
        new Animal("Bixie", Category.Bird, 0.5f, "White")
    };

    public static List<AnimalVisit> visits= new List<AnimalVisit>
    {
        new AnimalVisit(animals[0], 200, "Vaccine"),
        new AnimalVisit(animals[2], 100, "Treatment"),
        new AnimalVisit(animals[0], 300, "Vaccine"),
        new AnimalVisit(animals[1], 150, "Vaccine")
    };

}

