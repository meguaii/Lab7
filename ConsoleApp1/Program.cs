using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AnimalReflectionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal cow = new Cow("Молли", "Россия", "нет", "корова");
            Animal lion = new Lion("Симба", "Африка", "да", "Лев");
            Animal pig = new Pig("Пеппа", "Великобритания", "нет", "свинка");

            cow.SayHello();
            cow.GetFavouriteFood();

            lion.SayHello();
            lion.GetFavouriteFood();

            pig.SayHello();
            pig.GetFavouriteFood();

            GenerateXml();
        }

        static void GenerateXml()
        {
            
            var types = typeof(Animal).Assembly.GetTypes();
            var xmlDocument = new System.Xml.Linq.XDocument(new System.Xml.Linq.XElement("Classes"));

            foreach (var type in types)
            {
                var attribute = type.GetCustomAttribute<CustomAttribute>();
                if (attribute != null)
                {
                    var classElement = new System.Xml.Linq.XElement("Class",
                        new System.Xml.Linq.XAttribute("Name", type.Name),
                        new System.Xml.Linq.XElement("Comment", attribute.Comment));
                    xmlDocument.Root.Add(classElement);
                }
            }

            string path = "AnimalClassesDiagram.xml";
            xmlDocument.Save(path);
            Console.WriteLine($"XML файл сгенерирован: {path}"); 
        }
    }
}