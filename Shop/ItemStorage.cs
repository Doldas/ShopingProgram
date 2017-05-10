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
        //A storage list
        private List<Item> internalStorage;
        //Constructor
        public ItemStorage()
        {
            internalStorage = new List<Item>();
        }
        //All Search Methods for searching Items
        #region Search Method
        public Item GetItem(string search)
        {
            try
            {
             if (FindItem(search).First()!=null)
                {
                    return FindItem(search).First();
                }
            }
            catch(Exception e)
            {

            }
            return null;

           
        }
        public void Remove(T itemToRemove)
        {
            internalStorage.Remove(itemToRemove);
        }
        private IEnumerable<Item> FindItem(string searchTerm)
        {
            return
                from item in internalStorage
                where item.Name == searchTerm || item.ProductNumber == searchTerm
                select item;
        }
        public IEnumerable<Item> SearchName(string searchTerm)
        {
            var output =
                from item in internalStorage
                where item.Name.Contains(searchTerm) == true
                select item;
            return output;
        }
        protected IEnumerable<Item> SearchPriceLower(double price)
        {
            var output =
                from item in internalStorage
                where item.Price<=price
                select item;
            return output;
        }
        protected IEnumerable<Item> SearchPriceHigher(double price)
        {
            var output =
                from item in internalStorage
                where item.Price >= price
                select item;
            return output;
        }
        protected IEnumerable<Item>SearchNameOrPrice(string input,Category category)
        {
            double i=-1;
            bool searchPrice = false;
            try
            {
                i=double.Parse(input);
                if (i != -1)
                {
                    searchPrice = true;
                }
            }
            catch(Exception e)
            {
                if(input==null)
                {
                    return null;
                }
            }
            if(searchPrice==true)
            {
                return
                        from item in internalStorage
                        where item.Price == i && item.Category==category
                        select item;
            }
            else
            {
                return from item in internalStorage
                       where item.Name == input && item.Category == category
                       select item;
            }
                
        }
        #endregion
        //Add Method
        public void Add(Item item)
        {
            if (item != null)
            {
                bool exist = false; //Variable that says if an item exist or not in the storage
                foreach(Item tempItem in internalStorage)
                {
                    if(tempItem.Equals(item))
                    {
                        exist = true;
                    }
                }
                //Add the new item if same item do
                if (!exist)
                {
                    internalStorage.Add(item);
                }
            }
        }
        protected IEnumerable<Item>GetAllItems()
        {
            return
                from item in internalStorage
                select item;
        }
        public IEnumerable<Item> SortCategory(bool ascend)
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
        public IEnumerable<Item> SortArticle(bool ascend)
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
        public IEnumerable<Item> SortItemName(bool ascend)
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
        public IEnumerable<Item> SortPriceAndCategory(bool ascend)
        {
            if (ascend)
            {
                return
                    from item in internalStorage
                    orderby item.Category,
                    item.Price ascending
                    select item;
                    
                    
                    
            }
            else
            {
                return
                    from item in internalStorage
                    orderby item.Category,
                    item.Price descending
                 
                    select item;
            }
        }
        public IEnumerable<Item> SortPriceAndName(bool ascend)
        {
            if (ascend)
            {
                return
                    from item in internalStorage
                    orderby item.Name,
                    item.Price ascending
                    select item;
            }
            else
            {
                return
                    from item in internalStorage
                    orderby item.Name descending,
                    item.Price descending
                    select item;
            }
        }
        public IEnumerable<Item> SortPrice(bool ascend)
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
