using System;

namespace LINQStudio
{
    public class TestDate
    {
        public DateTime? Date { get; set; }
    }

    public static class TestDateClass
    {
        public static void Start()
        {
            var a = new TestDate()
            {
                Date = new DateTime(2021, 6, 10)
            };
            
            var diff = DateTime.UtcNow.Subtract(a.Date.Value).Days;
        }
    }

}