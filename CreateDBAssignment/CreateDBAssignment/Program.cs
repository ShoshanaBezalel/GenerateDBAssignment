using CreateDBAssignment;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Program
{
    static void Main()
    {
        string csvFilePath = "people_data.csv";
        CSVFunctions.GenerateCSVFile(csvFilePath, 1000);

        var peopleData = CSVFunctions.ReadCSVFile(csvFilePath);

        double averageAge = peopleData.Select(p => p.Age).Average();
        Console.WriteLine($"Average age of all people: {averageAge:F2} years.");

        int peopleInWeightRange = peopleData.Count(p => p.Weight > 120 && p.Weight <= 140);
        Console.WriteLine($"Total Number of People Weighing between 120lbs and 140lbs: {peopleInWeightRange}");

        double averageAgeInWeightRange = peopleData
            .Where(p => p.Weight >= 120 && p.Weight <= 140)
            .Select(p => p.Weight)
            .Average();

        Console.WriteLine($"Average Age of People Weighing between 120lbs and 140lbs: {averageAgeInWeightRange:F2} years");

    }
}



