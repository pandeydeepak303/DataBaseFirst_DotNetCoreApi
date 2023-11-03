using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticeProject.Models
{
    public class EmployeeResponseVM
    {

        public int sno { get; set; }
        public string name { get; set; }
        public Nullable<decimal> salary { get; set; }
        public Nullable<int> age { get; set; }
        public string DepartmentName { get; set; }




    }
}