using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Howsden_CashFlowManager
{
    class Invoice : IPayable
    {
        private readonly LedgerType _ledgerType;
        private string _partNumber;
        private string _partDescription;
        private int _quantity;
        private decimal _price;
        Random r = new Random(DateTime.Now.Millisecond);

        public Invoice(string PartNumber, string PartDescription, int Quantity, decimal Price)
        {
            _ledgerType = LedgerType.Invoice;
            _partNumber = PartNumber;
            _partDescription = PartDescription;
            _quantity = Quantity;
            _price = Price;
        }

        public string PartNumber
        {
            get { return _partNumber; }
        }
        public string PartDescription
        {
            get { return _partDescription; }
        }
        public int Quantity
        {
            get { return _quantity; }
        }
        public decimal Price
        {
            get { return _price; }
        }
        public LedgerType LedgerType
        {
            get { return _ledgerType; }
        }

        public decimal GetPayableAmount()
        {
            return _price * _quantity;
        }

        public override string ToString()
        {
            string invoiceNumber = "000000" + r.Next(999999);
            invoiceNumber = invoiceNumber.Substring(invoiceNumber.Length - 6, 6);
            return "Invoice: " + invoiceNumber + "_" + _partNumber +
                "\nQuantity: " + _quantity + "\nPart Description: " + _partDescription +
                "\nUnit Price: " + _price.ToString("C") + "\nExtended Price: " + GetPayableAmount().ToString("C");
        }
    }
}
