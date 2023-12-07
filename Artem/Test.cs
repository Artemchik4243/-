using Allure.Net.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artem
{
    [TestFixture]
    [AllureNUnit]
    public class CalculatorModel
    {
        [Test]
        [AllureSeverity(SeverityLevel.Normal)]
        [AllureOwner("John Doe")]
        public double Add(double a, double b) {return a + b;}
        public double Subtract(double a, double b) {return a - b;}

        public double Multiply(double a, double b) {return a * b;}

        public double Divide(double a, double b)
        {
            if (b == 0)
            {
                throw new ArgumentException("На ноль делить нельзя");
            }
            return (double)a / b;
        }
    }
    public class CalculatorPresenter
    {
        private readonly Form1 view;
        private readonly CalculatorModel model;

        public CalculatorPresenter(Form1 view, CalculatorModel model)
        {
            this.view = view;
            this.model = model;

            this.view.Calculate += Calculate;
        }
        [AllureStep("Performing Calculation")]
        private void Calculate(object sender, EventArgs e)
        {
            double a = view.GetValueA();
            double b = view.GetValueB();
            double result = model.Add(a, b);

            view.DisplayResult(result);
            AllureLifecycle.Instance.AddAttachment("Input Values", "text/plain", $"{a}, {b}");
            AllureLifecycle.Instance.AddAttachment("Calculation Result", "text/plain", result.ToString());

        }
    }
}
