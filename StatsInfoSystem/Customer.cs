using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatsInfoSystem
{
    public class CustomerArea
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string DisplayName
        {
            get { return "[" + Code + "] " + Name; }
        }
    }
    public class CustomerGroup
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Displayname 
        { 
            get { return "[" + Code + "] " + Name; } 
        }
    }
    public class Customer
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string ContactName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public DateTime StartDate { get; set; }
        public decimal Order { get; set; }
        public decimal OrderAverage { get; set; }
        public decimal Buy { get; set; }
        public decimal BuyAverage { get; set; }
        public decimal QuanBuy { get; set; }
        public decimal QuanBuyAverage { get; set; }
        public int ContactMonth { get; set; }
        public string CreditLimit { get; set; }
        public int Late { get; set; }
        public CustomerGroup Group { get; set; }
        public CustomerArea Area { get; set; }
    }

}
