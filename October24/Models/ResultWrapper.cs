using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace October24.Models
{
    public class ResultWrapper
    {
        private int _foundIndex;
        private string _searchSubject;
        private Company _company;
        private Employee _employee;


        public ResultWrapper(int foundIndex, string searchSubject,Employee emp)
        {
            FoundIndex = foundIndex;
            SearchSubject = searchSubject;
            Employee = emp;
        }
        public ResultWrapper(int foundIndex, string searchSubject, Company comp)
        {
            FoundIndex = foundIndex;
            SearchSubject = searchSubject;
            Company = comp;
        }
        public ResultWrapper(int foundIndex)
        {
            FoundIndex = foundIndex;
        }

        public bool IsFail()
        {
            return FoundIndex == -1;
        }

        public int FoundIndex { get => _foundIndex; set => _foundIndex = value; }
        public string SearchSubject { get => _searchSubject; set => _searchSubject = value; }
        internal Company Company { get => _company; set => _company = value; }
        internal Employee Employee { get => _employee; set => _employee = value; }
    }
}
