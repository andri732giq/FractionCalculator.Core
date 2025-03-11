using System;

namespace FractionCalculator.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Калькулятор дробів");
            while (true)
            {
                try
                {
                    Console.WriteLine("Введіть перший дріб (наприклад, 1/2):");
                    var fraction1 = ParseFraction(Console.ReadLine());

                    Console.WriteLine("Введіть другий дріб (наприклад, 3/4):");
                    var fraction2 = ParseFraction(Console.ReadLine());

                    Console.WriteLine("Виберіть операцію (+, -, *, /):");
                    string operation = Console.ReadLine();

                    Fraction result;
                    switch (operation)
                    {
                        case "+":
                            result = Fraction.Add(fraction1, fraction2);
                            break;
                        case "-":
                            result = Fraction.Subtract(fraction1, fraction2);
                            break;
                        case "*":
                            result = Fraction.Multiply(fraction1, fraction2);
                            break;
                        case "/":
                            result = Fraction.Divide(fraction1, fraction2);
                            break;
                        default:
                            throw new ArgumentException("Невірна операція.");
                    }

                    Console.WriteLine($"Результат: {result}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Помилка: {ex.Message}");
                }

                Console.WriteLine("Продовжити? (y/n)");
                if (Console.ReadLine().ToLower() != "y") break;
            }
        }

        static Fraction ParseFraction(string input)
        {
            var parts = input.Split('/');
            if (parts.Length != 2 || !int.TryParse(parts[0], out int num) || !int.TryParse(parts[1], out int den))
                throw new ArgumentException("Невірний формат дробу.");
            return new Fraction(num, den);
        }
    }
}