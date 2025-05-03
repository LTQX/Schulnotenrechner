using System.Collections.Generic;

namespace Rechner2_0
{
    public class Subject
    {
        public string Name { get; }
        private List<Grade> grades;

        public Subject(string name)
        {
            Name = name;
            grades = new List<Grade>();
        }

        public void AddGrade(double value, double weight)
        {
            grades.Add(new Grade(value, weight));
        }

        public double CalculateWeightedAverage()
        {
            double weightedSum = 0;
            double totalWeight = 0;

            foreach (var grade in grades)
            {
                weightedSum += grade.Value * grade.Weight;
                totalWeight += grade.Weight;
            }

            return totalWeight > 0 ? weightedSum / totalWeight : 0;
        }
    }
}