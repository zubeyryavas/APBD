using System;
namespace APBD4.Models;

public class AnimalVisit
{
    public int id { get; private set; }
    public int animalId{ get; set; }
    public int price { get; set; }
    public string description { get; set; }

    private static int newId = 0;
    public AnimalVisit(int animalId, int price, string description)
	{
        this.id = newId;
        this.animalId = animalId;
        this.price = price;
        this.description = description;
	}
}

