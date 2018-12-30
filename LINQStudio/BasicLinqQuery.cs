using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQStudio
{
    public static class BasicLinqQuery
    {
        public static void BasicQuery()
        {
            // Specify the data source.
            int[] scores = new int[] { 97, 92, 81, 60 };

            // Define the query expression.
            IEnumerable<int> scoreQuery =
                from score in scores
                where score > 80
                select score;

            Console.WriteLine("Score > 80");
            // Execute the query.
            foreach (int i in scoreQuery)
            {
                Console.Write(i + " ");
            }

            Console.ReadKey();
        }
    }
}
