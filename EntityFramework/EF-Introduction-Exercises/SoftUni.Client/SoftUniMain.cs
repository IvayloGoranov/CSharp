using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using EntityFramework.Extensions;

using SoftUni.Data;

namespace SoftUni.Client
{
    public class SoftUniMain
    {
        public static void Main()
        {
            SoftUniContext context = new SoftUniContext();
            //IEnumerable<Employee> allEmployees = context.Employees;

            //foreach (var employee in allEmployees)
            //{
            //    Console.WriteLine("{0} {1} {2} {3} {4:0.00}", 
            //        employee.FirstName, employee.LastName, employee.MiddleName,
            //        employee.JobTitle, employee.Salary);
            //}

            //var allEmployeesWithSalaryOver50000 = context.Employees.
            //    Where(e => e.Salary > 50000).Select(e => e.FirstName);

            //foreach (var employee in allEmployeesWithSalaryOver50000)
            //{
            //    Console.WriteLine(employee);
            //}

            //var allEmployeesFromDepartment = context.Employees.
            //    Include(x => x.Departments).
            //    Where(x => x.Department.Name == "Research and Development").
            //    OrderBy(x => x.Salary).
            //    ThenByDescending(x => x.FirstName).
            //    Select(e => 
            //    new {
            //            e.FirstName,
            //            e.LastName,
            //            Department = e.Department.Name,
            //            e.Salary
            //        });

            //foreach (var employee in allEmployeesFromDepartment)
            //{
            //    Console.WriteLine("{0} {1} from {2} - ${3:F2}", employee.FirstName, employee.LastName,
            //        employee.Department, employee.Salary);
            //}

            //var address = new Address
            //{
            //    AddressText = "Vitoshka 15",
            //    TownID = 4
            //};

            //var nakov = context.Employees.FirstOrDefault(x => x.LastName == "Nakov");
            //nakov.Address = address;

            //context.SaveChanges();

            //var allEmployeesAddresses = context.Employees.
            //    Include(x => x.Address).
            //    OrderByDescending(x => x.AddressID).
            //    Select(x => x.Address.AddressText).
            //    Take(10);

            //foreach (var a in allEmployeesAddresses)
            //{
            //    Console.WriteLine(a);
            //}

            //var project = context.Projects.Find(2);

            //foreach (var emp in context.Employees.Include(x => x.Projects))
            //{
            //    emp.Projects.Remove(project);
            //}

            //context.Projects.Remove(project);
            //context.SaveChanges();

            //var projects = context.Projects.
            //    Select(x => x.Name).
            //    Take(10);

            //foreach (var p in projects)
            //{
            //    Console.WriteLine(p);
            //}

            //var employeesWithProjects = context.Employees.
            //    Include(x => x.Projects).
            //    Include(x => x.Subordinates).
            //    Where(x => x.Projects.Count(p => p.StartDate.Year >= 2001 && p.StartDate.Year <= 2003) > 0).
            //    Select(x => new
            //    {
            //        x.FirstName,
            //        x.LastName,
            //        ManagerName = x.Manager.FirstName,
            //        Projects = x.Projects.Where(p => p.StartDate.Year >= 2001 && p.StartDate.Year <= 2003).
            //            Select(p => new { p.Name, p.StartDate, p.EndDate })
            //    }).
            //    Take(30);

            //foreach (var item in employeesWithProjects)
            //{
            //    Console.WriteLine("{0} {1} {2}", item.FirstName, item.LastName, item.ManagerName);
            //    foreach (var p in item.Projects)
            //    {
            //        Console.WriteLine("--{0} {1} {2}", p.Name, p.StartDate, p.EndDate);
            //    }
            //}

            //var allAdresses = context.Addresses.
            //    Include(x => x.Employees).
            //    OrderByDescending(x => x.Employees.Count).
            //    ThenBy(x => x.Town.Name).
            //    Select(x => new { x.AddressText, TownName = x.Town.Name, EmployeesCount = x.Employees.Count }).
            //    Take(10);

            //foreach (var item in allAdresses)
            //{
            //    Console.WriteLine("{0} {1} {2} employees", item.AddressText, item.TownName, item.EmployeesCount);
            //}

            //var employee147 = context.Employees.Find(147);

            //Console.WriteLine("{0} {1} {2}", employee147.FirstName, employee147.LastName, employee147.JobTitle);
            //foreach (var item in employee147.Projects.OrderBy(x => x.Name))
            //{
            //    Console.WriteLine(item.Name);
            //}

            var departments = context.Departments.
                Include(x => x.Employees).
                Where(x => x.Employees.Count > 5).
                OrderBy(x => x.Employees.Count).
                Select(x => new { x.Name, Manager = x.Employee.FirstName,
                    Employees = x.Employees.Select(e => new { e.FirstName, e.LastName, e.JobTitle })});

            foreach (var item in departments)
            {
                Console.WriteLine("{0} {1}", item.Name, item.Manager);
                foreach (var emp in item.Employees)
                {
                    Console.WriteLine("{0} {1} {2}", emp.FirstName, emp.LastName, emp.JobTitle);
                }
            }
        }
    }
}
