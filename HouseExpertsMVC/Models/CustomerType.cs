using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseExpertsMVC.Models
{
    public class CustomerType
    {
        public byte ID { get; set; }
        public string Name { get; set; }

        public List<Customer> Customers { get; set; }
    }
}