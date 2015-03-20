using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyCalculator
{
    public partial class myCalculator : Form
    {
        bool add = false;
        bool subtract = false;
        bool multiply = false;
        bool divide = false;
        bool calc = false;
        bool orwell = false;

        public myCalculator()
        {
            InitializeComponent();            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+"))
            {
                MessageBox.Show("Enter Only Numbers", "Not a Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }

            if (e.Control == true)
            {
                switch (e.KeyCode)
                {
                    case Keys.C:
                    case Keys.P:
                    case Keys.X:
                        e.Handled = true;
                        textBox1.SelectionLength = 0;
                        break;
                }
            }
        }

        private void button0_Click(object sender, EventArgs e)
        {
            checkCalculation();
            textBox1.Text = textBox1.Text + "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            checkCalculation();
            textBox1.Text = textBox1.Text + "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            checkCalculation();
            textBox1.Text = textBox1.Text + "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            checkCalculation();
            textBox1.Text = textBox1.Text + "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            checkCalculation();
            textBox1.Text = textBox1.Text + "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            checkCalculation();
            textBox1.Text = textBox1.Text + "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            checkCalculation();
            textBox1.Text = textBox1.Text + "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            checkCalculation();
            textBox1.Text = textBox1.Text + "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            checkCalculation();
            textBox1.Text = textBox1.Text + "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            checkCalculation();
            textBox1.Text = textBox1.Text + "9";
        }

        private void buttonPlusMinus_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Contains("-"))
            {
                textBox1.Text = textBox1.Text.Remove(0, 1);
            }
            else
            {
                textBox1.Text = "-" + textBox1.Text;
            }
        }

        private void buttonDecimal_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Contains("."))
            {
                checkCalculation();
                return;
            }
            else if(String.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Text = textBox1.Text + "0.";
            }
            else
            {
                textBox1.Text = textBox1.Text + ".";
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                return;
            }
            else
            {
                add = true;
                textBox1.Tag = textBox1.Text;
                textBox1.Text = "";
            }
        }

        private void buttonEquals_Click_1(object sender, EventArgs e)
        {
            calc = true;
            decimal decTag = 0;
            decimal decText;
            
            if (textBox1.Text == "")
            {
                textBox1.Text = "0";
            }
            decText = Convert.ToDecimal(textBox1.Text);
            if (!String.IsNullOrEmpty(textBox1.Tag.ToString()))
            {
                decTag = Convert.ToDecimal(textBox1.Tag.ToString());
            }


            if (textBox1.Text == "1984") //Easter Egg code for Orwellian joke
            {
                if (orwell == false)
                {
                    orwell = true;
                }
                else
                {
                    orwell = false;
                }
                textBox1.Text = "";
            }
            else if (orwell)
            {
                if ("2" == textBox1.Tag.ToString() && decText == 2)
                {
                    decText = 3;
                }
                else if (textBox1.Text == "1984")
                {
                    orwell = false;
                }
                else
                {
                    Random rnd = new Random();
                    int george = rnd.Next(1, 11);
                    int eightyFour = Convert.ToInt32(textBox1.Text) + george;
                    textBox1.Text = eightyFour.ToString();
                }
            }
            if (multiply)
            {
                decimal mult = decText * decTag;
                textBox1.Text = mult.ToString();
                multiply = false;
            }
            if (divide)
            {
                decimal div = decTag/decText;
                textBox1.Text = div.ToString();
                divide = false;
            }
            if (add)
            {
                decimal sum = decTag + decText;
                textBox1.Text = sum.ToString();
                add = false;
            }
            if (subtract)
            {
                decimal subt = decTag - decText;
                textBox1.Text = subt.ToString();
                subtract = false;
            }
            textBox1.Tag = "";
            
        }

        private void buttonSubtract_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                return;
            else
            {
                subtract = true;
                textBox1.Tag = textBox1.Text;
                textBox1.Text = "";
            }
        }

        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                return;
            else
            {
                multiply = true;
                textBox1.Tag = textBox1.Text;
                textBox1.Text = "";
            }
        }

        private void buttonDivide_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                return;
            else
            {
                divide = true;
                textBox1.Tag = textBox1.Text;
                textBox1.Text = "";
            }
        }
        //All trig functions in radians. Need to add a rad/degree button and possible trig functions in degrees
        private void buttonSine_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                return;
            else
            {
                double sin = Math.Sin(Convert.ToDouble(textBox1.Text));
                textBox1.Text = sin.ToString();
            }
        }
 
        private void buttonCosine_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                return;
            else
            {
                double cosine = Math.Cos(Convert.ToDouble(textBox1.Text));
                textBox1.Text = cosine.ToString();
            }
        }

        private void buttonTangent_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                return;
            else
            {
                double tangent = Math.Tan(Convert.ToDouble(textBox1.Text));
                textBox1.Text = tangent.ToString();
            }
        }

        private void buttonCotangent_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                return;
            else
            {
                double cotangent = Convert.ToDouble(textBox1.Text);
                cotangent = (1 / (Math.Tan(cotangent)));
                textBox1.Text = cotangent.ToString();
            }
        }

        private void buttonSquare_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                return;
            else
            {
                decimal square = Convert.ToDecimal(textBox1.Text);
                square *= square;
                textBox1.Text = square.ToString();
            }
        }

        private void buttonSquareRoot_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                return;
            else
            {
                double sqrt = Math.Sqrt(Convert.ToDouble(textBox1.Text));
                textBox1.Text = sqrt.ToString();
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Tag = "";
            add = false;
            subtract = false;
            multiply = false;
            divide = false;
            calc = false;
        }
        private void checkCalculation()
        {
            if (calc)
            {
                textBox1.Text = "";
                calc = false;
            }
        }

    }
}
