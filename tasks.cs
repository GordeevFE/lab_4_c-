using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

public static class Tasks
{
    // Задача 1
    public static List<int> RemoveAfterE(List<int> list, int E)
    {
        if (list == null || list.Count == 0)
            return new List<int>();

        List<int> result = new List<int>();
        int i = 0;

        while (i < list.Count)
        {
            result.Add(list[i]);

            if (list[i] == E && (i + 1 < list.Count) && list[i + 1] != E)
            {
                i++;
            }

            i++;
        }

        return result;
    }

    // Задача 2
    public static bool RavnElem(List<int> list)
    {
        if (list == null || list.Count < 2)
            return false;

        for (int i = 0; i < list.Count; i++)
        {
            int nextIndex = (i + 1) % list.Count;
            if (list[i] == list[nextIndex])
            {
                return true;
            }
        }

        return false;
    }

    // Задача 3
    public static void AnalyzeCountries(List<string> countries, Dictionary<string, List<string>> countryVisitors, List<string> allTourists)
    {
        var visitedByAll = new List<string>();
        var visitedBySome = new List<string>();
        var visitedByNone = new List<string>();

        foreach (var country in countries)
        {
            if (countryVisitors.ContainsKey(country))
            {
                var visitors = countryVisitors[country];

                bool allVisited = visitors.Count == allTourists.Count && visitors.All(tourist => allTourists.Contains(tourist));

                if (allVisited)
                {
                    visitedByAll.Add(country);
                }
                else if (visitors.Count > 0)
                {
                    visitedBySome.Add(country);
                }
                else
                {
                    visitedByNone.Add(country);
                }
            }
            else
            {
                visitedByNone.Add(country);
            }
        }

        Console.WriteLine("Посетили все туристы:");
        PrintList(visitedByAll);

        Console.WriteLine("\nПосетили некоторые туристы:");
        PrintList(visitedBySome);

        Console.WriteLine("\nНе посетил никто:");
        PrintList(visitedByNone);
    }

    // Задача 4
    public static void ConsonantsLetters(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Файл не найден!");
            return;
        }

        string text = File.ReadAllText(filePath, Encoding.UTF8).ToLower();
        char[] deafConsonants = { 'п', 'ф', 'к', 'т', 'ш', 'с', 'х', 'ц', 'ч', 'щ' };

        string[] words = text.Split(new[] { ' ', ',', '.', '!', '?', ';', ':', '\n', '\r', '\t' },
                                  StringSplitOptions.RemoveEmptyEntries);

        Dictionary<char, int> consonantCount = new Dictionary<char, int>();
        foreach (char consonant in deafConsonants)
        {
            consonantCount[consonant] = 0;
        }

        foreach (string word in words)
        {
            var wordConsonants = word.Where(c => deafConsonants.Contains(c)).Distinct();
            foreach (char consonant in wordConsonants)
            {
                consonantCount[consonant]++;
            }
        }

        var result = consonantCount.Where(pair => pair.Value == 1)
                                  .Select(pair => pair.Key)
                                  .OrderBy(c => c)
                                  .ToList();

        Console.WriteLine("Глухие согласные в одном слове:");
        foreach (char consonant in result)
        {
            Console.WriteLine(consonant);
        }
    }

    // Задача 5
    public static void Abiturients(string[] inputLines)
    {
        if (inputLines.Length == 0)
        {
            Console.WriteLine("Нет данных");
            return;
        }

        if (!int.TryParse(inputLines[0], out int n) || n <= 0 || n > 500)
        {
            Console.WriteLine("Неверное количество абитуриентов");
            return;
        }

        List<Applicant> failed = new List<Applicant>();

        for (int i = 1; i <= n && i < inputLines.Length; i++)
        {
            string[] parts = inputLines[i].Split(' ');
            if (parts.Length >= 4)
            {
                string lastName = parts[0];
                string firstName = parts[1];

                if (int.TryParse(parts[2], out int score1) && int.TryParse(parts[3], out int score2))
                {
                    if (score1 < 30 || score2 < 30)
                    {
                        failed.Add(new Applicant(lastName, firstName, score1, score2));
                    }
                }
            }
        }

        var sortedFailed = failed.OrderBy(a => a.LastName).ToList();

        Console.WriteLine("Не допущенные абитуриенты:");
        foreach (var applicant in sortedFailed)
        {
            Console.WriteLine($"{applicant.LastName} {applicant.FirstName}");
        }
    }

    private static void PrintList(List<string> list)
    {
        if (list.Count == 0)
        {
            Console.WriteLine("  (пусто)");
        }
        else
        {
            foreach (string item in list)
            {
                Console.WriteLine($"  - {item}");
            }
        }
    }

    private class Applicant
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int Score1 { get; set; }
        public int Score2 { get; set; }

        public Applicant(string lastName, string firstName, int score1, int score2)
        {
            LastName = lastName;
            FirstName = firstName;
            Score1 = score1;
            Score2 = score2;
        }
    }
}
