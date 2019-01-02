using System;
using System.Linq;

namespace LINQStudio
{
    public class NestedGroupQuery
    {
        public static void QueryNestedGroups()
        {
            var queryNestedGroups =
                from student in StudentClass.students
                group student by student.Year into newGroup1
                from newGroup2 in
                    (from student in newGroup1
                     group student by student.LastName)
                group newGroup2 by newGroup1.Key;

            // Three nested foreach loops are required to iterate 
            // over all elements of a grouped group. Hover the mouse 
            // cursor over the iteration variables to see their actual type.
            foreach (var outerGroup in queryNestedGroups)
            {
                Console.WriteLine($"student Level = {outerGroup.Key}");
                foreach (var innerGroup in outerGroup)
                {
                    Console.WriteLine($"\tNames that begin with: {innerGroup.Key}");
                    foreach (var innerGroupElement in innerGroup)
                    {
                        Console.WriteLine($"\t\t{innerGroupElement.LastName} {innerGroupElement.FirstName}");
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
