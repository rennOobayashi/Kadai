using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proj_FinacialLedger_202444086
{
    public partial class Form1 : Form
    {
        public static string PATH 
        {
            get {
                var path = "C:\\class_c";

                if (false == Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                return path;
            }
        }
        public static string FULLPATH = null;


        Finacialedger finacialedger = null;


        public Form1()
        {
            InitializeComponent();
            ClearAll();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void ClearAll()
        {
            tbxYear.Text = string.Empty;
            tbxTargetAmount.Text = string.Empty;
            tbxYear.Enabled = true;
            tbxTargetAmount.Enabled = true;

            btnIncome.Enabled = false;
            btnExoenditure.Enabled = false;
            btnQuickIncome.Enabled = false;
            btnQuickExpenditure.Enabled = false;

            tbxIncomeYear.Text = string.Empty;
            tbxIncomeMonth.Text = string.Empty;
            tbxIncomeDay.Text = string.Empty;
            tbxIncomeContent.Text = string.Empty;
            tbxIncomeMoney.Text = string.Empty;

            tbxExpenditureYear.Text = string.Empty;
            tbxExpenditureMonth.Text = string.Empty;
            tbxExpenditureDay.Text = string.Empty;
            tbxExpenditureContent.Text = string.Empty;
            tbxExpenditureMoney.Text = string.Empty;

            tbxQuickContent.Text = string.Empty;
            tbxQuickMoney.Text = string.Empty;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxYear.Text))
            {
                MessageBox.Show("년도가 비어있습니다.");
                tbxYear.Focus();
                return;
            }

            Finacialedger fin = null;
            int year = 0;
            int targetAmount = 0;

            if (int.TryParse(tbxYear.Text, out year))
            {
                if (false == (1900 < year && year < 2100))
                {
                    MessageBox.Show("년도는 1900에서 2100 사이만 입력 가능합니다.");
                    tbxYear.Focus();
                    return;
                }
            }
            else
            {
                MessageBox.Show("년도는 정수 숫자만 입력 가능합니다.");
                tbxYear.Focus();
                return;
            }

            if (string.IsNullOrEmpty(tbxTargetAmount.Text))
            {
                tbxTargetAmount.Text = "0";
                fin = new Finacialedger(year);
            }
            else
            {

                if (int.TryParse(tbxTargetAmount.Text, out targetAmount))
                {
                    //목표 흑자액에 음수일 경우도 있을 듯
                    if (targetAmount == 0)
                    {
                        fin = new Finacialedger(year);
                        MessageBox.Show("목표 흑자액은 0이외에만 가능합니다.");
                    }
                    else
                    {
                        fin = new Finacialedger(year, targetAmount);
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(tbxTargetAmount.Text))
                    {
                        fin = new Finacialedger(year);
                        MessageBox.Show("목표 흑자액을 입력해주세요.");
                    }
                    MessageBox.Show("목표 흑자액은 정수 숫자만 입력 가능합니다.");
                    tbxTargetAmount.Focus();
                    return;
                }
            }

            finacialedger = fin;

            tbxTargetAmount.Enabled = false;
            btnIncome.Enabled = true;
            btnExoenditure.Enabled = true;
            btnQuickIncome.Enabled = true;
            btnQuickExpenditure.Enabled = true;

            MessageBox.Show("추가되었습니다.");

            try
            {
                FULLPATH = year.ToString() + ".txt";
                using (var fs = new FileStream(Path.Combine(PATH, year.ToString() + ".txt"), FileMode.Create))
                {
                    using (var sw = new StreamWriter(fs, Encoding.UTF8))
                    {
                        sw.WriteLine(finacialedger.TargetAmount);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"가계부 저장에 실패했습니다.\r\n{ex.Message}");
                return;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(PATH))
            {
                var files = Directory.GetFiles(PATH);

                if (files != null && files.Length > 0)
                {
                    foreach (var file in files)
                    {
                        var fileName = Path.GetFileName(file);
                        if (fileName.Trim().Split('.')[0] != tbxYear.Text)
                        {
                            continue;
                        }

                        try 
                        {
                            using (var fs = new FileStream(Path.Combine(PATH, file), FileMode.Open))
                            {
                                using (var sr = new StreamReader(fs))
                                {
                                    Dictionary<int, Finacialedger> fin = new Dictionary<int, Finacialedger>();
                                    int lines = 0;
                                    int key = 0;
                                    int year = int.Parse(tbxYear.Text);

                                    lbxIncomes.Items.Clear();
                                    lbxExpenditures.Items.Clear();
                                    lbxAll.Items.Clear();

                                    while (false == sr.EndOfStream)
                                    {
                                        if (lines == 0)
                                        {
                                            key = int.Parse(sr.ReadLine());
                                            fin[year] = new Finacialedger(year, key);
                                        }
                                        else
                                        {
                                            var data = sr.ReadLine();

                                            if (data != null)
                                            {
                                                var items = data.Split(',');

                                                try
                                                {
                                                    DateTime times = DateTime.ParseExact(items[0], "yyyyMMdd HHmmssfff", null);
                                                    if (items[3] == "0")
                                                    {
                                                        fin[year].RegIncome(times, items[1], int.Parse(items[2]));
                                                        lbxIncomes.Items.Add(fin[year].getNowInfo());
                                                        lbxAll.Items.Add(fin[year].getNowInfo());
                                                    }
                                                    else if (items[3] == "1")
                                                    {
                                                        fin[year].RegExpenditure(times, items[1], int.Parse(items[2]));
                                                        lbxExpenditures.Items.Add(fin[year].getNowInfo());
                                                        lbxAll.Items.Add(fin[year].getNowInfo());
                                                    }
                                                }
                                                catch (NullReferenceException ex)
                                                {
                                                    Console.WriteLine($"NullReferenceException error\r\n({ex.Message})");
                                                    continue;
                                                }
                                                catch (Exception ex)
                                                {
                                                    Console.WriteLine($"Error\r\n({ex.Message})");
                                                    continue;
                                                }
                                            }
                                        }
                                        lines++;
                                    }
                                    lblPrintNowMoney.Text = (fin[year].TotalIncome - fin[year].TotalExpenditure).ToString();
                                    lblPrintTotalIncome.Text = fin[year].TotalIncome.ToString();
                                    lblPrintTotalExpenditure.Text = fin[year].TotalExpenditure.ToString();
                                    lblPrintBlack.Text = (fin[year].IsBlack) ? "흑자" : "적자";
                                }
                            }
                        }
                        catch 
                        {
                            
                        }
                    }
                }
            }
        }

        private void btnwIncome_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxIncomeMoney.Text))
            {
                MessageBox.Show("넣으려는 돈이 비어있습니다.");
                tbxIncomeMoney.Focus();
                return;
            }
            if (finacialedger == null)
            {
                MessageBox.Show("가계부를 먼저 만들어주세요.");
                return;
            }

            int money = 0;

            if (int.TryParse(tbxIncomeMoney.Text, out money))
            {

            }
            else
            {
                MessageBox.Show("금액은 정수 숫자만 입력 가능합니다.");
                tbxIncomeMoney.Focus();
                return;
            }

            int year = 0;
            int month = 0;
            int day = 0;

            if (int.TryParse(tbxIncomeYear.Text, out year))
            {
                //if (!(1900 <= year && year <= 2100))
                if (false == (1900 <= year && year <= 2100))
                {
                    MessageBox.Show("1900~2100년 이내로만 입력 가능합니다.");
                    return;
                }
            }
            else
            {
                if (false == string.IsNullOrEmpty(tbxIncomeYear.Text))
                {
                    MessageBox.Show("년도는 정수 숫자만 입력 가능합니다.");
                    tbxIncomeYear.Focus();
                    return;
                }
                else
                {
                    MessageBox.Show("년도를 입력해주세요.");
                    return;
                }
            }


            if (int.TryParse(tbxIncomeMonth.Text, out month))
            {
                //if (!(1900 <= year && year <= 2100))
                if (false == (1 <= month && month <= 12))
                {
                    MessageBox.Show("1~12월 이내로만 입력 가능합니다.");
                    return;
                }
            }
            else
            {
                if (false == string.IsNullOrEmpty(tbxIncomeMonth.Text))
                {
                    MessageBox.Show("월은 정수 숫자만 입력 가능합니다.");
                    tbxIncomeMonth.Focus();
                    return;
                }
                else
                {
                    MessageBox.Show("월을 입력해주세요.");
                    return;
                }
            }

            if (int.TryParse(tbxIncomeDay.Text, out day))
            {
                //if (!(1900 <= year && year <= 2100))
                if (false == (1 <= day && day <= 31))
                {
                    MessageBox.Show("1~31일 이내로만 입력 가능합니다.");
                    return;
                }
            }
            else
            {
                if (false == string.IsNullOrEmpty(tbxIncomeDay.Text))
                {
                    MessageBox.Show("일은 정수 숫자만 입력 가능합니다.");
                    tbxIncomeDay.Focus();
                    return;
                }
                else
                {
                    MessageBox.Show("일을 입력해주세요.");
                    return;
                }
            }

            if (finacialedger.RegIncome(new DateTime(year, month, day), tbxIncomeContent.Text, money))
            {
                MessageBox.Show("수입이 등록되었습니다.");
                lblPrintNowMoney.Text = (finacialedger.TotalIncome - finacialedger.TotalExpenditure).ToString();
                lblPrintTotalIncome.Text = finacialedger.TotalIncome.ToString();

                lbxIncomes.Items.Add(finacialedger.getNowInfo());
                lbxAll.Items.Add(finacialedger.getNowInfo());

                lblPrintBlack.Text = (finacialedger.IsBlack) ? "흑자" : "적자";

                try
                {
                    using (var fs = new FileStream(Path.Combine(PATH, FULLPATH), FileMode.Append))
                    {
                        using (var sw = new StreamWriter(fs))
                        {
                            sw.WriteLine($"{new DateTime(year, month, day).ToString("yyyyMMdd HHmmssfff")},{tbxIncomeContent.Text},{money},0");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"수입 등록에 실패했습니다. 다시 시도해주세요.\r\n({ex.Message})");
                    return;
                }
            }
            else
            {
                MessageBox.Show("수입 등록에 실패했습니다. 다시 시도해주세요.");
            }

        }


        private void btnExoenditure_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxExpenditureMoney.Text))
            {
                MessageBox.Show("넣으려는 돈이 비어있습니다.");
                tbxExpenditureMoney.Focus();
                return;
            }
            if (finacialedger == null)
            {
                MessageBox.Show("가계부를 먼저 만들어주세요.");
                return;
            }

            int money = 0;

            if (int.TryParse(tbxExpenditureMoney.Text, out money))
            {

            }
            else
            {
                MessageBox.Show("금액은 정수 숫자만 입력 가능합니다.");
                tbxExpenditureMoney.Focus();
                return;
            }

            int year = 0;
            int month = 0;
            int day = 0;

            if (int.TryParse(tbxExpenditureYear.Text, out year))
            {
                //if (!(1900 <= year && year <= 2100))
                if (false == (1900 <= year && year <= 2100))
                {
                    year = DateTime.Now.Year;
                }
            }
            else
            {
                if (false == string.IsNullOrEmpty(tbxExpenditureYear.Text))
                {
                    MessageBox.Show("년도는 정수 숫자만 입력 가능합니다.");
                    tbxExpenditureYear.Focus();
                    return;
                }
                else
                {
                    year = DateTime.Now.Year;
                }
            }


            if (int.TryParse(tbxExpenditureMonth.Text, out month))
            {
                //if (!(1900 <= year && year <= 2100))
                if (false == (1 <= month && month <= 12))
                {
                    month = DateTime.Now.Month;
                }
            }
            else
            {
                if (false == string.IsNullOrEmpty(tbxExpenditureMonth.Text))
                {
                    MessageBox.Show("월은 정수 숫자만 입력 가능합니다.");
                    tbxExpenditureMonth.Focus();
                    return;
                }
                else
                {
                    month = DateTime.Now.Month;
                }
            }

            if (int.TryParse(tbxExpenditureDay.Text, out day))
            {
                //if (!(1900 <= year && year <= 2100))
                if (false == (1 <= day && day <= 31))
                {
                    day = DateTime.Now.Day;
                }
            }
            else
            {
                if (false == string.IsNullOrEmpty(tbxExpenditureDay.Text))
                {
                    MessageBox.Show("일은 정수 숫자만 입력 가능합니다.");
                    tbxExpenditureDay.Focus();
                    return;
                }
                else
                {
                    day = DateTime.Now.Day;
                }
            }


            if (finacialedger.RegExpenditure(new DateTime(year, month, day), tbxExpenditureContent.Text, money))
            {
                MessageBox.Show("지출이 등록되었습니다.");

                lblPrintNowMoney.Text = (finacialedger.TotalIncome - finacialedger.TotalExpenditure).ToString();
                lblPrintTotalExpenditure.Text = finacialedger.TotalExpenditure.ToString();

                lbxExpenditures.Items.Add(finacialedger.getNowInfo());
                lbxAll.Items.Add(finacialedger.getNowInfo());

                if (finacialedger.IsBlack)
                {
                    lblPrintBlack.Text = "흑자";
                }
                else
                {
                    lblPrintBlack.Text = "적자";
                }

                try
                {
                    using (var fs = new FileStream(Path.Combine(PATH, FULLPATH), FileMode.Append))
                    {
                        using (var sw = new StreamWriter(fs))
                        {
                            sw.WriteLine($"{new DateTime(year, month, day).ToString("yyyyMMdd HHmmssfff")},{tbxExpenditureContent.Text},{money},1");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"지출 등록에 실패했습니다. 다시 시도해주세요.\r\n({ex.Message})");
                    return;
                }
            }
            else
            {
                MessageBox.Show("지출 등록에 실패했습니다. 다시 시도해주세요.");
            }
        }

        private void btnQuickIncome_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxQuickMoney.Text))
            {
                MessageBox.Show("넣으려는 돈이 비어있습니다.");
                tbxQuickMoney.Focus();
                return;
            }
            if (finacialedger == null)
            {
                MessageBox.Show("가계부를 먼저 만들어주세요.");
                return;
            }

            int money = 0;

            if (int.TryParse(tbxQuickMoney.Text, out money))
            {

            }
            else
            {
                MessageBox.Show("금액은 정수 숫자만 입력 가능합니다.");
                tbxQuickMoney.Focus();
                return;
            }
            DateTime now = DateTime.Now;

            if (finacialedger.RegIncome(now, tbxQuickContent.Text, money))
            {
                MessageBox.Show("수입이 등록되었습니다.");
                lblPrintNowMoney.Text = (finacialedger.TotalIncome - finacialedger.TotalExpenditure).ToString();
                lblPrintTotalIncome.Text = finacialedger.TotalIncome.ToString();

                lbxIncomes.Items.Add(finacialedger.getNowInfo());
                lbxAll.Items.Add(finacialedger.getNowInfo());

                if (finacialedger.IsBlack)
                {
                    lblPrintBlack.Text = "흑자";
                }
                else
                {
                    lblPrintBlack.Text = "적자";
                }

                try
                {
                    using (var fs = new FileStream(Path.Combine(PATH, FULLPATH), FileMode.Append))
                    {
                        using (var sw = new StreamWriter(fs))
                        {
                            sw.WriteLine($"{now.ToString("yyyyMMdd HHmmssfff")},{tbxQuickContent.Text},{money},0");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"수입 등록에 실패했습니다. 다시 시도해주세요.\r\n({ex.Message})");
                    return;
                }
            }
            else
            {
                MessageBox.Show("수입 등록에 실패했습니다. 다시 시도해주세요.");
            }
        }

        private void btnQuickExpenditure_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxQuickMoney.Text))
            {
                MessageBox.Show("넣으려는 돈이 비어있습니다.");
                tbxQuickMoney.Focus();
                return;
            }
            if (finacialedger == null)
            {
                MessageBox.Show("가계부를 먼저 만들어주세요.");
                return;
            }

            int money = 0;

            if (int.TryParse(tbxQuickMoney.Text, out money))
            {

            }
            else
            {
                MessageBox.Show("금액은 정수 숫자만 입력 가능합니다.");
                tbxQuickMoney.Focus();
                return;
            }

            DateTime now = DateTime.Now;

            if (finacialedger.RegExpenditure(tbxQuickContent.Text, money))
            {
                MessageBox.Show("지출이 등록되었습니다.");

                lblPrintNowMoney.Text = (finacialedger.TotalIncome - finacialedger.TotalExpenditure).ToString();
                lblPrintTotalExpenditure.Text = finacialedger.TotalExpenditure.ToString();

                lbxExpenditures.Items.Add(finacialedger.getNowInfo());
                lbxAll.Items.Add(finacialedger.getNowInfo());

                if (finacialedger.IsBlack)
                {
                    lblPrintBlack.Text = "흑자";
                }
                else
                {
                    lblPrintBlack.Text = "적자";
                }

                try
                {
                    using (var fs = new FileStream(Path.Combine(PATH, FULLPATH), FileMode.Append))
                    {
                        using (var sw = new StreamWriter(fs))
                        {
                            sw.WriteLine($"{now.ToString("yyyyMMdd HHmmssfff")},{tbxQuickContent.Text},{money},1");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"지출 등록에 실패했습니다. 다시 시도해주세요.\r\n({ex.Message})");
                    return;
                }
            }
            else
            {
                MessageBox.Show("지출 등록에 실패했습니다. 다시 시도해주세요.");
            }
        }
    }
}
