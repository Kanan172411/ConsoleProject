using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProject.Classes
{
    public class Department
    {
        public Department(string name, int workerlimit,int salarylimit)
        {
            _name = name;
            _workerLimit = workerlimit;
            _salaryLimit = salarylimit;
            employees = new Employee[0];
        }
        private string _name;
        private int _workerLimit;
        private int _salaryLimit;
        public Employee[] employees;
        public string SetDepartmentName 
        {
            get { return _name; }
            set
            {
                    _name = value;
            }
        }
        public int SetWorkerLimit 
        {
            get { return _workerLimit; } 
            set
            {
                    _workerLimit = value;
            } 
        }
        public int SetSalaryLimit 
        {
            get { return _salaryLimit; } 
            set
            {
                    _salaryLimit = value;
            } 
        }
     
        public int CalcAverageSalary()
        {
            int averageSalary = 0;
            for (int i = 0; i < employees.Length; i++)
            {
                averageSalary += employees[i].SetSalary;
            }
            averageSalary = averageSalary / employees.Length;
            return averageSalary;
        }
     
        public void AddEmployee(Employee employee)
        {
            Array.Resize(ref employees, employees.Length + 1);
            employees[employees.Length - 1] = employee;
        }
    }
}
