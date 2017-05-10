using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class ShopLogic
    {
        private ShopStorage storage = new ShopStorage();
        private ShopingCart userCart = new ShopingCart();
        public string GetReceipt()
        {
            return userCart.Receipt();
        }
        public List<Item> GetCartList()
        {
            return userCart.GetItems();
        }
        public bool RemoveFromCart(string product)
        {
            bool Removed = false;
            Item testItem = userCart.GetItem(product) as Item;
            if (testItem != null)
            {
                Removed = true;
                userCart.Remove(testItem);
            }
            return Removed;
        }
        public bool AddToCart(string item)
        {
            Item testItem = storage.GetItem(item) as Item;
            if (testItem != null)
            {
                userCart.Add(testItem);
                return true;
            }
            return false;
        }
        public List<Item>SearchItem(string input)
        {
            return storage.SearchName(input).ToList();
        }
        
        private bool tFlipFlop = true;
        private List<Item> SortedList(string property)
        {
            property = property.ToLower();
            List<Item> sortedList = new List<Item>();
            if(property=="name")
            {
                if (!tFlipFlop)
                {
                    tFlipFlop = true;
                }
                else
                {
                    tFlipFlop = false;
                }
                sortedList=storage.SortItemName(tFlipFlop).ToList();
            }
            else if(property=="price")
            {
                if (!tFlipFlop)
                {
                    tFlipFlop = true;
                }
                else
                {
                    tFlipFlop = false;
                }
                sortedList = storage.SortPrice(tFlipFlop).ToList();
            }
            else if (property == "price_and_name")
            {
                if (!tFlipFlop)
                {
                    tFlipFlop = true;
                }
                else
                {
                    tFlipFlop = false;
                }
                sortedList = storage.SortPriceAndName(tFlipFlop).ToList();
            }

            else if (property == "price_and_category")
            {
                if (!tFlipFlop)
                {
                    tFlipFlop = true;
                }
                else
                {
                    tFlipFlop = false;
                }
                sortedList = storage.SortPriceAndCategory(tFlipFlop).ToList();
            }
            return sortedList;
        }
        public List<Item> GetAllItems(int sortValue)
        {
            string[] sortOption = { "name", "price", "price_and_name", "price_and_category","category" };
            if (sortValue != 0)
            {
                for (int i = 0; i < sortOption.Length - 1; i++)
                {
                    if (sortValue-1 == i)
                    {
                        return SortedList(sortOption[i]);
                    }
                }
            }
               return storage.GetItems();
        }



    }
}
