using PracticeProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticeProject.DataLayer
{
    public class EmployeeImp : IEmployee
    {
       newdbEntities _db = null;
       ServiceResponse response = null;
        public EmployeeImp()
        {
            _db = new newdbEntities();
            response = new ServiceResponse();
        }
        public ServiceResponse AddEditEmployee(EmployeeVm employeeVM)
        {
            try
            {
                if (employeeVM.Id == 0)
                {
                    Employee employee = new Employee();
                    employee.name = employeeVM.name;
                    employee.salary = employeeVM.salary;
                    employee.age = employeeVM.age;
                    employee.DepartmentId = employeeVM.DepartmentId;
                    employee.IsDeleted = false;
                    _db.Employees.Add(employee);
                    _db.SaveChanges();
                    response.statusCode = 200;
                    response.message = " Employee  has been inserted successfuly";
                    response.version = "v1.0";
                  }
                else
                  {
                    var record = _db.Employees.Where(x => x.sno == employeeVM.Id).FirstOrDefault();

                    if ( record!= null)
                    {
                        record.name = employeeVM.name;
                        record.salary = employeeVM.salary;
                        record.age = employeeVM.age;
                        record.IsDeleted = false;
                        record.DepartmentId = employeeVM.DepartmentId;
                        _db.SaveChanges();

                        response.statusCode = 200;
                        response.message = " Employee  has been updated successfuly";
                        response.version = "v1.0";
                    }
                    else
                    {
                        response.statusCode = 404;
                        response.message = "Record doesn't exists"; 
                    }
                }            
            }
            catch( Exception Ex)
            {
                response.statusCode = 201;
                response.message = Ex.Message;
                response.version = "v1.0";
            }
            return response;
        }

        public ServiceResponse DeleteEmployee(int Id)
        {
            
          try
                {
                    var record = _db.Employees.Where(x => x.sno == Id).FirstOrDefault();
                    if (record != null)
                    {
                        record.IsDeleted = true;
                        _db.SaveChanges();
                        response.statusCode = 200;
                        response.message = "Employee Deleted Successfully";
                        response.version = "v1.0";
                    }
                    else
                    {
                        response.statusCode = 404;
                        response.message = "Record doesn't exists";
                    }
                }
                catch (Exception ex)
                {
                    response.statusCode = 201;
                    response.message = ex.Message;
                    response.version = "v1.0";

                }
                return response;      
        }

        public ServiceResponse GetEmployee(int Id =0)
        {
            ServiceResponse response = new ServiceResponse();
            List<EmployeeResponseVM> DetailsList = new List<EmployeeResponseVM>();

            try
            {
                var query = from employee in _db.Employees
                            join department in _db.Departments on employee.DepartmentId equals department.sno
                            where employee.IsDeleted == false
                            select new EmployeeResponseVM
                            {
                                sno = employee.sno,
                                name = employee.name,
                                salary = employee.salary,
                                age = employee.age,
                                DepartmentName = department.Department1
                            };

                if (Id != 0)
                {
                    query = query.Where(x => x.sno == Id);
                }
                foreach (var item in query)
                {
                    EmployeeResponseVM employeeResponseVM = new EmployeeResponseVM
                    {

                        sno = item.sno,
                        name = item.name,
                        salary = item.salary,
                        age = item.age,
                        DepartmentName = item.DepartmentName
                    };

                    DetailsList.Add(employeeResponseVM);
                }
                response.statusCode = 200;
                response.data = DetailsList;
                response.Success = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.message = ex.Message;
                return response;
            }
        }







    }
}