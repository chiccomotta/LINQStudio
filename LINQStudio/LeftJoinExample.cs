using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQStudio
{
    public class LeftJoinExample
    {
        // https://docs.microsoft.com/it-it/dotnet/csharp/linq/perform-left-outer-joins

        // This code produces the following output:
        //
        // Magnus:        Daisy
        // Terry:         Barley
        // Terry:         Boots
        // Terry:         Blue Moon
        // Charlotte:     Whiskers
        // Arlene:

        public static void LeftOuterJoinExample()
        {
            var magnus = new Person {FirstName = "Magnus", LastName = "Hedlund"};
            var terry = new Person {FirstName = "Terry", LastName = "Adams"};
            var charlotte = new Person {FirstName = "Charlotte", LastName = "Weiss"};
            var arlene = new Person {FirstName = "Arlene", LastName = "Huff"};

            var barley = new Pet {Name = "Barley", Owner = terry};
            var boots = new Pet {Name = "Boots", Owner = terry};
            var whiskers = new Pet {Name = "Whiskers", Owner = charlotte};
            var bluemoon = new Pet {Name = "Blue Moon", Owner = terry};
            var daisy = new Pet {Name = "Daisy", Owner = magnus};

            // Create two lists.
            var people = new List<Person> {magnus, terry, charlotte, arlene};
            var pets = new List<Pet> {barley, boots, whiskers, bluemoon, daisy};

            var query = from person in people
                join pet in pets on person equals pet.Owner into gj
                from subpet in gj.DefaultIfEmpty()
                select new {person.FirstName, PetName = subpet?.Name ?? string.Empty};

            foreach (var v in query) Console.WriteLine($"{v.FirstName + ":",-15}{v.PetName}");

            Console.ReadKey();
        }
    }


    internal class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    internal class Pet
    {
        public string Name { get; set; }
        public Person Owner { get; set; }
    }
}