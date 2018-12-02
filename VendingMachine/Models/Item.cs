using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VendingMachine.Models
{
    public class Item
    {
        private static int totalItemCount = 0;

        protected readonly int itemID;
        protected readonly string itemName;
        protected readonly decimal itemPrice;

        public Item(string itemName, decimal itemPrice)
        {
            this.itemID = totalItemCount++;
            this.itemName = itemName;
            this.itemPrice = itemPrice;
        }
        public Item(Item item)
        {
            this.itemID = item.itemID;
            this.itemName = item.itemName;
            this.itemPrice = item.itemPrice;
        }

        public int ItemID
        {
            get
            {
                return this.itemID;
            }
        }
        public string ItemName
        {
            get
            {
                return this.itemName;
            }
        }
        public decimal ItemPrice
        {
            get
            {
                return this.itemPrice;
            }
        }

        public static int TotalItems()
        {
            return totalItemCount;
        }

        public override string ToString()
        {
            return string.Format("[Item Details] ID: {0}, Name: {1}, Price: {2}",
                this.itemID, this.itemName, itemPrice.ToString("C"));
        }

        public override int GetHashCode()
        {
            return this.itemID;
        }

    }


}