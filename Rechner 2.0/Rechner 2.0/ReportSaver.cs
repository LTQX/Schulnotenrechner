using System;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Collections.Generic;

namespace Rechner2_0
{
    public static class ReportSaver
    {
        public static void SaveAsPdf(Dictionary<string, Subject> subjects, double penaltyPoints, double finalAverage)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string pdfFilePath = Path.Combine(desktopPath, "GradesReport.pdf");

            Document doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(pdfFilePath, FileMode.Create));
            doc.Open();

            doc.Add(new Paragraph("Notenbericht"));
            doc.Add(new Paragraph("\nFächer und Durchschnitte:"));

            foreach (var subject in subjects.Values)
            {
                double subjectAverage = subject.CalculateWeightedAverage();
                doc.Add(new Paragraph($"{subject.Name}: {Math.Round(subjectAverage, 2):0.00}"));
            }

            doc.Add(new Paragraph($"\nGesamtdurchschnitt: {Math.Round(finalAverage, 2):0.00}"));
            doc.Add(new Paragraph($"Strafpunkte: {penaltyPoints:0.00}"));

            if (penaltyPoints <= -3)
            {
                doc.Add(new Paragraph("Du bist provisorisch."));
            }

            doc.Close();
            Console.WriteLine($"PDF gespeichert unter: {pdfFilePath}");
        }
    }
}