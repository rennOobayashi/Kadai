using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week04Homework
{
    //Object 클래스를 상속한 Department
    class Department
    {
        public string Code;
        public string Name;

        //Python의 __str__()와 동일
        public override string ToString()
        {
            //base.ToString(): object에서 기본 정의된 ToString()
            //ToString은 기본적으로 네임스페이스와 타입을 출력
            return $"[{Code}] {Name}";
        }
    }
}
