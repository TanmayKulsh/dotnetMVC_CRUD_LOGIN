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
    public IActionResult Add(Employee empformadd)
    {
        _DBTESTContext.Employees.Add(empformadd);
        _DBTESTContext.SaveChanges();
        return RedirectToAction("GetEmployees");
    }

    [HttpGet]
    public IActionResult Delete(Employee empformdel)
    {
        _DBTESTContext.Employees.Remove(empformdel);
        _DBTESTContext.SaveChanges();
        return RedirectToAction("GetEmployees");
    }
    [HttpGet]
    public IActionResult Edit(Employee empformedit)
    {
        return RedirectToAction("EditView",empformedit);
    }

    [HttpGet]
    public IActionResult EditView(Employee empformedit)
    {
        Employee emp = _DBTESTContext.Employees.Find(empformedit.Id);
        ViewData["empedit"] = emp;
        return View();
    }

    [HttpPost]
    public IActionResult updateEmp(Employee empUpdate)
    {
        var emp = _DBTESTContext.Employees.FirstOrDefault(x=>x.Id==empUpdate.Id);
        if(emp != null){
            emp.Name=empUpdate.Name;
            emp.Email=empUpdate.Email;
            emp.Address=empUpdate.Address;
            emp.Phone=empUpdate.Phone;

            
        }
        _DBTESTContext.SaveChanges();
        return RedirectToAction("GetEmployees"); 
    }

    [HttpGet]
    public IActionResult Login()
    {

        return View();
    }

    [HttpPost]
    public IActionResult Login(Employee empformadd)
    {
        _DBTESTContext.Employees.Add(empformadd);
        _DBTESTContext.SaveChanges();
        return RedirectToAction("GetEmployees");
    }

}