using System;
namespace APBD4.Models;

    public class Animal
    {
        public int id { get; private set; }
        public string name { get; set; }
        public Category category { get; set; }
        public float weight { get; set; }
        public string color { get; set; }

        private static int newId = 0;
        public Animal(string name, Category category, float weight, string color)
        {
            this.id = newId++;
            this.name = name;
            this.category = category;
            this.weight = weight;
            this.color = color;
        }
    }


