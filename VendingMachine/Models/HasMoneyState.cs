using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VendingMachine.Models
{
    public class HasMoneyState : IVendingMachineState
    {
        public void dispenseProduct()
        {
            Console.WriteLine("Vending Machine dispensed the product");
        }

        public void selectProductAndInsertMoney(int amount, string productName)
        {
            Console.WriteLine("Already Vending machine has money and product selected, so wait till it finish the current dispensing process...");
        }
    }
}