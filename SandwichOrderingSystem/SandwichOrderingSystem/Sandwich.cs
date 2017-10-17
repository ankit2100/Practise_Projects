using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SandwichOrderingSystem
{
    class Sandwich
    {
        private string name;
        private string bread;
        private string filling;
        private List<string> optionals;
        private string description;
        private double price;

        public Sandwich()
        {
            optionals = new List<string>();
            name = "";
            filling = "";
            description = "";
            price = 0;
            bread = "";
        }
        public Sandwich(string name, string bread, string filling, List<string> optionals, string description, double price)
        {
            //creating a sandwich with bread,filling and optionals things
            this.name = name;
            this.bread = bread;
            this.filling = filling;
            this.optionals = optionals;
            this.description = description;
            this.price = price;
           
        }


        public string getName()
        {
            return name;
        }
        public string getBread()
        {
            return bread;
        }
        public string getFilling()
        {
            return filling;
        }
        public List<string> getOptionals()
        {
            return optionals;
        }
        public string getDescription()
        {
            return description;
        }
        public double getPrice()
        {
            return price;
        }

        public void setName(string name)
        {
            this.name = name;
        }
        public void setBread(string bread)
        {
            this.bread = bread;
        }
        public void setFilling(string filling)
        {
            this.filling = filling;
        }
        public void setOptionals(string optionals)
        {
            this.optionals.Add(optionals);
        }
        public void setDescription(string description)
        {
            this.description = description;
        }
        public void setPrice(double price)
        {
            this.price = price;
        }

        
        

    }
}
