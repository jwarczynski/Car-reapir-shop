using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WarsztatSamochodowy.Models
{
    internal class Employee
    {
        public string fullName { get; set; }
        public float wage { get; set; }
        public string role { get; set; }
        public Employee(string name, float wage, string role)
        {
            fullName= name;
            this.wage= wage;
            this.role= role;
        }
    }
    
}
