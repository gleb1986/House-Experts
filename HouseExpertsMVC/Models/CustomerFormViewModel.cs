using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseExpertsMVC.Models
{
    public class CustomerFormViewModel
    {
        public Customer Customer { get; set; }
        public IEnumerable<CustomerType> CustomerTypes { get; set; }
    }
}