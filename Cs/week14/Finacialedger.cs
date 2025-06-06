using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proj_FinacialLedger_202444086
{
    class Finacialedger : Finacial
    {
        //Finacialedger도 됨

        private int _year;
        private int _targetAmount;
        public int Year { get { return _year; } }
        public int TargetAmount { get { return _targetAmount; } }

        Info nowInfo;

        public bool IsBlack
        {
            get
            {
                try
                {
                    int income = 0;
                    int expenditure = 0;

                    if (_incomes.Count <= 0 || _expenditures.Count <= 0)
                    {
                        return false;
                    }

                    foreach (var inc in _incomes)
                    {
                        //if (true == (income.Value != null))
                        if (false == (inc.Value == null))
                        {
                            income += inc.Value.Money;
                        }
                    }

                    foreach (var ex in _expenditures)
                    {
                        //if (true == (expenditure.Value != null))
                        if (false == (ex.Value == null))
                        {
                            expenditure += ex.Value.Money;
                        }
                    }

                    if (_targetAmount == 0)
                    {
                        if (income > expenditure)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if (0 < _targetAmount || _targetAmount < 0)
                    {
                        int total = income - expenditure;

                        if (_targetAmount < total)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }

                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"TotalIncome error\r\n({ex.Message})");
                    return false;
                }
            }
        }

        public Finacialedger(int year)
        {
            _year = year;
            _targetAmount = 0;
            _incomes = new Dictionary<DateTime, Info>();
            _expenditures = new Dictionary<DateTime, Info>();
        }

        public Finacialedger(int year, int targetAmount)
        {
            _year = year;
            _targetAmount = targetAmount;
            _incomes = new Dictionary<DateTime, Info>();
            _expenditures = new Dictionary<DateTime, Info>();
        }

        public override bool RegIncome(DateTime times, string content, int money)
        {
            if (_year == times.Year)
            {
                nowInfo = new Info(content, money);
                return base.RegIncome(times, content, money);
            }
            else
            {
                return false;
            }
        }

        public override bool RegIncome(string content, int money)
        {
            if (_year == DateTime.Now.Year)
            {
                nowInfo = new Info(content, money);
                return base.RegIncome(content, money);
            }
            else
            {
                return false;
            }
        }

        public override bool RegExpenditure(DateTime times, string content, int money)
        {
            if (_year == times.Year)
            {
                nowInfo = new Info(content, money);
                return base.RegExpenditure(times, content, money);
            }
            else
            {
                return false;
            }
        }

        public override bool RegExpenditure(string content, int money)
        {
            if (_year == DateTime.Now.Year)
            {
                nowInfo = new Info(content, money);
                return base.RegExpenditure(content, money);
            }
            else
            {
                return false;
            }
        }

        public void RenewalTargetYear(int year)
        {
            _year = year;
        }

        public void RenewalTargetAmount(int targetAmount)
        {
            _targetAmount = targetAmount;
        }

        public Info getNowInfo()
        {
            return nowInfo;
        }

        public override string ToString()
        {
            return $"[{Year}] {TargetAmount}";
        }

    }
}
