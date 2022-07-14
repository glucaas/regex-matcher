using System;
using System.Text.RegularExpressions;

namespace ConsoleApp_ReegexErros
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a pattern for a word that starts with letter "M"  
            string patternPlaca = @"[A-Z]{3}[0-9][0-9A-Z][0-9]{2}";
            const string quote = "\"";
            string patterBase64 = $"[{quote}][c][h][e][c][k][l][i][s][t][{quote}][:].[{quote}]\\w*[{quote}]";
            System.Console.WriteLine("pattern base64: " + patterBase64);
            // // Get all matches  
            // MatchCollection matchedAuthors = rg.Matches(text);  
            var matchPlaca = buscarMatch(patternPlaca);
            var matchBase64 = buscarMatch(patterBase64);
            System.Console.WriteLine("Quantidade de match base64: " + matchBase64.Count);
            // Print all matched authors  
            System.Console.WriteLine($"Quantidade de registros: {matchPlaca.Count}");
            for (int count = 0; count < matchPlaca.Count; count++)
                Console.WriteLine($"PLACA: {matchPlaca[count].Value} base64: {matchBase64[count].Value}");
        }
        private static MatchCollection buscarMatch(string pattern)
        {
            Regex rg = new Regex(pattern);
            string textoArquivo = System.IO.File.ReadAllText(@"C:\Users\194745\Downloads\errospost.txt");
            MatchCollection matchedAuthors = rg.Matches(textoArquivo);
            return matchedAuthors;
        }
    }
}
