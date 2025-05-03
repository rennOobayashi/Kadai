using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week09Homework
{
    class Professor
    {
        public string DepartmentCode { get; set; }
        
        public string Number { get; /*private set;*/ }

        private string _name;
        public string Name {
            get { return _name; }
            set { _name = value; }
        } 

        public override string ToString()
        {
            return $"[{Number}]{Name}";
        }

        public Professor(string number, string name, string departmentCode)
        {
            Number = number;
            Name = name;
            DepartmentCode = departmentCode;
        }
    }
}
