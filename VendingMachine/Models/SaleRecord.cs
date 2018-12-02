using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VendingMachine.Models
{
    public sealed class SaleRecord : Record
    {
        private static int totalSaleRecords = 0;

        private readonly Item saleItem;
        private readonly decimal amountPaid;

        public SaleRecord(DateTime recordDate, string recordMessage, Item saleItem, decimal amountPaid) :
            base(totalSaleRecords++, recordDate, recordMessage)
        {
            this.saleItem = saleItem;
            this.amountPaid = amountPaid;
        }

        public Item SaleItem
        {
            get
            {
                return this.saleItem;
            }
        }
        public decimal AmountPaid
        {
            get
            {
                return this.amountPaid;
            }
        }

        public override string ToString()
        {
            return string.Format("[Sale Record] ID: {0}, Date: {1}, Item Sold: {2}, Sale Amount: {3}",
                this.recordID, this.recordDate.ToString("dd/MM/yyyy HH:mm:ss"), this.saleItem.ItemName, this.saleItem.ItemPrice);
        }
    }
}