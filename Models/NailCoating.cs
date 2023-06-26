using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurs
{
    public  class NailCoating
    {
        public NailCoating(string service, double price, string description, string duration, string material, string img)
        {
            Service = service;
            Price = price;
            Description = description;
            Duration = duration;
            Material = material;
            Img = Path.Combine(Directory.GetCurrentDirectory(), "images\\coating", img);
        }

        public string Img { get; set; }
        public string Service { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public string Material { get; set; }
    }
}
