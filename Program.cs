using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

class Program
{
    static void Main()
    {
        string inputFilePath = "hello-multilingual.txt";
        string outputFilePath = "language.json";

        if (!File.Exists(inputFilePath))
        {
            Console.WriteLine($"The file {inputFilePath} does not exist!");
            return;
        }

        string[] lines = File.ReadAllLines(inputFilePath);
       
        var languages = new List<LanguageGreeting>();

        for (int i = 0; i < lines.Length; i += 3)
        {
            
            if (i + 2 >= lines.Length)
            {
                Console.WriteLine($"Incomplete data for language entry starting at line {i + 1}");
                break;
            }

            // Read language, greeting, and pronunciation
            string language = lines[i].Trim();
            string greeting = lines[i + 1].Trim();
            string pronunciation = lines[i + 2].Trim();

            
            Console.WriteLine($"Processing entry starting at line {i + 1}:");
            Console.WriteLine($"Language: '{language}'");
            Console.WriteLine($"Greeting: '{greeting}'");
            Console.WriteLine($"Pronunciation: '{pronunciation}'");

           
            if (string.IsNullOrEmpty(language) || string.IsNullOrEmpty(greeting) || string.IsNullOrEmpty(pronunciation))
            {
                Console.WriteLine($"Skipping incomplete entry starting at line {i + 1}");
                continue;
            }

            
            if (string.IsNullOrEmpty(pronunciation))
            {
                pronunciation = "-";
            }

            if (string.IsNullOrEmpty(language))
            {
                language = "-";
            }

             if (string.IsNullOrEmpty(greeting))
            {
                greeting = "-";
            }

            var langGreeting = new LanguageGreeting
            {
                Language = language,
                Greeting = greeting,
                Pronunciation = pronunciation
            };

            languages.Add(langGreeting);
        }

       
        string jsonOutput = JsonConvert.SerializeObject(languages, Formatting.Indented);

        try
        {
           
            File.WriteAllText(outputFilePath, jsonOutput);
            Console.WriteLine($"Processing complete. Output written to {outputFilePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error writing to {outputFilePath}: {ex.Message}");
        }
    }

    class LanguageGreeting
    {
        public string? Language { get; set; }
        public string? Greeting { get; set; }
        public string? Pronunciation { get; set; }
    }
}
