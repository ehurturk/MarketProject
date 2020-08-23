using System;
using System.Collections.Generic;

namespace MarketProject
{
    class Core
    {
        private static ItemType bread, milk, meat, lemonade;
        private static PlayerEconomy playerEconomy;
        private static PlayerInventory playerInventory;
        static List<ItemType> GetCatalog()
        {
            var catalog = new List<ItemType>();
            catalog.Add(bread);
            catalog.Add(milk);
            catalog.Add(meat);
            catalog.Add(lemonade);
            return catalog;

        }

        static void AddItem(ItemType item)
        {
            if (playerEconomy.money >= item.itemCost)
            {
                playerInventory.AddItem(item);
                playerEconomy.money -= item.itemCost;
                Console.WriteLine();
                Console.WriteLine("Money Left: " + playerEconomy.money);
            }
            else 
                Console.WriteLine("Not enough money");

        }
        static void Main()
        {
            #region Implementitations
            bread = new ItemType(30, "Bread", "amount");
            milk = new ItemType(20, "Milk", "bottle");
            meat = new ItemType(40, "Meat","kg");
            lemonade = new ItemType(5, "Lemonade","l");
            
            playerEconomy = new PlayerEconomy();
            playerInventory = new PlayerInventory();
            #endregion

            
            
            #region Storyline
            Console.WriteLine("Money: "+playerEconomy.money);
            Console.WriteLine("There are "+ GetCatalog().Count + " item(s) in our stocks: ");
            foreach (var item in GetCatalog())
            {
                Console.WriteLine("(" + item.itemSuffix + ") " + item.name + " $"+ item.itemCost);
            }
            
            Console.WriteLine("");
            Console.WriteLine("Things you can buy with your money: ");
            foreach (var item in GetCatalog())
            {
                if (item.itemCost <= playerEconomy.money)
                {
                    Console.WriteLine(item.name + " $"+ item.itemCost + " x" + playerEconomy.money / item.itemCost);
                }
                
            }
            Console.WriteLine("");
            bool cont = true;
            while (cont)
            {
                int itemMulti = 0;
                Console.WriteLine("Which one do you want to buy?");
                var inputItem = Console.ReadLine(); //try to get the Item type of the input to reduce the code and write more clear. For now, just hardcode it.
                Console.WriteLine("How much? (max 3 at a time): ");
                var inputMultiplier = Console.ReadLine();

                switch (inputMultiplier)
                {
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                    case "1":
                        itemMulti = 1;
                        break;
                    case "2":
                        itemMulti = 2;
                        break;
                    case "3":
                        itemMulti = 3;
                        break;
                    
                }
                switch (inputItem)
                {
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                    case "Bread":
                        for (int i = 1; i <= itemMulti; i++)
                        {
                            AddItem(bread);
                        }
                        
                        break;
                    case "Milk":
                        for (int i = 1; i <= itemMulti; i++)
                        {
                            AddItem(milk);
                        }
                        break;
                    case "Lemonade":
                        for (int i = 1; i <= itemMulti; i++)
                        {
                            AddItem(lemonade);
                        }
                        break;
                    case "Meat":
                        for (int i = 1; i <= itemMulti; i++)
                        {
                            AddItem(meat);
                        }
                        break;
                    
                }

                Console.WriteLine();
                Console.WriteLine("Player Inventory");
                Console.WriteLine();
                foreach (var item in playerInventory.inventory)
                {
                    Console.WriteLine(item.name);
                    Console.WriteLine("----------");
                }

                if (playerEconomy.money > 0)
                {
                    Console.WriteLine("Do you want to buy something else? (y/n)");
                    var input = Console.ReadLine();
                    cont = input == "y";
                }
                else
                {
                    Console.WriteLine("You have 0 money, you can't buy anything.");
                    break;
                }
            }
            
            #endregion
        }
    }
}


//TODO
// 4. Make an inventory
    // DONE To make this, create a new class called Inventory, which is the base class for inventory.
// 2. Make a catalog
    // DONE Just simply take the current item available, and display.
// 3. Handle player economy
    // DONE On buy, just get the current item player is buying, and get it's money and subtract money from players money.
// 1. Make items
    // DONE Just simply make a base class called Items, and make ItemType class to make different item types.
    // DONE Then in the constructor set the values for item.
    // DONE (MAYBE) To get the values, try to use getter and setters, otherwise use simple getter setter:
    // DONE Just declare a public variable called ex. "itemCost" to access it from another class. (Just set this value in constructor).
        // For Items,
        // use itemCost
//
//
//
//
// 5. Handle Wrong Inputs, Typos


