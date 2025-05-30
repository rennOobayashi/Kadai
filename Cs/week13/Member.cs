using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week09Homework
{
    abstract class Member
    {
        public string Number { get; protected set; }
        public string Name { get; protected set; }
        public Department Dept { get; set; }

        public Member(string number, string name, Department dept)
        {
            Number = number;
            Name = name;
            Dept = dept;
        }
    }
}