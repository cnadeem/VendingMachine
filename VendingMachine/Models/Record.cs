using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VendingMachine.Models
{
    public abstract class Record
    {
        protected readonly int recordID;
        protected readonly DateTime recordDate;
        protected readonly string recordMessage;

        public Record(int recordID, DateTime recordDate, string recordMessage)
        {
            this.recordID = recordID;
            this.recordDate = recordDate;
            this.recordMessage = recordMessage;
        }

        public int RecordID
        {
            get
            {
                return this.recordID;
            }
        }
        public DateTime RecordDate
        {
            get
            {
                return this.recordDate;
            }
        }
        public string RecordMessage
        {
            get
            {
                return this.recordMessage;
            }
        }
    }
}