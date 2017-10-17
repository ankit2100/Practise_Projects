using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SandwichOrderingSystem
{
    class Combo
    {
        private Sandwich sandwich;
        private Drink drink;
        private Chips chips;
        private double price;
        public Combo()
        {
            sandwich = new Sandwich();
            drink = new Drink();
            chips = new Chips();
        }

        public double getPrice()
        {
            return price;
        }
        public void setPrice(double price)
        {
            this.price = price;
        }

        public Sandwich getSandwich()
        {
            return sandwich;
        }
        public void setSandwich(Sandwich sandwich)
        {
            this.sandwich = sandwich;
        }

        public Drink getDrink()
        {
            return drink;
        }
        public void setDrink(Drink drink)
        {
            this.drink = drink;
        }

        public Chips getChips()
        {
            return chips;
        }
        public void setChips(Chips chips)
        {
            this.chips = chips;
        }

       
        
    }
}
