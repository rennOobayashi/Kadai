using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week09Homework
{
    enum YEAR
    {
        ONE = 0,
        TWO,
        THREE,
        FOUR,

        END,
    }

    enum CLASS
    {
        A = 0,
        B,
        C,

        END,
    }

    enum REG_STATUS
    {
        ENROLLED = 0,
        GRADUATED,
        ONLEAVE,
        EXPELLED,

        END,
    }

    class Student : Member, IFile
    {
        //static 필드
        public static List<IFile> students = new List<IFile>();
        public static Dictionary<YEAR, string> YearName
            = new Dictionary<YEAR, string>{
                { YEAR.ONE,   "1학년" },
                { YEAR.TWO,   "2학년" },
                { YEAR.THREE, "3학년" },
                { YEAR.FOUR,  "4학년(심화)" },
            };

        public static Dictionary<REG_STATUS, string> RegStatusName
            = new Dictionary<REG_STATUS, string>{
                { REG_STATUS.ENROLLED,    "재학"},
                { REG_STATUS.GRADUATED,   "졸업"},
                { REG_STATUS.ONLEAVE,     "휴학"},
                { REG_STATUS.EXPELLED,    "퇴학"},
            };

        //public string Number { get; private set; }
        //public string Name { get; private set; }
        public DateTime BirthInfo { get; private set; }
        public void SetBirthInfo(int year, int month, int day)
        {
            BirthInfo = new DateTime(year, month, day);
        }
        //public string DepartmentCode { get; set; }
        public Professor Advisor { get; set; }
        public YEAR Year { get; set; }
        public CLASS Class { get; set; }
        public REG_STATUS RegStatus { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }

        public Student(string number, string name)
            //: this(number, name, null)
            : base(number, name, null)
        {
            //Number = number;
            //Name = name;
        }
        public Student(string number, string name, Department dept)
             : base(number, name, dept)
        {
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return $"[{this.Number}]{this.Name}";
        }

        public string Record
        {
            get { return $"{Number}|{Name}|{Dept.Code}|{BirthInfo:yyyy.MM.dd}|{Advisor.Number}|{Year}|{(int)Class}|{(int)RegStatus}|{Address}|{Contact}"; }
        }

        public static Student Restore(string record, List<IFile> depts, List<IFile> profs)
        {
            Student stu = null;

            try
            {
                var sdatas = record.Trim().Split('|');

                if (sdatas.Length == 10)
                {
                    var dept = depts.FirstOrDefault(m => m != null && ((Department)m).Code == sdatas[2]);
                    stu = new Student(sdatas[0], sdatas[1], (Department)dept);

                    //3 생일
                    //DateTime.ParseExact(sdatas[3], "yyyyMMdd", null)
                    var date = sdatas[3].Trim().Split('.');
                    if (date.Length == 3)
                    {
                        if (int.TryParse(date[0], out int y))
                        {

                            if (int.TryParse(date[1], out int m))
                            {

                                if (int.TryParse(date[2], out int d))
                                {
                                    stu.SetBirthInfo(y, m, d);
                                }
                            }
                        }
                    }
                    //4 지도교수
                    var prof = profs.FirstOrDefault(m => m != null && ((Professor)m).Number == sdatas[4]);
                    stu.Advisor = (Professor)prof;
                    //5 학년
                    if (Enum.TryParse<YEAR>(sdatas[5], out var year))
                    {
                        stu.Year = year;
                    }
                    else
                    {
                        stu.Year = YEAR.ONE;
                    }
                    //6 반
                    if (Enum.TryParse<CLASS>(sdatas[6], out var c))
                    {
                        stu.Class = c;
                    }
                    //7 재적여부
                    if (int.TryParse(sdatas[7], out var reg))
                    {
                        stu.RegStatus = (REG_STATUS)reg;
                    }
                    //8 주소
                    stu.Address = sdatas[8];
                    //9 번호
                    stu.Contact = sdatas[9];
                }
            }
            catch //(Exception ex)
            {
                Console.WriteLine("무사고 1일차");
                //Console.WriteLine($"Error: Student\r\n ({ex.Message})");
                //throw ex;
            }

            return stu;
        }

    }
}