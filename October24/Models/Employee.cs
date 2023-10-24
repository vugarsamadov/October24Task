using October24.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace October24.Models
{
    internal class Employee
    {
        private string _name;
        private string _surname;
        private string _username;
        private byte _age;

        public string Name { get => _name; set => _name = Helper.FormatName(value); }
        public string Surname { get => _surname; set => _surname = Helper.FormatName(value); }
        public byte Age { get => _age; set => _age = IsValidAge(value) ? value : _age; }
        public string Username { get => _username; set=>_username = value; }


        public Employee(string name, string surname, byte age)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Username = Name + "_" + Surname;
        }
       
        private bool IsValidAge(byte age)
        {
            return age > 0;
        }

        public override string ToString()
        {
            return $"Employe: {Name} {Surname} is registered with {Username} username";
        }

    }
}
