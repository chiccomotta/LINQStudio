using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace LINQStudio
{
    public class FooClass
    {
        public int Id { get; set; }
        public string F1 { get; set; }
        public int F2 { get; set; }
        public int F3 { get; set; }
        public DateTime Date { get; set; }
    }

    public static class FooClassTest
    {
        public static void Test()
        {
            var list = new List<FooClass>()
            {
                new FooClass() {Id = 1, F1 = "Nima", F2 = 1990, F3 = 10, Date = DateTime.Now.AddDays(-1)},
                new FooClass() {Id = 2, F1 = "Nima", F2 = 1990, F3 = 11, Date = DateTime.Now.AddDays(-2)},
                new FooClass() {Id = 3, F1 = "Nima", F2 = 2000, F3 = 12, Date = DateTime.Now.AddDays(1)},
                new FooClass() {Id = 4, F1 = "John", F2 = 2001, F3 = 1, Date = DateTime.Now.AddDays(-1)},
                new FooClass() {Id = 5, F1 = "John", F2 = 2001, F3 = 2, Date = DateTime.Now.AddDays(+2)},
                new FooClass() {Id = 6, F1 = "John", F2 = 2001, F3 = 2, Date = DateTime.Now.AddDays(+3)},
                new FooClass() {Id = 7, F1 = "Sara", F2 = 2010, F3 = 4, Date = DateTime.Now},
            };

            // raggruppo per F1, ordino e prendo il primo elemento di ogni gruppo
            var result = (from element in list
                group element by element.F1
                into groups
                select groups.OrderBy(p => p.F2).ThenByDescending(p => p.Date).First()).ToList();

            Debug.WriteLine(result);
        }
    }
}
