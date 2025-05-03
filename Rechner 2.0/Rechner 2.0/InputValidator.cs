using System;

namespace Rechner2_0
{
    public static class InputValidator
    {
        public static double GetValidDouble(double min, double max)
        {
            double input;
            while (!double.TryParse(Console.ReadLine(), out input) || input < min || input > max)
            {
                Console.WriteLine($"Ungültige Eingabe. Bitte gib eine Zahl zwischen {min} und {max} ein.");
            }
            return input;
        }
    }
}