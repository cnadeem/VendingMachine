using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VendingMachine.Models
{
    public abstract class PaymentType
    {
        protected readonly int paymentID;
        protected readonly DateTime paymentDate;

        public PaymentType(int paymentID, DateTime paymentDate)
        {
            this.paymentID = paymentID;
            this.paymentDate = paymentDate;
        }
        public int PaymentID
        {
            get { return this.paymentID; }
        }

        public DateTime PaymentDate
        {
            get { return this.paymentDate; }
        }

    }
}