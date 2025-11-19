using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main()
    {
        Console.WriteLine("Тестирование задач 1-5\n");

        // Тест задачи 1
        Console.WriteLine("Задача 1: Удаление элемента после E");
        var list1 = new List<int> { 1, 2, 3, 2, 4, 5, 2, 6 };
        var result1 = Tasks.RemoveAfterE(list1, 2);
        Console.WriteLine($"Было: [{string.Join(", ", list1)}]");
        Console.WriteLine($"Стало: [{string.Join(", ", result1)}]");

        // Тест задачи 2
        Console.WriteLine("\nЗадача 2: Равные соседи по кругу");
        var list2 = new List<int> { 1, 2, 3, 4, 1 };
        var result2 = Tasks.RavnElem(list2);
        Console.WriteLine($"Список: [{string.Join(", ", list2)}]");
        Console.WriteLine($"Есть равные соседи: {result2}");

        // Тест задачи 3
        Console.WriteLine("\nЗадача 3: Анализ посещения стран");
        var countries = new List<string> { "Франция", "Италия", "Испания", "Германия" };
        var visitors = new Dictionary<string, List<string>>
        {
            ["Франция"] = new List<string> { "Иван", "Мария", "Петр" },
            ["Италия"] = new List<string> { "Иван", "Мария" },
            ["Испания"] = new List<string> { "Петр" }
        };
        var tourists = new List<string> { "Иван", "Мария", "Петр" };
        Tasks.AnalyzeCountries(countries, visitors, tourists);

        // Тест задачи 4
        Console.WriteLine("\nЗадача 4: Глухие согласные");
        string testText = "поп кот ток шум сон час щит";
        System.IO.File.WriteAllText("test.txt", testText, Encoding.UTF8);
        Tasks.ConsonantsLetters("test.txt");

        // Тест задачи 5
        Console.WriteLine("\nЗадача 5: Абитуриенты");
        string[] testData = {
            "3",
            "Ветров Роман 68 59",
            "Петров Иван 25 45",
            "Сидорова Анна 45 28"
        };
        Tasks.Abiturients(testData);
    }
}
