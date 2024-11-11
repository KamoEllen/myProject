using System;
using System.IO;  

class Program
{
    static void Main(string[] args)
    {
        string filePath = "hi.txt";
        File.WriteAllText(filePath, "Hello World");
       
        string fileContent = File.ReadAllText(filePath);
        Console.WriteLine(fileContent);
    }
}
