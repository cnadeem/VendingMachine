using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VendingMachine.Models
{
    public sealed class VendingMachines : IVendingMachineState
    {
        private static VendingMachines instance;

        private readonly Dictionary<Item, int> machineItems;
        private readonly Stack<SaleRecord> saleRecords;
        private readonly Stack<CardPayment> cardPaymentRecords;
        private readonly Stack<CashPayment> cashPaymentRecords;
        private decimal machineBank;

        private IVendingMachineState vendingMachineState;

        private VendingMachines()
        {
            this.machineItems = new Dictionary<Item, int>();
            this.saleRecords = new Stack<SaleRecord>();
            this.cardPaymentRecords = new Stack<CardPayment>();
            this.cashPaymentRecords = new Stack<CashPayment>();
            this.machineBank = 0;
            vendingMachineState = new NoMoneyState();
        }

        public IVendingMachineState getVendingMachineState()
        {
            return vendingMachineState;
        }

        private void setVendingMachineState(IVendingMachineState vendingMachineState)
        {
            this.vendingMachineState = vendingMachineState;
        }
        public void dispenseProduct()
        {
            IVendingMachineState noMoneyState = new NoMoneyState();
            vendingMachineState.dispenseProduct();

            /*
             * Product has been dispensed so vending Machine changed the 
             * internal state to NoMoneyState 
             */

            if (vendingMachineState is HasMoneyState)
            {
                setVendingMachineState(noMoneyState);
            }
        }

        public void selectProductAndInsertMoney(int amount, string productName)
        {
            vendingMachineState.selectProductAndInsertMoney(amount, productName);
            IVendingMachineState hasMoneyState = new HasMoneyState();

            /*
             * The Money and product are provided hence it has changed it
             * state from noMoneyState to hasMoneyState
             */

            if (vendingMachineState is NoMoneyState)
            {
                setVendingMachineState(hasMoneyState);
            }

        }
    }

       
  

  

   

   
}