using System;
using System.Collections.Generic;
using System.Linq;

namespace MarketProject
{
    public class PlayerInventory
    {
        public List<Item> inventory = new List<Item>();

        public void AddItem(ItemType item)
        {
            Console.WriteLine("Item " + item.name + " added to player inventory");
            inventory.Add(item);
        }
    }
    
    
}