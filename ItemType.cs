using System;
using System.Threading;

namespace MarketProject
{
    public class ItemType: Item //maybe array
    {
        
        public ItemType(int cost, string _name, string _itemSuffix)
        {
            itemCost = cost;
            name = _name;
            itemSuffix = _itemSuffix;

        }
        
    }
}