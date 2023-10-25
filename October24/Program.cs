using October24.Models;
using October24.Models.Helpers;

namespace October24
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Helper helper = new Helper();
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
                Console.WriteLine(company);
                Console.WriteLine("=========================================================");
                Console.WriteLine();
                command = helper.PromptCommands();
                switch (command)
                {
                    case 1:
                        Console.Clear();
                        company = helper.GetCompanyFromUser();
                        break;
                    case 2:
                        Console.Clear();
                        var employee = helper.GetEmployeeFromUser();
                        company.AddEmployee(employee);
                        break;
                    case 3:
                        Console.Clear();
                        var employeeUserName = helper.PromptUserAndGetString("Please enter username: ");
                        company.RemoveEmployee(employeeUserName);
                        break;
                    case 4:
                        Console.Clear();
                        var UserName = helper.PromptUserAndGetString("Please enter username: ");
                        if(!company.EmployeeExists(UserName))
                        {
                            break;
                        }
                       var NewEmployee = helper.PromptUpdateEmployeeAndGetEmployee(company.GetEmployee(UserName).Employee);
                       company.UpdateUser(UserName,NewEmployee);
                        break;
                    case 5:
                        Console.Clear();
                        helper.PrintEmployeeArray(company.GetAllEmployees());
                        break;
                    case 6:
                        Console.Clear();
                        var userName = helper.PromptUserAndGetString("Please enter username: ");
                        Console.WriteLine(company.GetEmployee(userName).Employee);
                        break;
                    case 7:
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid command!");
                        break;
                }
                Console.WriteLine();

            } while (command != 7);
        }


    }
}