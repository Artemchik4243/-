using NUnit.Framework;
namespace Artem
{
    public partial class Form1 : Form
{
        public event EventHandler Calculate;
        public Form1()
        {
            InitializeComponent();
            button1.Click += (sender, e) => Calculate?.Invoke(this, EventArgs.Empty);
        }
        public double GetValueA()
        {
            // Логика получения значения из элемента управления
            return double.Parse(textBox1.Text);
        }

        public double GetValueB()
        {
            // Логика получения значения из элемента управления
            return double.Parse(textBox2.Text);
        }

        public void DisplayResult(double result)
        {
            // Логика отображения результата в элементе управления
            label2.Text = result.ToString();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(textBox1.Text);
            double b = a * (Math.PI / 180.0);
            double c = Math.Sin(b);
            //label2.Text = c.ToString();
            DisplayResult(c);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(textBox1.Text);
            double b = a * (Math.PI / 180.0);
            double c = Math.Cos(b);
            //label2.Text = c.ToString();
            DisplayResult(c);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(textBox1.Text);
            double b = a * (Math.PI / 180.0);
            double c = Math.Tan(b);
            //label2.Text = c.ToString();
            DisplayResult(c);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(textBox1.Text);
            double b = Convert.ToDouble(textBox2.Text);
            double c = a + b;
            //label2.Text = c.ToString();
            DisplayResult(c);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(textBox1.Text);
            double b = Convert.ToDouble(textBox2.Text);
            double c = a - b;
            //label2.Text = c.ToString();
            DisplayResult(c);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(textBox1.Text);
            double b = Convert.ToDouble(textBox2.Text);
            double c = a * b;
            //label2.Text = c.ToString();
            DisplayResult(c);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(textBox1.Text);
            double b = Convert.ToDouble(textBox2.Text);
            if (b == 0)
            {
                throw new ArgumentException("На ноль делить нельзя");
            }
            double c = a / b;
            //label2.Text = c.ToString();
            DisplayResult(c);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(textBox1.Text);
            double b = Math.Log(a);
            //label2.Text = b.ToString();
            DisplayResult(b);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(textBox1.Text);
            double b = Math.Exp(a);
            //label2.Text = b.ToString();
            DisplayResult(b);
        }
    }
}