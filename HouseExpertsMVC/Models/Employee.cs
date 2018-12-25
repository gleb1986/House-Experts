using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HouseExpertsMVC.Models
{
    public class Employee : Person
    {
        [Display(Name = "Employee Type")]
        public byte EmployeeTypeID { get; set; }
        public EmployeeType EmployeeType { get; set; }
    }
}