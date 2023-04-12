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
            List<Language> languages = File.ReadAllLines("./languages.tsv")
              .Skip(1)
              .Select(line => Language.FromTsv(line))
              .ToList();

            PrettyPrintAll(languages);


            var details = languages.Select(l => $"{l.Year}, {l.Name}, {l.ChiefDeveloper}");
            foreach (string detail in details)
            {
                //Console.WriteLine(detail);
            }

            var cSharp = languages
            .Where(l => l.Name.Contains("C#"));

            foreach (Language c in cSharp)
            {
                Console.WriteLine(c.Prettify());
            }
            var microsoftLanguages = languages.Where(l => l.ChiefDeveloper.Contains("Microsoft"));
            PrettyPrintAll(microsoftLanguages);


            var languageWithScript = languages
            .Where(l => l.Name.Contains("Script"))
            .Select(l => l.Name);

            foreach (string l in languageWithScript)
            {
                //Console.WriteLine(l);
            }

            Console.WriteLine(languages.Count());

            var languagesInTenYears = languages
            .Where(l => l.Year >= 1995 && l.Year <= 2005);
            Console.WriteLine(languagesInTenYears.Count());

            static void PrettyPrintAll(IEnumerable<Language> langs)
            {
                foreach (Language l in langs)
                {
                    Console.WriteLine(l.Prettify());
                }
            }

        }
    }
}


