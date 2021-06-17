using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Howsden_CashFlowManager
{
    class Employee : IPayable
    {
        private string firstName;
        private string _SSN;
        private string lastName;
        private LedgerType _ledgerType;

        public Employee(string first, string last, string SSN, LedgerType LedgerType)
        {
            firstName = first;
            lastName = last;
            _SSN = SSN;
            _ledgerType = LedgerType;
        }
        public string FirstName
        {
            get { return firstName; }
        }
        public string SSN
        {
            get { return _SSN; }
        }
        public string LastName
        {
            get { return lastName; }
        }

        public LedgerType LedgerType 
        { 
            get {return _ledgerType; }  
        }

        public decimal GetPayableAmount()
        {
            return Earnings();
        }
        protected virtual decimal Earnings()
        {
            return 0M;
        }
    }
}
