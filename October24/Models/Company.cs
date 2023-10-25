using October24.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace October24.Models
{
    public class Company
    {
        private Helper helper = new Helper();
        private string EMPLOYEE_SUBJECT_NAME = "Employee";
        private string COMPANY_SUBJECT_NAME = "Company";


        private string _name;
        public string Name
        {
            get => _name;
            set => _name = FormatName(value);
        }

        private Employee[] _employees = new Employee[0];

        public Company(string name)
        {
            Name = name;
        }

        public Employee[] Employees
        { 
            get => _employees;
            set => _employees = value;
        }

        public void AddEmployee(Employee employee)
        {
            Array.Resize(ref _employees, _employees.Length+1);
            _employees[_employees.Length - 1] = employee;
        }

        public void RemoveEmployee(string userName)
        {
            if (!EmployeeExists(userName)) return;
            var employeeIndx = GetEmployee(userName).FoundIndex;

            helper.RemoveEmployeeFromDatabase(employeeIndx, ref _employees);
        }

        public ResultWrapper GetEmployee(string userName)
        {
            for (int i = 0; i < Employees.Length; i++)
            {
                if (Employees[i].Username == userName)
                {
                    return new ResultWrapper(i,EMPLOYEE_SUBJECT_NAME,Employees[i]);
                }
            }
            Console.WriteLine("There exists no user with the provided username.");
            return new ResultWrapper(-1);
        }

        public bool EmployeeExists(string userName)
        {
            return !GetEmployee(userName).IsFail();
        }

        public Employee[] GetAllEmployees() 
        {
            return Employees;
        }

        public override string ToString()
        {
            return $@"
Company : {Name}
Employee Count: {Employees.Length}
";
        }

        public void UpdateUser(string userName, Employee newEmployee)
        {
            var searchResult = GetEmployee(userName);

            if (searchResult.IsFail())
            {
                Console.WriteLine("There exists no user with the provided username.");
                return;
            }
            searchResult.Employee.Name = String.IsNullOrEmpty(newEmployee.Name) ? searchResult.Employee.Name : newEmployee.Name;
            searchResult.Employee.Username = String.IsNullOrEmpty(newEmployee.Username) ? searchResult.Employee.Username : newEmployee.Username;
            searchResult.Employee.Age = newEmployee.Age;
        }

        private string FormatName(string name)
        {
            var charArray = name.ToCharArray();

            charArray[0] = char.ToUpper(charArray[0]);

            return new string(charArray);
        }

    }
}
