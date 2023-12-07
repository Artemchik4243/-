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
        [AllureTest("Add")]
        [AllureSeverity(SeverityLevel.Normal)]
        [AllureOwner("John Doe")]
        public double Add(double a, double b)
        {
            return a + b;
        }

        // Другие методы калькулятора
        public double Subtract(double a, double b)
        {
            return a - b;
        }

        public double Multiply(double a, double b)
        {
            return a * b;
        }

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

        private void Calculate(object sender, EventArgs e)
        {
            // Получаем данные из формы и передаем их в модель
            double a = view.GetValueA();
            double b = view.GetValueB();

            // Выполняем вычисления
            //double result = model.Add(a, b);

            // Отправляем результат в форму
            //view.DisplayResult(result);
            // Используйте атрибут Step для аннотации кода, который нужно отобразить в отчете Allure
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                double result = model.Add(a, b);

                // Отправляем результат в форму
                view.DisplayResult(result);

                // Добавляем атрибуты Allure
                AllureLifecycle.Instance.AddAttachment("Input Values", "text/plain", $"{a}, {b}");
                AllureLifecycle.Instance.AddAttachment("Calculation Result", "text/plain", result.ToString());
            }, "Performing Calculation");
        }
    }
}
