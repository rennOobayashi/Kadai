using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooApp
{
    class Cat : Animal
    {
        public Cat(string name, COLOR color) : base(name, color) { }

        //Object 클래스의 ToString()을
        //override(재정의)한다.
        public override string ToString()
        {
            return $"CAT:{Name}";
        }

        public string Meow(int count)
        {
            string retValue = "";
            for (int i = 0; i < count; i++) {
                retValue += "냥!";
            }
            return retValue;
        }

        protected override bool AddLevel(int level)
        {
            if (_level + level <= 200) {
                _level += level;
                return true;
            } else {
                _level = 200;
                return false;
            }
        }

        public override void Eat()
        {
            AddLevel(300);
        }

        public new void Play()
        {
            AddLevel(200);
        }
    }
}
