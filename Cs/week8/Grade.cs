using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Week09Homework
{
    class Grade
    {
        public const int MAX_GRADE_COUNT = 9;

        //[숙제] 일반 프로퍼티를 만든다, 단 get만 구현한다
        public string StudentNumber { get; /*private set;*/ }

        private List<double> _scores = new List<double>();

        public Grade(string studentNumber)
        {
            StudentNumber = studentNumber;
        }

        public int Count()
        {
            return _scores.Count;
        }
        public double Get(int i)
        {
            return _scores[i];
        }

        //instance method
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
            //score범위 확인 

            //if (_scores.Count >= MAX_GRADE_COUNT) {
            //if (_scores.Count >= this.MAX_GRADE_COUNT) {
            if (_scores.Count >= Grade.MAX_GRADE_COUNT) {
                return false;
            }

            _scores.Add(score);
            return true;
        }
    }
}