using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.ViewModels;

namespace WebApplication2.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Test
        [Authorize]
        public ActionResult Index()
        {

            EmployeeListViewModel employeeListViewModel = new EmployeeListViewModel();
            EmployeeBussinesLayer empBal = new EmployeeBussinesLayer();
            List<Employee> employees = empBal.GetEmployees();
            List<EmployeeViewModel> empViewModels = new List<EmployeeViewModel>();

            foreach (Employee emp in employees)
            {
                EmployeeViewModel empViewModel = new EmployeeViewModel();
                empViewModel.EmployeeName = emp.FirstName + " " + emp.LastName;
                empViewModel.Salary = emp.Salary.Value.ToString("C");
                if (emp.Salary > 15000)
                {
                    empViewModel.SalaryColor = "yellow";
                }
                else
                {
                    empViewModel.SalaryColor = "green";
                }
                empViewModels.Add(empViewModel);
            }
            employeeListViewModel.Employees = empViewModels;
            //employeeListViewModel.UserName = "Admin";
            return View(employeeListViewModel);
        }

        public string GetString()
        {
            return "Hello World is old now, It's time for wassup bro ;)";
        }

        public ActionResult GetView(int id = -1)
        {
            if (id >= 0)
            {
                return View("YourView");
            }
            else
            {
                //Employee emp = new Employee();
                //emp.FirstName = "Elix";
                //emp.LastName = "Castillo";
                //emp.Salary = 30000;

                //EmployeeViewModel vmEmp = new EmployeeViewModel();
                //vmEmp.EmployeeName = emp.FirstName + " " + emp.LastName;
                //vmEmp.Salary = emp.Salary.ToString("c");
                //if(emp.Salary > 15000)
                //{
                //    vmEmp.SalaryColor = "yellow";
                //}
                //else
                //{
                //    vmEmp.SalaryColor = "green";
                //}

                //vmEmp.UserName = "Admin";
                ////ViewBag.Employee = emp;
                //return View("MyView",vmEmp);
                return View();
            }            
        }

        public ActionResult AddNew()
        {
            return View("CreateEmployee", new CreateEmployeeViewModel());
        }

        public ActionResult SaveEmployee(Employee emp, string BtnSubmit)
        {
            // return emp.FirstName + "|" + emp.LastName + "|" + emp.Salary;
            switch (BtnSubmit)
            {
                case "Save Employee":
                    // return Content(emp.FirstName + "|" + emp.LastName + "|" + emp.Salary);
                    if(ModelState.IsValid)
                    {
                        EmployeeBussinesLayer empBal = new EmployeeBussinesLayer();
                        empBal.SaveEmployee(emp);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        CreateEmployeeViewModel vm = new CreateEmployeeViewModel();
                        vm.FirstName = emp.FirstName;
                        vm.LastName = emp.LastName;
                        if (emp.Salary.HasValue)
                        {
                            vm.Salary = emp.Salary.ToString();
                        }
                        else
                        {
                            vm.Salary = ModelState["Salary"].Value.AttemptedValue;
                        }
                        return View("CreateEmployee",vm);
                    }                   
                case "Cancel":
                    //return RedirectToAction("Index");
                    return RedirectToAction("Index");
            }
            return new EmptyResult();
        }
    }
}