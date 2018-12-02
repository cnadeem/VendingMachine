using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VendingMachine.Models
{
    public sealed class VendingMachines 
    {
        private static VendingMachines instance;

        private readonly Dictionary<Item, int> machineItems;
        private readonly Stack<SaleRecord> saleRecords;
        private readonly Stack<CardPayment> cardPaymentRecords;
        private readonly Stack<CashPayment> cashPaymentRecords;
        private decimal machineBank;

        private VendingMachines()
        {
            this.machineItems = new Dictionary<Item, int>();
            this.saleRecords = new Stack<SaleRecord>();
            this.cardPaymentRecords = new Stack<CardPayment>();
            this.cashPaymentRecords = new Stack<CashPayment>();
            this.machineBank = 0;
        }

        public static VendingMachines GetInstance()
        {
            if (instance == null)
                instance = new VendingMachines();
            return instance;
        }
        public decimal MachineBank
        {
            get
            {
                return this.machineBank;
            }
        }
        public Dictionary<Item, int> MachineItems
        {
            get
            {
                return this.machineItems;
            }
        }
        public Stack<SaleRecord> SaleRecords
        {
            get
            {
                return this.saleRecords;
            }
        }

        public Stack<CardPayment> CardPaymentRecords
        {
            get
            {
                return this.cardPaymentRecords;
            }
        }
        public Stack<CashPayment> CashPaymentRecords
        {
            get
            {
                return this.cashPaymentRecords;
            }
        }

        public List<SaleRecord> GetLastSaleRecords()
        {
            return saleRecords.ToList();
        }

        public List<CardPayment> GetCardPaymentSaleRecords()
        {
            return cardPaymentRecords.ToList();
        }

        public List<CashPayment> GetCashPaymentSaleRecords()
        {
            return cashPaymentRecords.ToList();
        }

        public int GetItemStock(Item item)
        {
            if (machineItems.ContainsKey(item))
                return machineItems[item];

            return -1;
        }
        public int GetTotalMachineItems()
        {
            int totalItems = 0;
            foreach (Item item in machineItems.Keys)
                totalItems += machineItems[item];
            return totalItems;

        }

        public void RefillItems()
        {
            machineItems.Clear();
            this.machineItems.Add(new Item("Coca Cola 330", 5.30m), 20);
            this.machineItems.Add(new Item("Coca Cola Zero", 5.30m), 20);
            this.machineItems.Add(new Item("Fuze Tea 500", 5.30m), 20);
            this.machineItems.Add(new Item("Pepsi Max 330", 5.30m), 20);
            this.machineItems.Add(new Item("Pepsi Max 500", 5.30m), 20);
            this.machineItems.Add(new Item("Evian 500", 5.30m), 20);
            this.machineItems.Add(new Item("Lays Barbecue", 5.30m), 20);
            this.machineItems.Add(new Item("Lays Barbecue", 5.30m), 20);
            this.machineItems.Add(new Item("Lays Sour Cream & Onion", 5.30m), 20);
            this.machineItems.Add(new Item("Coca Cola 330", 5.30m), 20);

        }
        public void SellItem(Item item, decimal amountPaid)
        {
            machineBank += item.ItemPrice;
            machineItems[item]--;
        }
        public void AddSaleRecord(SaleRecord saleRecord)
        {
            this.saleRecords.Push(saleRecord);
        }

        public void AddCardPaymentRecord(CardPayment cardPaymentRecord)
        {
            this.cardPaymentRecords.Push(cardPaymentRecord);
        }

        public void AddCashPaymentRecord(CashPayment cashPaymentRecord)
        {
            this.cashPaymentRecords.Push(cashPaymentRecord);
        }
        public override string ToString()
        {
            return string.Format("Unique Items: {0}, Total Items: {1}, Total Sales: {2}, Machine Bank: {3}",
                machineItems.Count, GetTotalMachineItems(), saleRecords.Count, machineBank.ToString("C"));
        }

    }

       
  

  

   

   
}