using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using myapp.Models;

namespace myapp.Controllers;

public class EmployeeController : Controller
{

    public readonly ShashankContext _shashankContext;

    public EmployeeController(ShashankContext shashankContext)
    {
        _shashankContext = shashankContext;
    }
     protected override void Dispose(bool disposing)
        {
            _shashankContext.Dispose();
        }

    public IActionResult GetEmployees(){
        List<Employee> list = _shashankContext.Employees.ToList();
        ViewData["allemps"] =  list;   

        return View();        
        }
}

        // public IActionResult InsertEmp(){
        // List<Employee> list = _shashankContext.Employees.ToList();
        // ViewData["allemps"] =  list;   

        // return View();        
        // }

//          public ActionResult Save(Employee Employee)
//         {
//             if (!ModelState.IsValid)
//             {
//                 var viewModel = new EmployeeFormViewModel
//                 {
//                     Employee = Employee,
//                     MembershipTypes = _context.MembershipTypes.ToList()
//                 };

//                 return View("EmployeeForm", viewModel);
//             }

//             if (Employee.Id == 0)
//                 _context.Employees.Add(Employee);
//             else
//             {
//                 var EmployeeInDb = _context.Employees.Single(c => c.Id == Employee.Id);
//                 EmployeeInDb.Name = Employee.Name;
//                 EmployeeInDb.Birthdate = Employee.Birthdate;
//                 EmployeeInDb.MembershipTypeId = Employee.MembershipTypeId;
//                 EmployeeInDb.IsSubscribedToNewsletter = Employee.IsSubscribedToNewsletter;
//             }

//             _context.SaveChanges();

//             return RedirectToAction("Index", "Employees");
//         }

// }