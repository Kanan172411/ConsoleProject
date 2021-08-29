using ConsoleProject.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleProject
{
    public class HumanResoruceManager : IHumanResourceManager
    {
        public HumanResoruceManager()
        {
            _departments= new Department[0];
        }
        private Department[] _departments;
        public Department[] Departments => _departments;
        public void AddDepartment(string name, int workerlimit, int salarylimit)
        {
            Department department = new Department(name, workerlimit,salarylimit);
            foreach (var item in _departments)
            {
                if (item.SetDepartmentName == department.SetDepartmentName)
                {
                    Console.WriteLine($"{item.SetDepartmentName} adinda department movcuddur");
                    return;
                }
            }
            Array.Resize(ref _departments, _departments.Length + 1);
            _departments[_departments.Length - 1] = department;
        }
        public Department[] GetDepartments()
        {
            if (_departments.Length==0)
            {
                Console.WriteLine("Departament yaradilmiyib");
                return null;
            }
            return _departments;
        }
        public void EditDepartment(string str, string newstr)
        {
            Department department = FindDepartmentWithName(str);
            department.SetDepartmentName = newstr;
            for (int i = 0; i < department.employees.Length; i++)
            {
                department.employees[i].DepartmentName = newstr;
            }
        }
        public void AddEmploye(string fullname, string position, int salary, string departmentname)
        {
            int chehcking = SumOfSalary(departmentname) + salary;
            Department department = FindDepartmentWithName(departmentname);
            if (department.employees.Length>=department.SetWorkerLimit)
            {
                Console.WriteLine("Departamentin isci limit asildi");
                return;
            }
            if (chehcking>FindDepartmentWithName(departmentname).SetSalaryLimit)
            {
                Console.WriteLine("Departamentin maas limiti asildi");
                return;
            }
            Employee employee = new Employee(fullname, position, salary, departmentname);
            department.AddEmployee(employee);
        }
        public void RemoveEmployee(string departmentname, string employenumber)
        {
            Department department = FindDepartmentWithName(departmentname);
            for (int i = 0; i < department.employees.Length; i++) 
            {
                if (employenumber == department.employees[i].SetNo)
                {
                    Employee employeeToRemove =department.employees[i];
                    department.employees = department.employees.Where(val => val != employeeToRemove).ToArray();
                }
                else { Console.WriteLine($"{employenumber} nomresinde isci movcud deyil"); }
            }
        }
        public void EditEmployee(string employenumber, string newposition, int newsalary,string str)
        {
            Department department = FindDepartmentWithName(str);
            for (int i = 0; i < department.employees.Length; i++)
            {
                if (department.employees[i].SetNo == employenumber)
                {
                    department.employees[i].SetPosition = newposition;
                    department.employees[i].SetSalary = newsalary;
                }
            }
        }
        public Department FindDepartmentWithName(string name)
        {
            foreach (var item in _departments)
            {
                if (item.SetDepartmentName == name)
                {
                    return item;
                }
            }
            return null;
        }
        public Employee[] GetAllEmployees()
        {

            Employee[] employees = new Employee[0];

            foreach (var department in _departments)
            {
                foreach (var employee in department.employees)
                {
                    Array.Resize(ref employees, employees.Length + 1);
                    employees[employees.Length - 1] = employee;
                }
            }
            return employees;
        }
        public Employee[] GetEmployyeWithDEpartmentName(string departmentName)
        {
            Department department = FindDepartmentWithName(departmentName);

            if (department == null)
            {
                Console.WriteLine($"{departmentName} adinda departament movcud deyil!");
                return null;
            }
            if (department.employees.Length == 0)
            {
                return null;
            }

            return department.employees;
        }
        public int SumOfSalary(string departmentname)
        {
            int sum = 0;
            for (int i = 0; i < FindDepartmentWithName(departmentname).employees.Length; i++)
            {
                sum += FindDepartmentWithName(departmentname).employees[i].SetSalary;
            }
            return sum;
        }
    }
}
