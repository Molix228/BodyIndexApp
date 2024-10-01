using System.Drawing.Text;

namespace BodyIndexApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private double CalculateBMI(double weight, double height)
        {
            return weight / (height * height);
        }

        private string GetBMICategory(double bmi)
        {
            if (bmi < 18.5)
                return "Underweight";
            else if (bmi < 24.9)
                return "Normal";
            else if (bmi < 29.9)
                return "Overweight";
            else
                return "Extremely much fat";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double weight = Convert.ToDouble(txtWeight.Text);
                double heightCm = Convert.ToDouble(txtHeight.Text);
                double heightM = heightCm / 100;

                double bmi = CalculateBMI(weight, heightM);

                string category = GetBMICategory(bmi);

                textBox_Result.Text = $"BMI: {bmi:F2}\r\nStatus: {category}";

            }
            catch (FormatException)
            {
                MessageBox.Show("Incorrect data format. Try again!");
            }
        }

        private void txtWeight_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void txtHeight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
                e.SuppressKeyPress = true;
            }
        }
    }
}