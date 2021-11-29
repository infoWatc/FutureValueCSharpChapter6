/**********************************
 * Gu3
 * C# Object OrProgramming
 * exercise 6-1 & 6-2
 ***********************************/

using System;
using System.Windows.Forms;

namespace FutureValue
{
    public partial class frmFutureValue : Form
    {
        public frmFutureValue()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            decimal monthlyInvestment, yearlyInterestRate;
            int years;
            ConvertStringToDecimal(out monthlyInvestment, out yearlyInterestRate, out years);

            int months = years * 12;
            decimal monthlyInterestRate = yearlyInterestRate / 12 / 100;

            decimal futureValue = this.CalculateFutureValue(monthlyInvestment, months, monthlyInterestRate);

            txtFutureValue.Text = futureValue.ToString("c");
            txtMonthlyInvestment.Focus();


        }

        private void ConvertStringToDecimal(out decimal monthlyInvestment, out decimal yearlyInterestRate, out int years)
        {
            monthlyInvestment = Convert.ToDecimal(txtMonthlyInvestment.Text);
            yearlyInterestRate = Convert.ToDecimal(txtYearlyInterestRate.Text);
            years = Convert.ToInt32(txtYears.Text);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        // Created Method using <enter plus . and extracted local, then moved to a mehtod.
        private decimal CalculateFutureValue(decimal monthlyInvestment, int months, decimal monthlyInterestRate)
        {
            decimal futureValue = 0m;
            for (int i = 0; i < months; i++)
            {
                futureValue = (futureValue + monthlyInvestment)
                            * (1 + monthlyInterestRate);
            }

            return futureValue;
        }


        private void ClearFutureValue(object sender, EventArgs e)
        {
            txtFutureValue.Text = "";
        }

        private void ClearFutureValue_DoubleClick(object sender, EventArgs e)
        {
            txtFutureValue.Text = string.Empty;
            txtYearlyInterestRate.Text = string.Empty;
            txtMonthlyInvestment.Text = string.Empty;
            txtYears.Text = string.Empty;
        }

        private void txtMonthlyInvestment_MouseHover(object sender, EventArgs e)
        {
            txtMonthlyInvestment.Text = string.Empty;
        }

        private void txtYearlyInterestRate_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtYearlyInterestRate.Text = "12";
        }
    }
}
