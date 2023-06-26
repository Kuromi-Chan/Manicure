using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurs
{
        public  class SelectedService
        {
            public SelectedService(string service, double price)
            {
                Service = service;
                Price = price;
            }

            public string Service { get; set; }
            public double Price { get; set; }

        }
}
