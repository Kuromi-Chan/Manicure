using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Kurs
{
   
    public class Design
    {
        public Design(string service, string style, string colors, string description, double price, string img)
        {
            Service = service;
            Style = style;
            Colors = colors;
            Description = description;
            Price = price;
            Img = Path.Combine(Directory.GetCurrentDirectory(), "images\\designs", img);
        }

        public string Img { get; set; }

        public string Service { get; set; }
        public double Price { get; set; }
        public string Style { get; set; }
        public string Colors { get; set; }
        public string Description { get; set; }
    }

}
