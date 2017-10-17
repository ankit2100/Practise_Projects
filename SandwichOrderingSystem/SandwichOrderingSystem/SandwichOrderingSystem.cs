using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SandwichOrderingSystem
{
    class SandwichOrderingSystem
    {
        private List<string> breadList = null;
        private List<string> fillingList = null;
        private List<string> optionalsList = null;
        private List<Sandwich> signatureSandwichesList = null;
        private List<Drink> drinksList = null;
        private List<Chips> chipsList = null;
        private List<Order> orders = null;
        private double basicSandwichPrice = 0;
        private double discountComboPrice = 0;
        Sandwich sandwichObj = null;
        Combo comboObj = null;
        Order orderObj = null;
        public SandwichOrderingSystem()
        {
            basicSandwichPrice = 9.99;
            discountComboPrice = 2.00;
            //defining sandwich components and Addons
            breadList = new List<string> { "Whole Wheat", "Whole White", "Italian Herbs and Cheese", "9Grains Honey Oat" };
            fillingList = new List<string> { "Veggie Pattie", "Chicken", "Beef", "Oven Roasted Chicken Breast", "Shredded Barbeque Chicken", "Oven roasted tomato" };
            optionalsList = new List<string> { "Cheese", "Vegetables", "fresh mozzarella", "provolone cheese","basil pesto mayonnaise" ,"fresh basil","basil pesto","avacado",
                                                        "zesty buffalo sauce","red bell pepper","red onion","sun dried tomato"};
            drinksList = new List<Drink> { new Drink("Coke", 2.50), new Drink("Pepsi", 2.00), new Drink("Diet Coke", 2.25), new Drink("Fanta", 2.25) };
            chipsList = new List<Chips> { new Chips("Lays", 1), new Chips("Doritos", 1.50), new Chips("Tostitos", 1.75) };
            signatureSandwichesList = new List<Sandwich>();
            CreateSignatureSandwiches();
            orders = new List<Order>();
            StartOder();
        }
        /// <summary>
        /// This function calculates total amount for all the orders for the users and returns totalamount.
        /// If there is no order ,then it will return 0
        /// </summary>
        private void GenerateBilling()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("\nYour Order Details:\n");
                double totalprice = 0;
                foreach (Order orderitem in orders)
                {
                    Console.WriteLine("Order {0}\n",orders.IndexOf(orderitem)+1);
                    if (orderitem.getSandwich() != null)
                    {
                        Console.WriteLine("    {0}:${1}", orderitem.getSandwich().getName(), orderitem.getSandwich().getPrice());
                        totalprice += orderitem.getSandwich().getPrice();
                    }
                    if (orderitem.getCombo() != null)
                    {
                        //we make sure that order has all items
                        Console.WriteLine("Combo");
                        Console.WriteLine("    {0}:${1}", orderitem.getCombo().getSandwich().getName(), orderitem.getCombo().getSandwich().getPrice());
                        Console.WriteLine("    {0}:${1}", orderitem.getCombo().getDrink().getName(), orderitem.getCombo().getDrink().getPrice());
                        Console.WriteLine("    {0}:${1}", orderitem.getCombo().getChips().getName(), orderitem.getCombo().getChips().getPrice());
                        Console.WriteLine("    Discount ${0}", discountComboPrice);
                        totalprice += orderitem.getCombo().getPrice();
                    }
                    if (orderitem.getDrink() != null)
                    {
                        Console.WriteLine("    {0}:${1}", orderitem.getDrink().getName(), orderitem.getDrink().getPrice());
                        totalprice += orderitem.getDrink().getPrice();
                    }
                    if (orderitem.getChips() != null)
                    {
                        Console.WriteLine("    {0}:${1}", orderitem.getChips().getName(), orderitem.getChips().getPrice());
                        totalprice += orderitem.getChips().getPrice();
                    }
                    Console.WriteLine("");
                }
                Console.WriteLine("");
                Console.WriteLine("your total Bill is ${0}", totalprice);
                Console.WriteLine("Enter any key to continue...");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occurred in generateBilling : {0}",e.ToString());
            }
        }
        /// <summary>
        /// This function is called inside the constructor of class SandwichOrderingSystem.
        /// It will create set of Signature Sandwiches which will be then displayed for user.
        /// </summary>
        /// <returns></returns>

        private void CreateSignatureSandwiches()
        {
            try
            {
                string name;
                string bread;
                string filling;
                string description;
                double price;
                List<string> optional = new List<string>();
                Sandwich sandwich;

                // creating signature sandwich2
                name = "Vegetarian Sandwich";
                bread = breadList[3];
                filling = fillingList[5];
                description = "Oven roasted tomato, avocado, red bell pepper, red onion, mozzarella, ranch dressing";
                price = basicSandwichPrice;
                optional.Add(optionalsList[2]);
                optional.Add(optionalsList[7]);
                optional.Add(optionalsList[9]);
                optional.Add(optionalsList[10]);
                sandwich = new Sandwich(name, bread, filling, optionalsList, description, price);
                signatureSandwichesList.Add(sandwich);

                // creating signature sandwich1 
                name = "Chicken Pesto Sandwich";
                bread = breadList[2];
                filling = fillingList[3];
                description = "Oven roasted chicken breast, fresh mozzarella, basil pesto mayonnaise.";
                price = basicSandwichPrice + 1;
                optional.Add(optionalsList[0]);
                optional.Add(optionalsList[2]);
                optional.Add(optionalsList[4]);
                sandwich = new Sandwich(name, bread, filling, optionalsList, description, price);
                signatureSandwichesList.Add(sandwich);

                // creating signature sandwich3
                name = "Margherita Chicken Sandwich";
                bread = breadList[0];
                filling = fillingList[3];
                description = "Oven roasted chicken breast, fresh basil, sun dried tomato, provolone cheese, basil pesto mayonnaise";
                price = basicSandwichPrice + 2;
                optional.Add(optionalsList[5]);
                optional.Add(optionalsList[11]);
                optional.Add(optionalsList[3]);
                optional.Add(optionalsList[4]);
                sandwich = new Sandwich(name, bread, filling, optionalsList, description, price);
                signatureSandwichesList.Add(sandwich);

            }
            catch (Exception e)
            {
                signatureSandwichesList.Clear();
                Console.WriteLine("Exception occurred in createSignatureSandwiches : {0}", e.ToString());
            }
        }
        /// <summary>
        /// This function creates Signature sandwich and returns it
        /// </summary>
        /// <returns></returns>
        private Sandwich CreateSignatureSandwich()
        {
            try
            {
                sandwichObj = new Sandwich();
                int input = 0;
                Console.Clear();
                Console.WriteLine("\nPlease Select Signature Sandwich Type");
                foreach (Sandwich sndwich in signatureSandwichesList)
                {
                    int index = signatureSandwichesList.IndexOf(sndwich);
                    Console.WriteLine("{0} for {1}", index + 1, sndwich.getName());
                }
                Console.WriteLine("\npress any other key to cancel");
                input = int.Parse(Console.ReadLine());
                if (input <= 0  || input > signatureSandwichesList.Count)
                    return null;
                return signatureSandwichesList[input - 1];
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// This function creates Custom sandwich and returns it
        /// </summary>
        /// <returns></returns>
        private Sandwich CreateCustomSandwich()
        {
            try
            {
                sandwichObj = new Sandwich();
                int input = 0;
                Console.Clear();
                //adding bread
                Console.WriteLine("\nPlease Select your custom sandwich options\nselect your bread");
                foreach (string breadtype in breadList)
                {
                    int index = breadList.IndexOf(breadtype);
                    Console.WriteLine("{0} for {1}", index + 1, breadtype);
                }
                input = int.Parse(Console.ReadLine());
                if (input <= 0 || input > breadList.Count)
                    return null;
                sandwichObj.setBread(breadList[input - 1]);

                //adding mainfilling
                Console.WriteLine("\nPlease select your filling");
                foreach (string filltype in fillingList)
                {
                    Console.WriteLine("{0} for {1}", fillingList.IndexOf(filltype) + 1, filltype);
                }
                input = int.Parse(Console.ReadLine());
                if (input <= 0 || input > fillingList.Count)
                    return null;
                sandwichObj.setFilling(fillingList[input - 1]);

                //adding optionals
                Console.WriteLine("\nPlease select your optionals");
                foreach (string optionalstype in optionalsList)
                {
                    Console.WriteLine("{0} for {1}", optionalsList.IndexOf(optionalstype) + 1, optionalstype);
                }
                Console.WriteLine("\nType multiple optionals by separating them with ',' eg. 1,2,3");
                string[] optionalsinput = Console.ReadLine().Split(',');
                foreach (string optional in optionalsinput)
                {
                    input = int.Parse(optional);
                    if (input <= 0 || input > optionalsList.Count)
                        return null;
                    sandwichObj.setOptionals(optionalsList[input - 1]);
                }
                sandwichObj.setName("Custom Sandwich");
                sandwichObj.setDescription("Custom Sandwich");
                sandwichObj.setPrice(basicSandwichPrice);

                return sandwichObj;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// This function returns Sandwich that is added in the order
        /// if any Sandwich item is not added properly by user ,this function will return null
        /// </summary>
        /// <returns>object for Sandwich class</returns>
        private Sandwich AddSandwich()
        {
            try
            {
                sandwichObj = new Sandwich();
                Console.Clear();
                Console.WriteLine("\nPlease Select Sandwich Type");
                Console.WriteLine("1 for Signature Sandwich\n2 for Custom Sandwich");
                Console.WriteLine("press any other key to cancel");
                string input = Console.ReadLine();
                if (string.Equals(input, "1"))
                {
                    sandwichObj = CreateSignatureSandwich();
                }
                else if (string.Equals(input, "2"))
                {
                    sandwichObj = CreateCustomSandwich();
                }
                else
                {
                    return null;
                }
                return sandwichObj;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// This function returns Combo that is added in the order
        /// if any combo item is not added properly by user ,this function will return null
        /// </summary>
        /// <returns>object for Combo class</returns>
        private Combo AddCombo()
        {
            try
            {
                comboObj = new Combo();
                Sandwich sandwichObj;
                Drink drinkObj;
                Chips chipsObj;
                Console.Clear();
                //Adding Sandwich to Combo
                sandwichObj = AddSandwich();
                if (sandwichObj == null)
                    return null;
                else
                    comboObj.setSandwich(sandwichObj);

                //Adding Drink to Combo
                drinkObj = AddDrink();
                if (drinkObj == null)
                    return null;
                else
                    comboObj.setDrink(drinkObj);

                //Adding Chips to Combo
                chipsObj = AddChips();
                if (chipsObj == null)
                    return null;
                else
                    comboObj.setChips(chipsObj);

                comboObj.setPrice(CalculateComboPrice(comboObj)); 
                return comboObj;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// This function returns Drinks that is added in the order
        /// </summary>
        /// <returns>object for Drink class</returns>
        private Drink AddDrink()
        {
            try
            {
                Console.Clear();
                int input = 0;//return Failure if index given is not proper by user
                Console.WriteLine("\nPlease Select your Drink options");
                foreach (Drink drinkstype in drinksList)
                {
                    int index = drinksList.IndexOf(drinkstype);
                    Console.WriteLine("{0} for {1}", index + 1, drinkstype.getName());
                }
                Console.WriteLine("press any other key to cancel");
                input = int.Parse(Console.ReadLine());
                if (input <= 0 || input > drinksList.Count)
                    return null;
                else
                    return drinksList[input - 1];
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// This function returns Chips that is added in the order
        /// </summary>
        /// <returns>object for Chips class</returns>
        private Chips AddChips()
        {
            try
            {
                Console.Clear();
                int input = 0;//return Failure if index given is not proper by user
                Console.WriteLine("\nPlease Select your Chips options");
                foreach (Chips chipstype in chipsList)
                {
                    int index = chipsList.IndexOf(chipstype);
                    Console.WriteLine("{0} for {1}", index + 1, chipstype.getName());
                }
                Console.WriteLine("press any other key to cancel");
                input = int.Parse(Console.ReadLine());
                if (input <= 0 || input > chipsList.Count)
                    return null;
                else
                    return chipsList[input - 1];
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// This function calculates the price for the Combo order.
        /// It takes object of Combo class and calculates totalprice for that Order and applies the discount if Combo has all Sandwich,Drink and Chips.
        /// </summary>
        /// <param name="comboObj">This is an object for Combo class</param>
        /// <returns>Total Price for the combo</returns>
        private double CalculateComboPrice(Combo comboObj)
        {
            //calculate the price and add a discount
            double totalPrice;
            try
            {
                totalPrice = 0;
                if (comboObj.getSandwich() != null)
                {
                    totalPrice += comboObj.getSandwich().getPrice();
                }
                if (comboObj.getChips() != null)
                {
                    totalPrice += comboObj.getChips().getPrice();
                }
                if (comboObj.getDrink() != null)
                {
                    totalPrice += comboObj.getDrink().getPrice();
                }
                return totalPrice - discountComboPrice;
            }
            catch
            {
                totalPrice = 0;
                return totalPrice;
            }
        }
        /// <summary>
        /// This function initiates the order for user.It takes following input from user and performs actions accordingly. 
        /// 1. For creating Combo
        /// 2. For creating Sandwich
        /// 3. For creating Chips
        /// 4. For creating Drinks
        /// </summary>
        /// <returns>It returns the order built by user</returns>
        private Order CreateOrder()
        {
            try
            {
                orderObj = new Order();
                string input;
                Console.WriteLine("Select from following Menu options\n");
                Console.WriteLine("1 Combo\n2 Sandwich\n3 Chips\n4 Drinks");
                Console.WriteLine("press any other key to cancel");
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Combo combObj;
                        combObj = AddCombo();
                        if (combObj == null)
                            return null;
                        else
                            orderObj.setCombo(combObj);
                        break;
                    case "2":
                        Sandwich sandObj;
                        sandObj = AddSandwich();
                        if (sandObj == null)
                            return null;
                        else
                            orderObj.setSandwich(sandObj);
                        break;
                    case "3":
                        Chips chipsObj;
                        chipsObj = AddChips();
                        if (chipsObj == null)
                            return null;
                        else
                            orderObj.setChips(chipsObj);
                        break;
                    case "4":
                        Drink drinkObj;
                        drinkObj = AddDrink();
                        if (drinkObj == null)
                            return null;
                        else
                            orderObj.setDrink(drinkObj);
                        break;
                    default:
                        return null;
                }
                return orderObj;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// This function display the main options for user.It takes following input from user and performs actions accordingly. 
        /// 1. For starting the order
        /// 2. For checking the current order
        /// 3. For Exit
        /// </summary>
        private void StartOder()
        {
            while (true)
            {
                string input = "";
                DisplayMenu();
                Console.WriteLine("Enter 1 to Start Ordering\nEnter 2 to Check your order\nEnter 3 to Exit");
                input = Console.ReadLine();
                if (string.Equals(input,"1"))
                {
                    Console.Clear();
                    Order order = CreateOrder();
                    if (order == null)
                    {
                        Console.WriteLine("Invalid input !! Your order was not created !! Press any key to start again");
                        Console.ReadLine();
                    }
                    else
                    {
                        orders.Add(order);
                        Console.WriteLine("Your order was created !! Press any key to continue");
                        Console.ReadLine();
                    }
                }
                else if (string.Equals(input, "2"))
                {
                    GenerateBilling();
                }
                else if (string.Equals(input, "3"))
                {
                    //generate billing and exit
                    GenerateBilling();
                    break;
                }
                else
                {
                    //invalid input
                    Console.WriteLine("Invalid input.Please press any key to continue and choose from valid options.");
                    Console.ReadLine();
                }

            }
        }
        /// <summary>
        /// This function displays menu for user
        /// </summary>
        private void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("....................Welcome to Sandwish Ordering System....................");
            Console.WriteLine("....................................Menu...................................");
            Console.WriteLine("\nSignature Sandwiches");
            foreach (Sandwich sandwich in signatureSandwichesList)
            {
                int index = signatureSandwichesList.IndexOf(sandwich);
                Console.WriteLine("    {0} : ${1}",sandwich.getName(),sandwich.getPrice());
            }
            Console.WriteLine("\nCustom Sandwiches");
            Console.WriteLine("    Create any Custom Sandwich for ${0}",basicSandwichPrice);
            Console.WriteLine("\nChips");
            foreach (Chips chipstype in chipsList)
            {
                int index = chipsList.IndexOf(chipstype);
                Console.WriteLine("    {0} : ${1}",chipstype.getName(),chipstype.getPrice());
            }
            Console.WriteLine("\nDrinks");
            foreach (Drink drinktype in drinksList)
            {
                int index = drinksList.IndexOf(drinktype);
                Console.WriteLine("    {0} : ${1}", drinktype.getName(),drinktype.getPrice());
            }
            Console.WriteLine("\nDiscounts\n    Add any drink and chips to your Sandwich and SAVE ${0}",discountComboPrice);
            Console.WriteLine("\n\n");
        }
    }
}
