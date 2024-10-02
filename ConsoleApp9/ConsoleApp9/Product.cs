using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    class Product
    {
        private string name;
        private double price;
        private int quanity;

        public string Name { get
            { return name; }
            set
            {
                name = value;
            }
        }
        public double Price
        {
            get
            { return price; }
            set
            {
                if (value > 0) {
                    price = value;
                }
                else
                {
                    price = 1;
                }
            }
        }
        public int Quanity
        {
            get
            { return quanity; }
            set
            {
                if (value > 0)
                {
                    quanity = value;
                }
                else
                {
                    quanity = 1;
                }
            }
        }

        public Product(string name = "", double price = 0, int quanity = 0)
        {
            Name = name;
            Price = price;
            Quanity = quanity;
        }


    }
}
