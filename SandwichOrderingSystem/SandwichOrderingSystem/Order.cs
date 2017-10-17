using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SandwichOrderingSystem
{
    class Order
    {
        private Combo combo = null;
        private Sandwich sandwich = null;
        private Drink drink = null;
        private Chips chips = null;

        public Order()
        {
        }

        public void setCombo(Combo combo)
        {
            this.combo = combo;
        }

        public void setSandwich(Sandwich sandwich)
        {
            this.sandwich = sandwich;
        }

        public void setDrink(Drink drink)
        {
            this.drink = drink;
        }

        public void setChips(Chips chips)
        {
            this.chips = chips;
        }

        public Combo getCombo()
        {
            return combo;
        }
        public Sandwich getSandwich()
        {
            return sandwich;
        }
        public Drink getDrink()
        {
            return drink;
        }
        public Chips getChips()
        {
            return chips;
        }
    }
}
