using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Howsden_CashFlowManager
{
    interface IPayable
    {
        public decimal GetPayableAmount();
        public LedgerType LedgerType { get; }
    }
    public enum LedgerType
    {
        Salaried,
        Hourly,
        Invoice
    }
}
