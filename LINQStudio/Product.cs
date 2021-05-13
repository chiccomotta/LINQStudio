using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace LINQStudio
{
    public class Product
    {
        private sealed class CodeEqualityComparer : IEqualityComparer<Product>
        {
            public bool Equals(Product x, Product y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Code == y.Code;
            }

            public int GetHashCode(Product obj)
            {
                return (obj.Code != null ? obj.Code.GetHashCode() : 0);
            }
        }

        public static IEqualityComparer<Product> CodeComparer { get; } = new CodeEqualityComparer();

        public string Code { get; set; }
        public string Name { get; set; }
    }

    public static class TestIntersect
    {
        public static void Test()
        {
            var pa = new Product() {Code = "A", Name = "Pr. A"};
            var pb = new Product() {Code = "B", Name = "Pr. B"};
            var pc = new Product() {Code = "A", Name = "Pr. C con codice A"};
            var pd = new Product() {Code = "D", Name = "Pr. D"};
            var pa2 = new Product() {Code = "A", Name = "Pr. A2"};


            var left = new List<Product> {pb, pa2};
            var right = new List<Product> {pc, pd, pa};

            // Intersect è una left join perchè prende l'item della lista left e non quella di right
            var result = left.Intersect(right, Product.CodeComparer);

            Debug.WriteLine($"items in common:  {result.Count()}");
        }
    }
}
