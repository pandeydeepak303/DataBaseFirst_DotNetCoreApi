using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticeProject.Models
{
    public class EmployeeVm
    {

        public int Id { get; set; }

        public string name { get; set; }
        public Nullable<decimal> salary { get; set; }
        public Nullable<int> age { get; set; }

        public Nullable<int> DepartmentId { get; set; }


    }
}