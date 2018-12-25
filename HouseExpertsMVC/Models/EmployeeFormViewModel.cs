using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseExpertsMVC.Models
{
    public class EmployeeFormViewModel
    {
        public Employee Employee { get; set; }
        public IEnumerable<EmployeeType> EmployeeTypes { get; set; }
    }
}