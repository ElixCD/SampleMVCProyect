using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using WebApplication2.DataAccessLayer;

namespace WebApplication2.Models
{
    public class EmployeeBussinesLayer
    {
        public List<Employee> GetEmployees()
        {
            //List<Employee> employees = new List<Employee>();
            //Employee emp = new Employee();
            //emp.FirstName = "Elix";
            //emp.LastName = "Castillo Durán";
            //emp.Salary = 30000;
            //employees.Add(emp);

            //emp = new Employee();
            //emp.FirstName = "Froylán";
            //emp.LastName = "Castillo Durán";
            //emp.Salary = 14000;
            //employees.Add(emp);

            //return employees;

            SalesERPDAL salesDal = new DataAccessLayer.SalesERPDAL();
            return salesDal.Employees.ToList();
        }

        public Employee SaveEmployee(Employee emp)
        {
            SalesERPDAL salesDal = new SalesERPDAL();
            salesDal.Employees.Add(emp);
            salesDal.SaveChanges();
            return emp;
        }
    }
}