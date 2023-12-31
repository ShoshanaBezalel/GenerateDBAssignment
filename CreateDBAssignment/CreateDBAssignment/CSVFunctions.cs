using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace CreateDBAssignment
{
    internal class CSVFunctions
    {
        public static void GenerateCSVFile(string filePath, int rowCount)
        {
            Random random = new Random();
            List<string> lines = new List<string> { "FirstName, LastName, Age, Weight, Gender" };

            for (int i = 0; i < rowCount; i++)
            {
                string firstName = GetRadnomFName();
                string lastName = GetRadnomLName();
                int age = random.Next(18, 71);
                double weight = random.Next(100, 300) / 2.20462;
                string gender = random.Next(2) == 0 ? "Male" : "Female";

                lines.Add($"{firstName},{lastName},{age},{weight:F2},{gender}");
            }

            File.WriteAllLines(filePath, lines);
        }

        public static List<Person> ReadCSVFile(string filePath)
        {            var peopleData = new List<Person>();

            var lines = File.ReadLines(filePath).Skip(1);

            foreach (var line in lines)
            {
                var values = line.Split(',');
                var person = new Person
                {
                    FirstName = values[0],
                    LastName = values[1],
                    Age = int.Parse(values[2]),
                    Weight = double.Parse(values[3], CultureInfo.InvariantCulture),
                    Gender = values[4],
                };

                peopleData.Add(person);
            }

            return peopleData;
        }

        private static string GetRadnomLName()
        {
            string[] firstNames = { "John", "Jane", "Michael", "Emily", "David", "Emma", "Christopher", "Olivia", "Daniel", "Sophia" };
            return firstNames[new Random().Next(firstNames.Length)];
        }

        private static string GetRadnomFName()
        {
            string[] lastNames = { "Smith", "Johnson", "Williams", "Brown", "Jones", "Miller", "Davis", "García", "Rodriguez", "Martinez" };
            return lastNames[new Random().Next(lastNames.Length)];
        }
    }

}

