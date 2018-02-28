using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task03
{
    class Program
    {
        static void Main()
        {            
            string[] splitStr = new string[] { " ", "\n", "\r", "-", ".", ",", ":" };
            StreamReader wordsReader = new StreamReader("words.txt");
            StreamReader textReader = new StreamReader("text.txt");
            StreamWriter writer = new StreamWriter("result.txt");
            Dictionary<string, int> matchedWords = new Dictionary<string, int>();

            using (wordsReader)
            {
                using (textReader)
                {
                    string[] words = wordsReader.ReadToEnd().ToLower().Split(splitStr, StringSplitOptions.RemoveEmptyEntries);
                    string[] text = textReader.ReadToEnd().ToLower().Split(splitStr, StringSplitOptions.RemoveEmptyEntries);
                                        
                    foreach (string word in words)
                    {
                        foreach (string s in text)
                        {
                            if (s == word )
                            {
                                if (!matchedWords.ContainsKey(word))
                                {
                                    matchedWords.Add(word, 0);
                                }
                                matchedWords[word]++;
                            }
                        }
                    }
                }                    
            }
            using (writer)
            {
                foreach (var pair in matchedWords.OrderByDescending(p => p.Value))
                {
                    writer.WriteLine("{0} - {1}", pair.Key, pair.Value);
                }                
            }            
        }
    }
}
