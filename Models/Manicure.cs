using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurs
{
    public class Manicure
    {
        public Manicure(string service,  string description, double price, string duration, string img)
        {
            Service = service;
            Description = description;
            Price = price;
            Duration = duration;
            Img = Path.Combine(Directory.GetCurrentDirectory(), "images\\manicure", img);
        }

        public string Img { get; set; }
        public string Service { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Duration { get; set; }
    }
}
