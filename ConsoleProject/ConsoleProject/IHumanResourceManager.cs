using ConsoleProject.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProject
{
    interface IHumanResourceManager
    {
        public Department[] Departments { get; }
        public void AddDepartment(string name,int workerlimit,int salarylimit);
        public Department[] GetDepartments();
        public void EditDepartment(string str,string newstr);
        public void AddEmploye(string fullname, string position, int salary, string departmentname);
        public void RemoveEmployee(string departmentname,string employenumber);
        public void EditEmployee(string employenumber, string newposition,int newsalary,string str);
        public Employee[] GetAllEmployees();
        public Employee[] GetEmployyeWithDEpartmentName(string departmentName);
    }
}
