using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Week09Homework
{
    class Grade : IFile
    {
        public static List<IFile> grades = new List<IFile>();
        public const int MAX_GRADE_COUNT = 9;

        private Student _student;
        public Student Student
        {
            get { return _student; }
        }

        private List<double> _scores = new List<double>();

        public Grade(Student student)
        {
            _student = student;
        }

        public int Count()
        {
            return _scores.Count;
        }
        public double Get(int i)
        {
            return _scores[i];
        }

        public double Average()
        {
            if (this._scores.Count == 0) {
                return -1.0;
            }

            double sum = 0.0;
            foreach (var score in this._scores) {
                sum += score;
            }
            return sum / _scores.Count;
        }

        public void Clear()
        {
            _scores.Clear();
        }

        public bool Add(double score)
        {
            if (_scores.Count >= Grade.MAX_GRADE_COUNT) {
                return false;
            }

            _scores.Add(score);
            return true;
        }
        public string Record
        {
            get
            {
                StringBuilder sb = new StringBuilder(Student.Number + "|");
                for (int i = 0; i < MAX_GRADE_COUNT; i++)
                {

                    if (i < _scores.Count)
                    {
                        sb.Append(_scores[i].ToString() + '|');
                    }
                }
                sb.Append('a');
                return $"{sb}";
            }
        }

        public static Grade Restore(string record, List<IFile> students)
        {
            Grade score = null;
            var sdatas = record.Trim().Split('|');
            var stu = students.FirstOrDefault(m => m != null && ((Student)m).Number == sdatas[0]);

            try
            {
                score = new Grade((Student)stu);
                for (int i = 1; i < sdatas.Length - 1; i++)
                {
                    if (sdatas[i] != null)
                    {
                        score._scores.Add(double.Parse(sdatas[i]));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: Grade\r\n (" + ex.Message + ")");
                throw ex;
            }

            return score;
        }
    }
}