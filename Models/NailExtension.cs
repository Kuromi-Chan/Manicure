using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurs
{
    public class NailExtension
    {
        public NailExtension(double price, string material, string duration, string service, string description,string img)
        {
            Price = price;
            Material = material;
            Duration = duration;
            Service = service;
            Description = description;
            Img = Path.Combine(Directory.GetCurrentDirectory(), "images\\narashivanie", img);
        }
       
        public string Img { get; set; }
        public double Price { get; set; }
        public string Material { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public string Service { get; set; }

      
       
    }

}
