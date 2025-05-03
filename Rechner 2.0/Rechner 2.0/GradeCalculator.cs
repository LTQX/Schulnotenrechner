using System;
using System.Collections.Generic;

namespace Rechner2_0
{
    public class GradeCalculator
    {
        private Dictionary<string, Subject> subjects;
        private double penaltyPoints;

        public GradeCalculator()
        {
            subjects = new Dictionary<string, Subject>
            {
                { "Swir", new Subject("Swir") },
                { "Swfr", new Subject("Swfr") },
                { "Englisch", new Subject("Englisch") },
                { "Deutsch", new Subject("Deutsch") },
                { "Mathematik", new Subject("Mathematik") },
                { "Französisch", new Subject("Französisch") },
                { "Sport", new Subject("Sport") },
                { "Ila", new Subject("Ila") },
                { "Geschichte", new Subject("Geschichte") } // Neues Fach hinzugefügt
            };
            penaltyPoints = 0;
        }

        public void Run()
        {
            while (true)
            {
                foreach (var subject in subjects.Values)
                {
                    Console.Write($"Hast du Noten für {subject.Name}? (y/n): ");
                    string hasGrades = Console.ReadLine().ToLower();
                    if (hasGrades == "y")
                    {
                        AddGradesForSubject(subject);
                    }
                }

                GenerateReport();

                Console.Write("Möchtest du das Ergebnis als PDF speichern? (y/n): ");
                if (Console.ReadLine().ToLower() == "y")
                {
                    ReportSaver.SaveAsPdf(subjects, penaltyPoints, CalculateFinalAverage());
                }

                Console.Write("Möchtest du ein neues Durchschnitt berechnen? (y/n): ");
                if (Console.ReadLine().ToLower() != "y") break;
            }
        }

        private void AddGradesForSubject(Subject subject)
        {
            Console.WriteLine($"Gib die Noten und Gewichtungen für {subject.Name} ein (Format: Note:Gewichtung, z.B. 5.5:30,4.0:70): ");
            string input = Console.ReadLine();
            var gradeEntries = input.Split(',');

            foreach (var entry in gradeEntries)
            {
                var gradeWeight = entry.Split(':');
                if (gradeWeight.Length == 2 &&
                    double.TryParse(gradeWeight[0], out double grade) &&
                    double.TryParse(gradeWeight[1], out double weight) &&
                    grade >= 1 && grade <= 6 &&
                    weight >= 1 && weight <= 100)
                {
                    subject.AddGrade(grade, weight);
                    penaltyPoints += PenaltyCalculator.GetPenaltyPoints(grade);
                }
                else
                {
                    Console.WriteLine($"Ungültiger Eintrag: {entry}. Überspringe...");
                }
            }
        }

        private void GenerateReport()
        {
            Console.WriteLine("\nErgebnisse:");
            foreach (var subject in subjects.Values)
            {
                double subjectAverage = subject.CalculateWeightedAverage();
                Console.WriteLine($"{subject.Name}: {Math.Round(subjectAverage, 2):0.00}");
            }

            double finalAverage = CalculateFinalAverage();
            Console.WriteLine($"\nGesamtdurchschnitt: {Math.Round(finalAverage, 2):0.00}");
            Console.WriteLine($"Strafpunkte: {penaltyPoints:0.00}");

            if (penaltyPoints <= -3)
            {
                Console.WriteLine("Du bist provisorisch.");
            }
        }

        private double CalculateFinalAverage()
        {
            double total = 0;
            int totalGradesCount = 0;

            foreach (var subject in subjects)
            {
                double subjectAverage = subject.Value.CalculateWeightedAverage();

                if (subject.Key == "Ila")
                {
                    total += subjectAverage * 2;  // Ila doppelt zählen
                    totalGradesCount += 2;
                }
                else
                {
                    total += subjectAverage;
                    totalGradesCount++;
                }
            }

            return totalGradesCount > 0 ? total / totalGradesCount : 0;
        }
    }
}