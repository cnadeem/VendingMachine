using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VendingMachine.Models
{
    public class VendingMachineLog
    {
        private static int totalVendingMachineLogs = 0;

        protected readonly int logID;
        protected readonly DateTime logDate;
        protected readonly string logMessage;

        public VendingMachineLog(string logMessage)
        {
            this.logID = totalVendingMachineLogs++;
            this.logDate = DateTime.Now;
            this.logMessage = logMessage;
        }
        public VendingMachineLog(DateTime logDate, string logMessage)
        {
            this.logID = totalVendingMachineLogs++;
            this.logDate = logDate;
            this.logMessage = logMessage;
        }

        public int LogID
        {
            get
            {
                return this.logID;
            }
        }
        public DateTime LogDate
        {
            get
            {
                return this.logDate;
            }
        }
        public string LogMessage
        {
            get
            {
                return this.logMessage;
            }
        }

        public override string ToString()
        {
            return string.Format("[Log] ID: {0}, Date: {1}, Message: {2}",
                this.logID, this.logDate.ToString("dd/MM/yyyy HH:mm:ss"), this.logMessage);
        }
    }
}