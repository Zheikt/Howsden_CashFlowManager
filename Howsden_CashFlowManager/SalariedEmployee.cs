using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Howsden_CashFlowManager
{
    class SalariedEmployee : Employee
    {
        private readonly decimal _weeklySalary;
        public SalariedEmployee(string first, string last, string SSN, decimal WeeklySalary) : base(first, last, SSN, LedgerType.Salaried)
        {
            _weeklySalary = WeeklySalary;
        }
        protected override decimal Earnings()
        {
            return _weeklySalary;
        }
        public override string ToString()
        {
            return "Salaried Employee: " + base.FirstName + " " + base.LastName +
                "\nSSN: " + base.SSN + "\nWeekly Salary: " + _weeklySalary.ToString("C") +
                "\nEarned: " + _weeklySalary.ToString("C");
        }
    }
}
