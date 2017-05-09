using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class ItemStorage<T> : IEnumerable<ItemStorage<T>>
                                                where T:Item
    {
        protected List<Item> internalStorage { get; set; }

        protected ItemStorage()
        {
            internalStorage = new List<Item>
            {
                //Potions
                new Item
                {
                    ProductNumber="#100-000-001",
                    Name="Health Potion IV",
                    Category=Category.Potion,
                    Price=1999.99
                },
                new Item
                {
                    ProductNumber="#100-000-002",
                    Name="God Potion I",
                    Category=Category.Potion,
                    Price=3784.84
                },
                new Item
                {
                    ProductNumber="#100-000-003",
                    Name="Ultimate Badass Potion XVII",
                    Category=Category.Potion,
                    Price=9999.99
                },
                //Scrolls
                new Item
                {
                    ProductNumber="#100-000-004",
                    Name="Healing Scroll VI",
                    Category=Category.Scroll,
                    Price=2348.49
                },
                new Item
                {
                    ProductNumber="#100-000-005",
                    Name="Teleportation Scroll",
                    Category=Category.Scroll,
                    Price=1490
                },
                //Spells
                new Item
                {
                    ProductNumber="#100-000-006",
                    Name="Complete Schoolwork Spell",
                    Category=Category.Spell,
                    Price=859.39
                },
                new Item
                {
                    ProductNumber="#100-000-007",
                    Name="Cleaning Spell",
                    Category=Category.Spell,
                    Price=149
                },
                new Item
                {
                    ProductNumber="#100-000-008",
                    Name="Holiday Spell III",
                    Category=Category.Spell,
                    Price=39
                },
            };
        }

        protected IEnumerable<Item> SortCategory(bool ascend)
        {
            if (ascend)
            {
                return internalStorage.OrderBy(item => item.Category);

            }
            else
            {
                return internalStorage.OrderByDescending(item => item.Category);
            }
        }
        protected IEnumerable<Item> SortArticle(bool ascend)
        {
            if (ascend)
            {
                return internalStorage.OrderBy(item=>item.ProductNumber);
                    
            }
            else
            {
                return internalStorage.OrderByDescending(item => item.ProductNumber);
            }
        }
        #region Query Syntax Methods
        protected IEnumerable<Item> SortItemName(bool ascend)
        {
            if(ascend)
            {
                return
                    from item in internalStorage
                    orderby item.Name
                    select item;
             }
            else
            {
                return
                    from item in internalStorage
                    orderby item.Name descending
                    select item;
            }
        }
        protected IEnumerable<Item> SortPrice(bool ascend)
        {
            if (ascend)
            {
                return
                    from item in internalStorage
                    orderby item.Price
                    select item;
            }
            else
            {
                return
                    from item in internalStorage
                    orderby item.Price descending
                    select item;
            }
        }
        #endregion


        IEnumerator<ItemStorage<T>> IEnumerable<ItemStorage<T>>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
