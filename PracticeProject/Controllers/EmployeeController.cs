using PracticeProject.DataLayer;
using PracticeProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PracticeProject.Controllers
{
   
    public class EmployeeController : ApiController
    {
        IEmployee _emp;
        public EmployeeController()
        {
            _emp = new EmployeeImp();
        }

        [Route("AddEditEmployee")]
        public ServiceResponse AddEditUser(EmployeeVm empl)
        {
            return _emp.AddEditEmployee(empl);
        }

        [HttpDelete]
        [Route("DeleteEmployee")]
        public ServiceResponse DeleteEmployee(int Id = 0)
        {
           return _emp.DeleteEmployee(Id);
        }

        [HttpGet]
        [Route("GetEmployee")]
        public ServiceResponse GetUser(int Id = 0)
        {
            return _emp.GetEmployee(Id);
        }
    }
}
