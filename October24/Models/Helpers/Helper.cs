using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace October24.Models.Helpers
{
    internal static class Helper
    {
        public static string EMPLOYEE_SUBJECT_NAME = "Employee";
        public static string COMPANY_SUBJECT_NAME = "Company";

        public static string FormatName(string name)
        {
            var charArray = name.ToCharArray();

            charArray[0] = char.ToUpper(charArray[0]);

            return new string(charArray);
        }

        public static Employee GetEmployeeFromUser()
        {
            var name = PromptUserAndGetString("Enter employe name: ");
            var surname = PromptUserAndGetString("Enter employe surname: ");
            var age= PromptUserAndGetByte("Enter employe age: ");
            return new Employee(name, surname, age);
        }

        public static Employee PromptUpdateEmployeeAndGetEmployee()
        {
            int command;
            string name ="A";
            string surname="A";
            byte age=0;
            do
            {
                command = Helper.PromptUpdateCommands();

                switch (command)
                {
                    case 1:
                        name = Helper.PromptUserAndGetString("Enter new name: ");
                        break;
                    case 2:
                        surname = Helper.PromptUserAndGetString("Enter surname: ");
                        break;
                    case 3:
                        age = Helper.PromptUserAndGetByte("Enter new age: ");
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

        public static string PromptUserAndGetString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
        public static byte PromptUserAndGetByte(string prompt)
        {
            Console.Write(prompt);
            return Convert.ToByte(Console.ReadLine());
        }

        public static int PromptCommands()
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

        public static int PromptUpdateCommands()
        {
            Console.WriteLine("1 > Update name");
            Console.WriteLine("2 > Update surname");
            Console.WriteLine("3 > Update age");
            Console.WriteLine("4 > Finish Update");

            return Convert.ToInt32(Console.ReadLine());
        }


        public static void PrintEmployeeArray(Employee[] employeeArray)
        {
            foreach (var employee in employeeArray)
            {
                Console.WriteLine(employee);
            }
        }

        public static void RemoveEmployeeFromDatabase(int itemIndx,ref Employee[] Database)
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
