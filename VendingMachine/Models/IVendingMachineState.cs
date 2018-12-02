using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VendingMachine.Models
{
    public interface IVendingMachineState
    {
        void selectProductAndInsertMoney(int amount, string productName);

        void dispenseProduct();
    }
}