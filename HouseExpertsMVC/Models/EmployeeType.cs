using System.Collections.Generic;

namespace HouseExpertsMVC.Models
{
    public class EmployeeType
    {
        public byte ID { get; set; }
        public string Name { get; set; }

        public List<Employee> Employees { get; set; }
    }
}