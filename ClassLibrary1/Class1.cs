using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{



    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class CustomAttribute : Attribute
    {
        public string Comment { get; }

        public CustomAttribute(string comment)
        {
            Comment = comment;
        } 
    }


    [CustomAttribute("Это класс животного")]
    public abstract class Animal
    {
        private eClassificationAnimal classificationAnimal;

        public string Name { get; set; }
        public string Country { get; set; }
        public string HideFromOtherAnimals { get; set; }
        public string WhatAnimal { get; set; }

        public Animal(string name, string country, string hideFromOtherAnimals, string whatAnimal)
        {
            Name = name;
            Country = country;
            HideFromOtherAnimals = hideFromOtherAnimals;
            WhatAnimal = whatAnimal;
        }


        public virtual void GetClassificationAnimal(string whatAnimal)
        {
            switch (whatAnimal)
            {
                case "Корова":
                    Console.WriteLine($"Классификация: {eClassificationAnimal.Herbivores}.");
                    break;
                case "Лев":
                    Console.WriteLine($"Классификация: {eClassificationAnimal.Carnivores}.");
                    break;
                case "Свинка":
                    Console.WriteLine($"Классификация: {eClassificationAnimal.Omnivores}.");
                    break;
                default:
                    Console.WriteLine("Неизвестная классификация.");
                    break;
            }
        }
        public virtual void Doconstruct() { }
        public virtual void SayHello() { }
        public virtual void GetFavouriteFood()
        {
            //switch (whatAnimal)
            //{
            //    case "Корова":
            //        Console.WriteLine($"любимая еда: {eFavouriteFood.Plant}.");
            //        break;
            //    case "Лев":
            //        Console.WriteLine($"любимая еда: {eFavouriteFood.Meat}.");
            //        break;
            //    case "Свинка":
            //        Console.WriteLine($"любимая еда: {eFavouriteFood.Everything}.");
            //        break;
            //    default:
            //        Console.WriteLine("Неизвестна любимая еда.");
            //        break;
            //}
        }

    }

    [CustomAttribute("Это класс коровы")]
    public class Cow : Animal
    {
        public Cow(string name, string country, string hideFromOtherAnimals, string whatAnimal) : base(name, country, hideFromOtherAnimals, whatAnimal)
        {
        }
        public override void SayHello()
        {
            base.SayHello();

            Console.WriteLine($"Корова {Name} из страны {Country} прячется от других животных {HideFromOtherAnimals} и издает звук му-му-му.");
        }

        public override void GetFavouriteFood()
        {
            base.GetFavouriteFood();
            Console.WriteLine($"любимая еда коровы это трава");
        }

    }


    [CustomAttribute("Это класс льва")]
    public class Lion : Animal
    {
        public Lion(string name, string country, string hideFromOtherAnimals, string whatAnimal) : base(name, country, hideFromOtherAnimals, whatAnimal)
        {
        }

        public override void SayHello()
        {
            base.SayHello();
            Console.WriteLine($"Лев {Name} из страны {Country} прячется от других животных {HideFromOtherAnimals} и издает звук ррр-ррр-ррр.");
        }

        public override void GetFavouriteFood()
        {
            base.GetFavouriteFood();
            Console.WriteLine($"любимая еда льва это мясо");
        }
    }

    [CustomAttribute("Это класс свиньи")]
    public class Pig : Animal
    {
        public Pig(string name, string country, string hideFromOtherAnimals, string whatAnimal) : base(name, country, hideFromOtherAnimals, whatAnimal)
        {
        }

        public override void SayHello()
        {
            base.SayHello();
            Console.WriteLine($"Свинка {Name} из страны {Country} прячется от других животных {HideFromOtherAnimals} и издает звук хрю-хрю-хрю.");
        }

        public override void GetFavouriteFood()
        {
            base.GetFavouriteFood();
            Console.WriteLine("любимая еда свинки это все что жуется");
        }


    }

    public enum eClassificationAnimal
    {
        Herbivores,
        Carnivores,
        Omnivores
    }

    public enum eFavouriteFood
    {
        Meat,
        Plant,
        Everything
    }

}
