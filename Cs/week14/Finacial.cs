using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_FinacialLedger_202444086
{
    abstract class Finacial
    {
        protected Dictionary<DateTime, Info> _incomes;
        protected Dictionary<DateTime, Info> _expenditures;
        public int TotalIncome 
        {
            get
            {
                try
                {
                    if (_incomes.Count <= 0)
                    {
                        return 0;
                    }

                    int moneys = 0;

                    foreach (var income in _incomes)
                    {
                        //if (true == (income.Value != null))
                        if (false == (income.Value == null))
                        {
                            moneys += income.Value.Money;
                        }
                    }

                    return moneys;
                }
                catch (NullReferenceException ex)
                {
                    Console.WriteLine($"TotalIncome item is null error\r\n({ex.Message})");
                    return 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"TotalIncome error\r\n({ex.Message})");
                    return 0;
                }
            }
        }
        public int TotalExpenditure 
        { 
            get
            {
                try
                {
                    if (_expenditures.Count <= 0)
                    {
                        return 0;
                    }

                    int moneys = 0;

                    foreach (var expenditure in _expenditures)
                    {
                        //if (true == (expenditure.Value != null))
                        if (false == (expenditure.Value == null))
                        {
                            moneys += expenditure.Value.Money;
                        }
                    }

                    return moneys;
                }
                catch (NullReferenceException ex)
                {
                    Console.WriteLine($"expenditure item is null error\r\n({ex.Message})");
                    return 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"TotalExpenditure error\r\n({ex.Message})");
                    return 0;
                }
            }
        }

        public virtual bool RegIncome(DateTime times, string content, int money)
        {
            if (money > 0)
            {
                if (_incomes.ContainsKey(times))
                {
                    return false;
                }

                _incomes.Add(times, new Info(content, money));
                return true;
            }

            return false;
        }

        public virtual bool RegIncome(string content, int money)
        {
            if (money > 0)
            {
                if (_incomes.ContainsKey(DateTime.Now))
                {
                    return false;
                }

                _incomes.Add(DateTime.Now, new Info(content, money));
                return true;
            }

            return false;
        }

        public virtual bool RegExpenditure(DateTime times, string content, int money)
        {
            if (money > 0)
            {
                if (_expenditures.ContainsKey(times))
                {
                    return false;
                }
                _expenditures.Add(times, new Info(content, money));
                return true;
            }

            return false;
        }

        public virtual bool RegExpenditure(string content, int money)
        {
            if (money > 0)
            {
                if (_expenditures.ContainsKey(DateTime.Now))
                {
                    return false;
                }
                _expenditures.Add(DateTime.Now, new Info(content, money));
                return true;
            }

            return false;
        }
    }
}
