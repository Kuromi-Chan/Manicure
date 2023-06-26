using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurs
{
    public class NailStrengthening
    {
        public NailStrengthening(double price, string material, string duration, string description, string service, string img)
        {
            Price = price;
            Material = material;
            Duration = duration;
            Description = description;
            Service = service;
            Img = Path.Combine(Directory.GetCurrentDirectory(), "images\\ukreplenie", img);
        }

        public string Img { get; set; }

        public string Service { get; set; }
        public double Price { get; set; }
        public string Material { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }

        
    }

}
