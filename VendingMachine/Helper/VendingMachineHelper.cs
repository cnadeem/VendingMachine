using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using VendingMachine.Models;
namespace VendingMachine.Helper
{
    public class VendingMachineHelper
    {
        static VendingMachines vendingMachine;

        public static void InitializeVendingMachine()
        {
            vendingMachine = VendingMachines.GetInstance();
        }

        public static string GetSaleRecords()
        {
            StringBuilder saleRecordsDetails = new StringBuilder();
            List<SaleRecord> saleRecords = vendingMachine.GetLastSaleRecords();

            if (saleRecords == null || saleRecords.Count == 0)
            {
                return "There are currently no sale records to present.";

            }
            foreach (SaleRecord saleRecord in saleRecords)
            {
                saleRecordsDetails.Append(saleRecord.ToString());
            }
            return saleRecordsDetails.ToString();
        }

        public static string GetPaymentRecords()
        {
            StringBuilder paymentRecordsDetails = new StringBuilder();

            decimal cashAmountInVendingMachine = 0m, cardAmountInVendingMachine = 0m;
            List<CashPayment> cashSaleRecords = vendingMachine.GetCashPaymentSaleRecords();
            List<CardPayment> cardSaleRecords = vendingMachine.GetCardPaymentSaleRecords();

            if (cashSaleRecords == null || cashSaleRecords.Count == 0)
            {
                paymentRecordsDetails.AppendLine("There are currently no cash records to present.");
            }
            else
            {
                foreach (CashPayment cashSaleRecord in cashSaleRecords)
                {
                    cashAmountInVendingMachine += cashSaleRecord.AmountPaid;
                }
                paymentRecordsDetails.AppendLine(string.Format("Vending Machine has Total cash payment as {0}", cashAmountInVendingMachine));
            }

            if (cardSaleRecords == null || cardSaleRecords.Count == 0)
            {
                paymentRecordsDetails.AppendLine("There are currently no cards records to present.");
            }
            else
            {
                foreach (CardPayment cardSaleRecord in cardSaleRecords)
                {
                    cardAmountInVendingMachine += cardSaleRecord.AmountPaid;
                }
                paymentRecordsDetails.AppendLine(string.Format("Vending Machine has Total card payment as {0}", cardAmountInVendingMachine));
            }
            return paymentRecordsDetails.ToString();
        }

        public static string GetVendingMachineDetails()
        {
            return vendingMachine.ToString();
        }

        public static string RefillVendingMachine()
        {
            vendingMachine.RefillItems();
            return "Vending Machine Refill successfully done";
        }

        public static string GetProductsList()
        {
            StringBuilder productList = new StringBuilder();
            if (vendingMachine.MachineItems.Count == 0)
            {
                return "[ERROR] This vending machine does not have any items in stock.";
            }

            foreach (Item item in vendingMachine.MachineItems.Keys)
            {
                productList.AppendLine(string.Format("{0} [IN STOCK: {1}]", item.ToString(), vendingMachine.MachineItems[item]));
            }
            return productList.ToString();
        }

        public static string PurchaseProduct(string userInputProductID,string userInputAmount,string userInputPaymentMethod)
        {
            Item requestedItem = null;
            int userInputInt,paymentMethod;
            decimal userInputDecimal;

            if (vendingMachine.MachineItems.Count == 0)
            {
                return "[ERROR] This vending machine does not have any items in stock.";
            }
            
            if (!int.TryParse(userInputProductID, out userInputInt))
            {
                return "[ERROR] Invalid input.";
            }

            foreach (Item item in vendingMachine.MachineItems.Keys)
            {
                if (item.ItemID == userInputInt)
                {
                    requestedItem = item;
                    break;
                }
            }

            if (requestedItem == null)
            {
                return "[ERROR] No such item in the vending machine. Please try again.";
            }

            if (vendingMachine.GetItemStock(requestedItem) == 0)
            {
                return "[ERROR] Item is out of stock.";
            }

            if (!Decimal.TryParse(userInputAmount, out userInputDecimal))
            {
                return "[ERROR] Invalid input.";
            }

            if (userInputDecimal < requestedItem.ItemPrice)
            {
                return "[ERROR]  Item price is higher than the paid amount.";
            }

            if (!Int32.TryParse(userInputPaymentMethod, out paymentMethod))
            {
                return "[ERROR] Invalid payment amount input.";
            }

            if(paymentMethod != 1 && paymentMethod != 2)
            {
                return "[ERROR] Invalid payment amount method.";
            }
            vendingMachine.SellItem(requestedItem, userInputDecimal);

            string recordMessage = string.Format("[Vending Machine]: Item has been successfully sold (Paid: {0}, Returned: {1}).",
                    userInputDecimal.ToString("C"), (userInputDecimal - requestedItem.ItemPrice).ToString("C"));

            SaleRecord saleRecord = new SaleRecord(DateTime.Now, recordMessage, requestedItem, userInputDecimal);
            vendingMachine.AddSaleRecord(saleRecord);

            if(paymentMethod == 1)
            {
                CardPayment cardPaymentRecord = new CardPayment(DateTime.Now, recordMessage, requestedItem, userInputDecimal);
                vendingMachine.AddCardPaymentRecord(cardPaymentRecord);
            }
            else if (paymentMethod == 2)
            {
                CashPayment cashPaymentRecord = new CashPayment(DateTime.Now, recordMessage, requestedItem, userInputDecimal);
                vendingMachine.AddCashPaymentRecord(cashPaymentRecord);
            }

            return recordMessage;
        }
    }
}