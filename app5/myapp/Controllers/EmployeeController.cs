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
    public IActionResult Edit(int id)
    {
        var emp =_DBTESTContext.Employees.FirstOrDefault(x => x.Id == id);
        return View(emp);
    }


    [HttpPost]
    public IActionResult Edit(Employee empUpdate)
    {
        var emp = new Employee()
        {
            Id = empUpdate.Id,
            Name = empUpdate.Name,
            Email = empUpdate.Email,
            Address = empUpdate.Address,
            Phone = empUpdate.Phone,
        };

        _DBTESTContext.Employees.Update(emp);
        _DBTESTContext.SaveChanges();
        return RedirectToAction("GetEmployees");
    }

    [HttpGet]
    public IActionResult Login()
    {

        return View();
    }

    [HttpPost]
    public IActionResult Login(Employee empform)
    {
        List<Employee> list = _DBTESTContext.Employees.ToList();
        foreach (Employee item in list)
        {
            if (empform.Email == item.Email && empform.Id == item.Id)
            {

                return RedirectToAction("GetEmployees");
            }
        }
        return RedirectToAction("Login");
    }

}