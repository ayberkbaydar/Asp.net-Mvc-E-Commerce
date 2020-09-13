using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc.Eticaret.Core.Model.Entity
{
    public class OrderPayment:EntityBase
    {
        public int OrderID { get; set; }
        public int _OrderType { get; set; }
        public decimal Price { get; set; }
        public string Bank { get; set; }
    }
    public enum _OrderType
    {
        Transfer=0,
        CreditCard=1
    }
}
