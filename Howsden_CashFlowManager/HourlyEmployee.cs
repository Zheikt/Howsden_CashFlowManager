using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Howsden_CashFlowManager
{
    class HourlyEmployee : Employee
    {
        private readonly decimal _hourlyWage;
        private readonly decimal _hoursWorked;
        public HourlyEmployee(string first, string last, string SSN, decimal HourlyWage, decimal HoursWorked) : base(first, last, SSN, LedgerType.Hourly)
        {
            _hourlyWage = HourlyWage;
            _hoursWorked = HoursWorked;
        }
        protected override decimal Earnings()
        {
            if (_hoursWorked < 40)
            {
                return _hourlyWage * _hoursWorked;
            }
            else
            {
                decimal normalPay = _hourlyWage * 40;
                decimal overtimeWorked = _hoursWorked - 40;
                decimal overtimePay = _hourlyWage * 1.5M * overtimeWorked;
                return normalPay + overtimePay;
            }
        }
        public override string ToString()
        {
            string hoursWorked = _hoursWorked.ToString();
            if (hoursWorked.Contains('.'))
            {
                if (hoursWorked.Substring(hoursWorked.IndexOf('.')).Length == 2)
                    hoursWorked += "0";
            }
            else
                hoursWorked += ".00";
            return "Hourly Employee: " + base.FirstName + " " + base.LastName +
                "\nSSN: " + base.SSN + "\nHourly Wage Salary: " + _hourlyWage.ToString("C") +
                "\nHours Worked: " + hoursWorked + "\nEarned: " + Earnings().ToString("C");
        }
    }
}
