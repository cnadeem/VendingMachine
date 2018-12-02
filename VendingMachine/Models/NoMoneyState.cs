using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VendingMachine.Models
{
    public class NoMoneyState : IVendingMachineState
    {
        public void dispenseProduct()
        {
            Console.WriteLine("Vending machine cannot dispense product because money is not inserted and product is not selected");
        }

        public void selectProductAndInsertMoney(int amount, string productName)
        {
            Console.WriteLine(amount + " has been inserted and " + productName + " has been selected");
        }
    }
}