using October24.Models;
using October24.Models.Helpers;

namespace October24
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Company company = new Company(" E™ ");
            
            //Test employees
            Employee e1 = new Employee("Vugar", "Samadov", 20);
            Employee e2 = new Employee("Andrew", "Tate", 5);
            Employee e3 = new Employee("Bill", "Clinton", 68);

            company.AddEmployee(e1);
            company.AddEmployee(e2);
            company.AddEmployee(e3);

            int command;
            do
            {
                Console.WriteLine("=========================================================");
                Console.WriteLine();
                command = Helper.PromptCommands();
                switch (command)
                {
                    case 1:
                        /* Burani basa dusmedim company coxlu yaratmaq olsun? */
                        break;
                    case 2:
                        var employee = Helper.GetEmployeeFromUser();
                        company.AddEmployee(employee);
                        break;
                    case 3:
                        var employeeUserName = Helper.PromptUserAndGetString("Please enter username: ");
                        company.RemoveEmployee(employeeUserName);
                        break;
                    case 4:
                        var UserName = Helper.PromptUserAndGetString("Please enter username: ");
                        var NewEmployee = Helper.PromptUpdateEmployeeAndGetEmployee();
                        company.UpdateUser(UserName,NewEmployee);
                        break;
                    case 5:
                        Helper.PrintEmployeeArray(company.GetAllEmployees());
                        break;
                    case 6:
                        var userName = Helper.PromptUserAndGetString("Please enter username: ");
                        Console.WriteLine(company.GetEmployee(userName).Employee);
                        break;
                    case 7:
                        break;

                    default:
                        Console.WriteLine("Invalid command!");
                        break;
                }
                Console.WriteLine();

            } while (command < 7);
        }
    }
}