using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_FinacialLedger_202444086
{
    class Info
    {
        public string Content { get; set; }
        public int Money { get; set; }

        public Info(string content, int money)
        {
            Content = content;
            Money = money;
        }

        public override string ToString()
        {
            return $"{Content},{Money}";
        }
    }
}
