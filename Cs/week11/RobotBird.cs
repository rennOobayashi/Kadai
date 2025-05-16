using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooApp
{
    class RobotBird : Animal, IRobot
    {
        private int _batteryLevel = 100;

        public int BatteryLevel
        {
            get
            {
                return _batteryLevel;
            }
            set
            {
                if (value > 100)
                {
                    _batteryLevel = 100;
                }
                else
                {
                    _batteryLevel = value;
                }
            }
        }

        public RobotBird(string name, COLOR color, int level = 0) : base(name, color) 
        {
            BatteryLevel = level;
        }

        public void Charge()
        {
            BatteryLevel = 100;
        }

        protected override bool AddLevel(int level)
        {
            if (_level + level <= 50)
            {
                _level += level;
                return true;
            }
            else
            {
                _level = 200;
                return false;
            }
        }

        public string Fly(int cnt)
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < cnt; ++i)
            {
                stringBuilder.Append("푸드륵~");
                if (i + 1 < cnt)
                {
                    stringBuilder.Append("\r\n");
                }
            }

            return stringBuilder.ToString();
        }

        public override string ToString()
        {
            return $"ROBOTBIRD:{Name}";
        }
    }
}
