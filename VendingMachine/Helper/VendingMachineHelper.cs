using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VendingMachine.Models;
namespace VendingMachine.Helper
{
    public  class VendingMachineHelper
    {
        VendingMachines vendingMachine;

        public static void DispenseProduct(VendingMachines vendingMachine)
        {
            vendingMachine.dispenseProduct();
        }

        public static void GetVendingMachines(VendingMachines vendingMachine)
        {
            vendingMachine.selectProductAndInsertMoney(100, "Pepsi");
        }

    }
}