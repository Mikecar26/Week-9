using System.Text.RegularExpressions;
using System.IO;

/*
Common Regex Symbols:

^ Start of input 
$ End of input
\d A single digit 
\D A single NON-digit
\s Whitespace 
\S NON-whitespace
\w Word characters 
\W NON-word characters
[A-Za-z0-9] Range(s) of characters 
\^ ^ (caret) character
[aeiou] Set of characters 
[^aeiou] NOT in a set of characters
. Any single character 
\. . (dot) character

Quantifiers - affect previous symbol
* Zero or more
+ One or more 
? One or none
{3} Exactly three 
{3,5} Three to five
{3,} At least three 
{,3} Up to three
 */

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter a valid file path: ");
        string filePath = Console.ReadLine();
        var fileChecker = new Regex(@"[A-Z]:(\/([\w #])+)+\.\w{3}");

        if (fileChecker.IsMatch(filePath)) // Check valid file path
        {
            // Check file in computer
            try
            {
                StreamReader sr = new StreamReader(filePath);
                Console.WriteLine("Opening File...");
                string line;
                string[] words; 
                int count = 0;
                do
                {
                    line = sr.ReadLine();
                    if (line == null)
                        break;
                    Console.WriteLine(line);
                    words = line.Split(' ');
                    foreach(string word in words)
                    {
                        if (word != "")
                            count++;
                    }
                } while (line != null);
                Console.WriteLine("Number of words: " + count);
            }
            catch (Exception ex)
            {
                Console.WriteLine("File does not exist.");  
            }

        }
        else
            Console.WriteLine("Error: Invalid file path.");
    }
    
}

