using System;
namespace APBD4.Models;

public class AnimalVisit
{
    public int id { get; private set; }
    public Animal animal{ get; set; }
    public int price { get; set; }
    public string description { get; set; }

    private static int newId = 0;
    public AnimalVisit(Animal animal, int price, string description)
	{
        this.id = newId;
        this.animal = animal;
        this.price = price;
        this.description = description;
	}
}

