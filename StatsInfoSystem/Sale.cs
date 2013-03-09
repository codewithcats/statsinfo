using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatsInfoSystem
{
    public class Sale
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public DateTime Date { get; set; }
        public Decimal Amount { get; set; }
        public Decimal Vat { get; set; }
        public Decimal VatAmount { get { return Amount * Vat; } }
        public string Remark { get; set; }
        public Customer Customer { get; set; }
    }

    public class SaleLine
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public Sale Sale { get; set; }
        public Product Product { get; set; }
        public Decimal Unit { get; set; }
        public Decimal UnitPrice { get; set; }
        public Decimal Discount { get; set; }
        public Decimal SubTotal { get { return Unit * UnitPrice - Discount; } }
    }
}
