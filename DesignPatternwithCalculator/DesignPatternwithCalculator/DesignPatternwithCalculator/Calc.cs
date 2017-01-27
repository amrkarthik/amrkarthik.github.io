using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesignPatternwithCalculator
{
    public partial class Calc : Form
    {
        public double Operand1 { get; set; }
        public double Operand2 { get; set; }
        public OperatorSym SelectedOperator { get; set; }

        public Calc()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            Operand1 = 0;
            Operand2 = 0;
            SelectedOperator = OperatorSym.Equal;
            txtVal.Text = string.Empty;
        }

        private void btnSQR_Click(object sender, EventArgs e)
        {
            SelectedOperator = OperatorSym.Square;
        }

        private void btnCLR_Click(object sender, EventArgs e)
        {
            Init();
        }

        private void btnDEL_Click(object sender, EventArgs e)
        {
            txtVal.Text = txtVal.Text.Remove(txtVal.Text.Length - 1);
        }

        private void btnSymDIV_Click(object sender, EventArgs e)
        {
            Calculate("/");
        }

        private void Calculate(string symbol)
        {
             
        }

        private void btnNum7_Click(object sender, EventArgs e)
        {

        }

        private void btnNum8_Click(object sender, EventArgs e)
        {

        }

        private void btnNum9_Click(object sender, EventArgs e)
        {

        }

        private void btnSymMUL_Click(object sender, EventArgs e)
        {

        }

        private void btnNum4_Click(object sender, EventArgs e)
        {

        }

        private void btnNum5_Click(object sender, EventArgs e)
        {

        }

        private void btnNum6_Click(object sender, EventArgs e)
        {

        }

        private void btnSymSub_Click(object sender, EventArgs e)
        {

        }

        private void btnNum1_Click(object sender, EventArgs e)
        {

        }

        private void btnNum2_Click(object sender, EventArgs e)
        {

        }

        private void btnNum3_Click(object sender, EventArgs e)
        {

        }

        private void btnSymADD_Click(object sender, EventArgs e)
        {

        }

        private void btnNum0_Click(object sender, EventArgs e)
        {

        }

        private void btnSymDOT_Click(object sender, EventArgs e)
        {

        }

        private void btnSymEQ_Click(object sender, EventArgs e)
        {

        }
    }
}
