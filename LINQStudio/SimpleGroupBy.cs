using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LINQStudio
{
    public static class SimpleGroupBy
    {
        public static void BasicGroupBy()
        {
            string[] files = Directory.GetFiles(@"C:\tmp");

            // Group By
            IEnumerable<IGrouping<string, string>> query = 
                files.GroupBy(file => Path.GetExtension(file), (file) => file.ToUpper())
                    .OrderByDescending(group => group.Key.Substring(1));

            foreach (var grouping in query)
            {
                Console.WriteLine($"Extension: {grouping.Key}");
                foreach (var filename in grouping)
                {
                    Console.WriteLine("  - " + filename);
                }
            }

            Console.ReadLine();
        }
    }
}
