namespace Rechner2_0
{
    public class Grade
    {
        public double Value { get; }
        public double Weight { get; }

        public Grade(double value, double weight)
        {
            Value = value;
            Weight = weight / 100.0; 
        }
    }
}