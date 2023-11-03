using PracticeProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject.DataLayer
{
   public  interface IEmployee
    {

        ServiceResponse AddEditEmployee(EmployeeVm EmployeeVM);

        ServiceResponse GetEmployee(int Id= 0 );

        ServiceResponse DeleteEmployee(int Id);
    }
}
