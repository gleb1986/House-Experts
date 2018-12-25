using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HouseExpertsMVC.Models
{
    public class Customer : Person
    {
        [Display(Name = "Customer Type")]
        public byte CustomerTypeID { get; set; }

        public CustomerType CustomerType { get; set; }

    }


}