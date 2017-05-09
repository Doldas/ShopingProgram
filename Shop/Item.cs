using System;
namespace Shop
{
    public enum Category
    {
        Food,
        Potion,
        Herb,
        Scroll,
        Spell
    }
    class Item :  IComparable<Item>, IEquatable<Item>
    {
        public string ProductNumber { set; get; }
        public string Name { set; get; }
        public double Price { set; get; }
        public Category Category { get; set; }

        public bool Equals(Item other)
        {
            return this.ProductNumber == other.ProductNumber;
        }

        int IComparable<Item>.CompareTo(Item other)
        {
            throw new NotImplementedException();
        }
    }
}
