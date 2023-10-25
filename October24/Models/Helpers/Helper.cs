using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace October24.Models.Helpers
{
    public class Helper
    {

        public Employee GetEmployeeFromUser()
        {
            var name = PromptUserAndGetString("Enter employe name: ");
            var surname = PromptUserAndGetString("Enter employe surname: ");
            var age = PromptUserAndGetsbyte("Enter employe age: ");

            return new Employee(name, surname, age);
        }

        public string PromptUserAndGetString(string prompt)
        {
            string result;
            do
            {
                Console.Write(prompt);
                result = Console.ReadLine();
                if(String.IsNullOrEmpty(result))
                    Console.WriteLine("No empty strings are allowed!");
            } while (String.IsNullOrEmpty(result));
            return result;
        }
        public sbyte PromptUserAndGetsbyte(string prompt)
        {
            sbyte result;
            do
            {
                Console.Write(prompt);
                result = Convert.ToSByte(Console.ReadLine());
                if(result <= 0)
                    Console.WriteLine("No negative or 0 value allowed for this prop!");
            } while (result<0);
            
            return result;
        }

        public Employee PromptUpdateEmployeeAndGetEmployee(Employee oldEmployee)
        {
            int command;
            string name = oldEmployee.Name;
            string surname= oldEmployee.Surname;
            sbyte age= oldEmployee.Age;

            do
            {
                command = PromptUpdateCommands();

                switch (command)
                {
                    case 1:
                        name = PromptUserAndGetString("Enter new name: ");
                        break;
                    case 2:
                        surname = PromptUserAndGetString("Enter surname: ");
                        break;
                    case 3:
                        age = PromptUserAndGetsbyte("Enter new age: ");
                        break;
                    case 4:
                        break;

                    default:
                        Console.WriteLine("Invalid command!");
                        break;
                }
            } while (command < 4);

            return new Employee(name, surname,age);
        }

        public Company GetCompanyFromUser()
        {
            var companyName = PromptUserAndGetString("Enter company name: ");
            return new Company(companyName);
        }

        public int PromptCommands()
        {
            Console.WriteLine("1 > Create a company");
            Console.WriteLine("2 > Create an employee");
            Console.WriteLine("3 > Delete employee");
            Console.WriteLine("4 > Update employee");
            Console.WriteLine("5 > See all employees");
            Console.WriteLine("6 > See employee");
            Console.WriteLine("7 > Quit");

            return Convert.ToInt32(Console.ReadLine());
        }

        public int PromptUpdateCommands()
        {
            Console.WriteLine("1 > Update name");
            Console.WriteLine("2 > Update surname");
            Console.WriteLine("3 > Update age");
            Console.WriteLine("4 > Finish Update");

            return Convert.ToInt32(Console.ReadLine());
        }


        public void PrintEmployeeArray(Employee[] employeeArray)
        {
            foreach (var employee in employeeArray)
            {
                Console.WriteLine(employee);
            }
        }

        public void RemoveEmployeeFromDatabase(int itemIndx,ref Employee[] Database)
        {
            var UpdatedDataBase = new Employee[Database.Length-1];

            for (int i = 0; i < Database.Length; i++) 
            {
                if (i == itemIndx)
                {
                    continue;
                }
                else if (i > itemIndx)
                {
                    UpdatedDataBase[i-1] = Database[i];
                }
                else
                {
                    UpdatedDataBase[i] = Database[i];
                }
            }
            Database = UpdatedDataBase;
        }


    }
}
