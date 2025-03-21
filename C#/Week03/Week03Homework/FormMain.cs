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
        }

        private void btnNum0_Click(object sender, EventArgs e)
        {
            if (!isEnd)
            {
                lblExpression.Text += "0";
                enterNum = true;
            }
            else
            {
                lblExpression.Text = "0";
                enterNum = true;
                isEnd = false;
            }
        }

        private void btnNum1_Click(object sender, EventArgs e)
        {
            if (!isEnd)
            {
                lblExpression.Text += "1";
                enterNum = true;
            }
            else
            {
                lblExpression.Text = "1";
                enterNum = true;
                isEnd = false;
            }
        }

        private void btnNum2_Click(object sender, EventArgs e)
        {
            if (!isEnd)
            {
                lblExpression.Text += "2";
                enterNum = true;
            }
            else
            {
                lblExpression.Text = "2";
                enterNum = true;
                isEnd = false;
            }
        }

        private void btnNum3_Click(object sender, EventArgs e)
        {
            if (!isEnd)
            {
                lblExpression.Text += "3";
                enterNum = true;
            }
            else
            {
                lblExpression.Text = "3";
                enterNum = true;
                isEnd = false;
            }
        }

        private void btnNum4_Click(object sender, EventArgs e)
        {
            if (!isEnd)
            {
                lblExpression.Text += "4";
                enterNum = true;
            }
            else
            {
                lblExpression.Text = "4";
                enterNum = true;
                isEnd = false;
            }
        }

        private void btnNum5_Click(object sender, EventArgs e)
        {
            if (!isEnd)
            {
                lblExpression.Text += "5";
                enterNum = true;
            }
            else
            {
                lblExpression.Text = "5";
                enterNum = true;
                isEnd = false;
            }
        }

        private void btnNum6_Click(object sender, EventArgs e)
        {
            if (!isEnd)
            {
                lblExpression.Text += "6";
                enterNum = true;
            }
            else
            {
                lblExpression.Text = "6";
                enterNum = true;
                isEnd = false;
            }
        }

        private void btnNum7_Click(object sender, EventArgs e)
        {
            if (!isEnd)
            {
                lblExpression.Text += "7";
                enterNum = true;
            }
            else
            {
                lblExpression.Text = "7";
                enterNum = true;
                isEnd = false;
            }
        }

        private void btnNum8_Click(object sender, EventArgs e)
        {
            if (!isEnd)
            {
                lblExpression.Text += "8";
                enterNum = true;
            }
            else
            {
                lblExpression.Text = "8";
                enterNum = true;
                isEnd = false;
            }
        }

        private void btnNum9_Click(object sender, EventArgs e)
        {
            if (!isEnd)
            {
                lblExpression.Text += "9";
                enterNum = true;
            }
            else
            {
                lblExpression.Text = "9";
                enterNum = true;
                isEnd = false;
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (enterNum  && !(calType != 0 && calType != 1))
            {
                calType = 1;
                lblExpression.Text += "+";

                ++cnt;
                enterNum = false;
            }
            else if ((calType != 0 && calType != 1))
            {
                MessageBox.Show("복합연산은 구현하지 못하였습니다!");
            }
            else
            {
                MessageBox.Show("숫자를 먼저 입력해주세요!");
            }
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            if (enterNum && !(calType != 0 && calType != 2))
            {
                calType = 2;
                lblExpression.Text += "-";

                ++cnt;
                enterNum = false;
            }
            else if ((calType != 0 && calType != 2))
            {
                MessageBox.Show("복합연산은 구현하지 못하였습니다!");
            }
            else
            {
                MessageBox.Show("숫자를 먼저 입력해주세요!");
            }
        }

        private void btnMul_Click(object sender, EventArgs e)
        {

            if (enterNum && !(calType != 0 && calType != 3))
            {
                calType = 3;
                lblExpression.Text += "*";

                ++cnt;
                enterNum = false;
            }
            else if ((calType != 0 && calType != 3))
            {
                MessageBox.Show("복합연산은 구현하지 못하였습니다!");
            }
            else
            {
                MessageBox.Show("숫자를 먼저 입력해주세요!");
            }
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            if (enterNum && !(calType != 0 && calType != 4))
            {
                calType = 4;
                lblExpression.Text += "/";

                ++cnt;
                enterNum = false;
            }
            else if ((calType != 0 && calType != 4))
            {
                MessageBox.Show("복합연산은 구현하지 못하였습니다!");
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

                switch (calType)
                {
                    case 1:
                        numbers = lblExpression.Text.Split('+');
                        lblNumbers.Text = numbers[0];

                        for (int i = 0; i < cnt; i++)
                        {
                            result += int.Parse(numbers[i]);
                        }

                        break;
                    case 2:
                        numbers = lblExpression.Text.Split('-');

                        result = int.Parse(numbers[0]);

                        for (int i = 1; i < cnt; i++)
                        {
                            result -= int.Parse(numbers[i]);
                        }

                        break;
                    case 3:
                        numbers = lblExpression.Text.Split('*');

                        result = int.Parse(numbers[0]);

                        for (int i = 1; i < cnt; i++)
                        {
                            result *= int.Parse(numbers[i]);
                        }

                        break;
                    case 4:
                        numbers = lblExpression.Text.Split('/');

                        result = int.Parse(numbers[0]);

                        for (int i = 1; i < cnt; i++)
                        {
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
