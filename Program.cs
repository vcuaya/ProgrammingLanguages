using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProgrammingLanguages
{
    class Program
    {
        static void Main()
        {
            List<Language> languages = File.ReadAllLines("languages.tsv")
              .Skip(1)
              .Select(line => Language.FromTsv(line))
              .ToList();

            // Output: All data
            PrettyPrintAll(languages);

            // Output: taking Year, Name and ChiefDeveloper
            var queryResult = languages.Select(l => $"{l.Year}, {l.Name}, {l.ChiefDeveloper}");
            PrintAll(queryResult);

            // Output: searching for C# language
            var queryResult1 = languages.Where(l => l.Name.Contains("C#"));
            PrettyPrintAll(queryResult1);

            // Output: searching for Microsoft Languages
            var queryResult2 = languages.Where(l => l.ChiefDeveloper.Contains("Microsoft"));
            PrettyPrintAll(queryResult2);

            // Output: searching for Predecessor of Lisp
            var queryResult3 = languages.Where(l => l.Predecessors.Contains("Lisp"));
            PrettyPrintAll(queryResult3);

            // Output: searching for Languages whit "Script" in your name
            var queryResult4 = languages.Where(l => l.Name.Contains("Script"));
            PrettyPrintAll(queryResult4);

            // Output: searching for Laguages since Y2K
            var queryResult5 = languages.Where(l => l.Year >= 2000);
            PrettyPrintAll(queryResult5);

            // Output: searching for languages between 1995 and 2005
            var queryResult6 = languages.Where(l => l.Year >= 1995 && l.Year <= 2005);
            PrettyPrintAll(queryResult6);

            // Output: searching for languages
            var queryResult7 = languages
                .Where(l => l.Year >= 1995 && l.Year <= 2005)
                .Select(l => $"{l.Name} was invented in {l.Year}");

            PrintAll(queryResult7);
        }

        public static void PrettyPrintAll(IEnumerable<Language> languages)
        {
            foreach (var language in languages)
            {
                Console.WriteLine(language.Prettify());
            }

            Console.WriteLine($"La consulta tiene un total de {languages.Count()} fila(s).");
            Console.ReadKey();
            Console.Clear();
        }

        public static void PrintAll(IEnumerable<Object> languages)
        {
            int count = 0;
            foreach (var language in languages)
            {
                Console.WriteLine(language);
                count++;
            }

            Console.WriteLine($"La consulta tiene un total de {count} fila(s).");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
