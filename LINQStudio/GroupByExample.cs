using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQStudio
{
    public static class GroupByExamples
    {
        // Vedi: https://docs.microsoft.com/it-it/dotnet/csharp/language-reference/keywords/group-clause

        public static void GroupByEx1()
        {
            // Creo una lista di prezzi
            List<Price> pricesList =
                new List<Price>
                {
                    new Price()
                    {
                        Id = 1, Parameter = "Kwh",
                        FromDate = DateTime.Parse("01/01/2017"),
                        ToDate = DateTime.Parse("28/02/2017"), Value = 3.0M
                    },
                    new Price()
                    {
                        Id = 1, Parameter = "Markup",
                        FromDate = DateTime.Parse("01/01/2018"),
                        ToDate = DateTime.Parse("31/01/2018"), Value = 2.0M
                    },
                    new Price()
                    {
                        Id = 1, Parameter = "ChargingTime",
                        FromDate = DateTime.Parse("01/02/2017"),
                        ToDate = DateTime.Parse("28/01/2017"), Value = 4.0M
                    },
                    new Price()
                    {
                        Id = 2, Parameter = "ParkingTime",
                        FromDate = DateTime.Parse("01/03/2017"),
                        ToDate = DateTime.Parse("31/03/2017"), Value = 6.0M
                    },
                    new Price()
                    {
                        Id = 2, Parameter = "FooParam",
                        FromDate = DateTime.Parse("01/03/2017"),
                        ToDate = DateTime.Parse("31/03/2017"), Value = 6.6M
                    },
                    new Price()
                    {
                        Id = 2, Parameter = "PipsParam",
                        FromDate = DateTime.Parse("01/03/2017"), ToDate = null,
                        Value = 7.5M
                    },
                    new Price()
                    {
                        Id = 2, Parameter = "CiapsParam",
                        FromDate = DateTime.Parse("01/03/2017"), ToDate = null,
                        Value = 9.5M
                    }
                };

            // Raggruppo su 3 proprietà utilizzando un anonymous type
            var groups =
                pricesList.GroupBy(p => new {p.Id, p.FromDate, p.ToDate});

            // Iterate over each anonymous type.
            foreach (var group in groups)
            {
                Console.WriteLine(
                    $"Key: {group.Key.Id}, {group.Key.FromDate.ToShortDateString()}, " +
                    $"{(group.Key.ToDate.HasValue ? group.Key.ToDate.Value.ToShortDateString() : "NULL")}");

                foreach (var element in group)
                    Console.WriteLine($"  --> Name: {element.Parameter}, Value: " + element.Value);
                
                Console.WriteLine();
            }
            Console.ReadKey();
        }   
    }
}
