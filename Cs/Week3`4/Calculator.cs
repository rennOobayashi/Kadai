using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week03Homework
{
    public partial class FormMain: Form
    {
        int cnt = 1;
        int calType = 0;
        bool isEnd = false;
        bool enterNum = false;

        public FormMain()
        {
            InitializeComponent();
            
            lblNumbers.Text = "0";
        }

        private void btnNum_Click(object sender, EventArgs e)
        {
            if (isEnd)
            {
                lblNumbers.Text = "0";
                lblExpression.Text = "";
                isEnd = false;
            }

            int num = 0;

            if (lblNumbers.Text == "0")
            {
                num = int.Parse(((Button)sender).Text);

                lblNumbers.Text = num.ToString();

            }
            else
            {
                num = int.Parse(((Button)sender).Text);
                lblNumbers.Text += num;
            }

            enterNum = true;
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            String sign = ((Button)sender).Text;

            if (enterNum)
            {

                if (sign == "+" && !(calType != 0 && calType != 1))
                {
                    calType = 1;
                    ++cnt;
                }
                else if (sign == "-" && !(calType != 0 && calType != 2))
                {
                    calType = 2;
                    ++cnt;
                }
                else if (sign == "*" && !(calType != 0 && calType != 3))
                {
                    calType = 3;
                    ++cnt;
                }
                else if (sign == "/" && !(calType != 0 && calType != 4))
                {
                    calType = 4;
                    ++cnt;
                }
                else
                {
                    MessageBox.Show("복합연산은 구현하지 못하였습니다!");
                    return;
                }

                lblExpression.Text += lblNumbers.Text;
                lblNumbers.Text = "0";

                lblExpression.Text += sign;

                enterNum = false;
            }
            else
            {
                MessageBox.Show("숫자를 먼저 입력해주세요!");
            }
        }

        private void btnCal_Click(object sender, EventArgs e)
        {
            if (enterNum)
            {
                string[] numbers = new string[cnt];
                double result = 0;

                lblExpression.Text += lblNumbers.Text;

                switch (calType)
                {
                    case 1:
                        numbers = lblExpression.Text.Split('+');

                        result = int.Parse(numbers[0]);

                        for (int i = 1; i < cnt; ++i)
                        {
                            result += int.Parse(numbers[i]);
                        }

                        break;
                    case 2:
                        numbers = lblExpression.Text.Split('-');

                        result = int.Parse(numbers[0]);

                        for (int i = 1; i < cnt; ++i)
                        {
                            result -= int.Parse(numbers[i]);
                        }

                        break;
                    case 3:
                        numbers = lblExpression.Text.Split('*');

                        result = int.Parse(numbers[0]);

                        for (int i = 1; i < cnt; ++i)
                        {
                            result *= int.Parse(numbers[i]);
                        }

                        break;
                    case 4:
                        numbers = lblExpression.Text.Split('/');

                        result = int.Parse(numbers[0]);

                        for (int i = 0; i < cnt; ++i)
                        {
                            if (int.Parse(numbers[i]) == 0)
                            {
                                MessageBox.Show("0으로 나눌 수는 없습니다!");
                                lblExpression.Text += "=error";
                                lblNumbers.Text = ":(";

                                cnt = 1;
                                calType = 0;
                                isEnd = true;

                                return;
                            }

                            if (i == 0)
                            {
                                continue;
                            }

                            result /= float.Parse(numbers[i]);
                        }

                        break;
                    default:
                        result = int.Parse(lblExpression.Text);
                        break;
                }

                lblExpression.Text += "=" + result;

                lblNumbers.Text = result.ToString();

                cnt = 1;

                calType = 0;

                isEnd = true;

            }
            else
            {
                MessageBox.Show("숫자를 먼저 입력해주세요!");
            }
        }

    }
}
