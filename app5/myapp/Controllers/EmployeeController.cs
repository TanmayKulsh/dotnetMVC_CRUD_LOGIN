using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using myapp.Models;

namespace myapp.Controllers;

public class EmployeeController : Controller
{

    public readonly DBTESTContext _DBTESTContext;

    public EmployeeController(DBTESTContext DBTESTContext)
    {
        _DBTESTContext = DBTESTContext;
    }
    protected override void Dispose(bool disposing)
    {
        _DBTESTContext.Dispose();
    }

    public IActionResult GetEmployees()
    {
        List<Employee> list = _DBTESTContext.Employees.ToList();
        ViewData["allemps"] = list;

        return View();
    }
    [HttpGet]
    public IActionResult Add()
    {

        return View();
    }

    [HttpPost]
    public IActionResult Add(Employee empform)
    {
        _DBTESTContext.Employees.Add(empform);
        _DBTESTContext.SaveChangesAsync();
        return RedirectToAction("GetEmployees");
    }

}
