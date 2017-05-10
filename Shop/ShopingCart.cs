using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class ShopingCart:ItemStorage<Item>
    {
        public string Receipt()
        {
            string info = "Receipt:\n\nUser: Kalle Anka\n\nitems:\n";

            double totalCost = 0;
            foreach (Item item in GetAllItems())
            {
                totalCost = totalCost + item.Price;
                info += "Name: " + item.Name + "\nPrice: " + item.Price + "\n\n";
            }
            return info + "Total Cost: " + totalCost;
        }
        public List<Item> GetItems()
        {
            return GetAllItems().ToList();
        }
    }
}
