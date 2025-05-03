namespace Rechner2_0
{
    public static class PenaltyCalculator
    {
        public static double GetPenaltyPoints(double grade)
        {
            if (grade == 3.5) return -0.5;
            if (grade == 3) return -1;
            if (grade == 2.5) return -1.5;
            if (grade == 2) return -2;
            if (grade == 1.5) return -2.5;
            if (grade == 1) return -3;
            return 0;
        }
    }
}