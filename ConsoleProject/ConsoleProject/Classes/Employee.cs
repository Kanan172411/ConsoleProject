using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProject.Classes
{
    public class Employee
    {
        public Employee(string fullname,string position, int salary,string departmentname )
        {
            _fullname = fullname;
            _position = position;
            _salary = salary;
            DepartmentName = departmentname;
            _no =  DepartmentName[0]  + Counter.ToString();
            Counter++;
        }
        private string _fullname;
        private string _position;
        private int _salary;
        public string DepartmentName;
        private string _no;
        static int Counter = 1001;
        public string SetNo
        {
            get { return _no; }
            set
            {
                _no = DepartmentName[0]  + Counter.ToString();
            }
        }
        public string SetFullName 
        {
            get { return _fullname; }
            set
            {
               _fullname = value;
            } 
        }
        public string SetPosition 
        {
            get { return _position; }
            set
            {
                _position = value;
            }
        }
        public int SetSalary 
        { 
            get { return _salary; }
            set
            {
               _salary = value;
            } 
        }
    }
}
