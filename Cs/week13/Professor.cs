using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week09Homework
{
    class Professor : Member, IFile
    {
        //public string DepartmentCode { get; set; }

        //private string _number;
        //public string Number
        //{
        //    get { return _number; }
        //}
        //
        //private string _name;
        //public string Name
        //{
        //    get { return _name; }
        //    set { _name = value; }
        //}

        public static List<IFile> professors = new List<IFile>();
        public override string ToString()
        {
            return $"[{Number}]{Name}";
        }

        public Professor(string number, string name, Department dept)
            : base(number, name, dept)
        {
            //_number = number;
            //_name = name;
            //DepartmentCode = deptcode;
        }

        public string Record
        {
            get { return $"{Number}|{Name}|{Dept.Code}"; }
            //Dept.ToString()이 저장
            //get { return $"{Number}|{Name}|{Dept}"; }
        }

        public static Professor Restore(string record, List<IFile> depts)
        {
            Professor prof = null;

            try
            {
                //가능한 split은 배열로 하는 것이 좋음
                var sdatas = record.Trim().Split('|');
                var dept = depts.FirstOrDefault(m => m != null && ((Department)m).Code == sdatas[2]);
                //var dept = depts.Where(m => m != null).FirstOrDefault(m => m.Code == sdatas[2]); <<조건 여러개면

                prof = new Professor(sdatas[0], sdatas[1], (Department)dept);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: Professor\r\n (" + ex.Message + ")");
                throw ex;
            }

            return prof;
        }
    }
}