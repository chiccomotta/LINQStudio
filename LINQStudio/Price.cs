using System;

namespace LINQStudio
{
    public class Price
    {
        public int Id { get; set; }
        public string Parameter { get; set; }
        public decimal Value { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}