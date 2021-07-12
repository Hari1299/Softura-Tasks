using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EmployeeInformation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EmployeeInformation.Controllers
{
    public class HomeController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }

        public ActionResult SaveEmployeeInfo(Employee employee)
        {
            List<string> Email = new List<string>();
            Email.Add("kumaran76@gmail.com");
            Email.Add("ganesh12@gmail.com");
            Email.Add("vasu123@gmail.com");
            Email.Add("murugan67@gmail.com");

            if (Email.Contains(employee.Email))
            {
                return Json(new { msg = "Success", FirstName = employee.Firstname, LastName = employee.Lastname, Gender = employee.Gender, Email = employee.Email, skills=employee.Skills});
            }
            //return Json(new { msg = "success" }
          
            else
            {
              return Json(new { msg = "Success", FirstName = employee.Firstname, LastName = employee.Lastname, Gender = employee.Gender });
            }
          

        }
    }
}