using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HouseExpertsMVC.Models
{
    public class Customer
    {
        public Customer()
        {
            DateCreated = DateTime.Now;
        }

        public int ID { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Customer Type")]
        public byte CustomerTypeID { get; set; }

        public CustomerType CustomerType { get; set; }

        public bool IsAcive { get; set; }

        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }


}