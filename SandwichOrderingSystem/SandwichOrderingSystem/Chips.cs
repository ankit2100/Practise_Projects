using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SandwichOrderingSystem
{
    class Chips
    {
        private string name;
        private double price;
        public Chips()
        {
        }
        public Chips(string name, double price)
        {
            this.name = name;
            this.price = price;
        }
        public string getName()
        {
            return name;
        }
        public double getPrice()
        {
            return price;
        }
        public void setName(string name)
        {
            this.name = name;
        }
        public void setPrice(double price)
        {
            this.price = price;
        }
    }
}
