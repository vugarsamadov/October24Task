using October24.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace October24.Models
{
    public class Employee
    {
        private string _name;
        private string _surname;
        private string _username;
        private sbyte _age;

        public string Name { get => _name; set => _name = FormatName(value); }
        public string Surname { get => _surname; set => _surname = FormatName(value); }
        public sbyte Age { get => _age; set => _age = IsValidAge(value) ? value : _age; }
        public string Username { get => _username; set=>_username = value; }


        public Employee(string name, string surname, sbyte age)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Username = Name + "_" + Surname;
        }
       
        private bool IsValidAge(sbyte age)
        {
            return age > 0;
        }

        public override string ToString()
        {
            return $"Employe: {Name} {Surname} is registered with {Username} username";
        }

        private string FormatName(string name)
        {
            var charArray = name.ToCharArray();

            charArray[0] = char.ToUpper(charArray[0]);

            return new string(charArray);
        }
    }
}
