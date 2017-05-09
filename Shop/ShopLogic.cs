using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class ShopLogic
    {
        ShopStorage storage = new ShopStorage();

        public IReadOnlyList<Item> GetItems()
        {
            var Items = new
            {
                itemList = storage.GetItems()
            };
           
            IReadOnlyList<Item> temp=Items.itemList;

           return temp;

         
        }
    }
}
