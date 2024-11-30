using System;
using System.IO;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "0_vstup.txt";
            string outPath = "0_vystup.txt";
            try 
            {
                using (TextAnalyzer sr = new TextAnalyzer(path))
                {
                    using (StreamWriter sw = new StreamWriter(outPath)) 
                    {
                        sw.WriteLine("Number of words: " + sr.WordCount);
                        sw.WriteLine("Number of character (with white spaces): " + sr.CharacterCount);
                        sw.WriteLine("Number of character (without white spaces): " + sr.CharacterNoWhitesCount);
                        sw.WriteLine("\nWord dictionary: ");
                        sw.WriteLine(sr.WriteDictionary());
                        sw.WriteLine("\nWords by order: \n");
                        sw.WriteLine(sr.WriteWordOrder());
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Soubor " + path + " neexistuje");
            }
            catch
            {
                Console.WriteLine("Soubor " + path + " nelze načíst");
            }
            
        }
    }
    class TextAnalyzer : StreamReader 
    {
        Dictionary<string, int> _words = new Dictionary<string, int>();
        public int WordCount { get; private set; }
        public int CharacterCount { get; private set; }
        public int CharacterNoWhitesCount { get; private set; }
        public List<String> WordOrder { get; private set; }
        public TextAnalyzer(string path) : base(path)
        {
            WordOrder = new List<string>();
            CharacterNoWhitesCount = 0;
            CharacterCount = 0;
            string tempString = null;
            int tempChar = this.Read();
            while(tempChar != -1) 
            {
                if (!Char.IsWhiteSpace((char)tempChar)) //pokud není bílým znakem
                {
                    CharacterNoWhitesCount++;
                    if (tempString == null)
                    {
                        tempString = Convert.ToString((char)tempChar);
                    }
                    else 
                    {
                        tempString = tempString + (char)tempChar;
                    }
                    
                }
                else //pokud narazil na bílý znak tak to znamená že bylo odděleno slovo
                {
                    //slovo se přidá do slovníku (pokud není prázdné)
                    if (tempString != null) 
                    {
                        AddWordToDictionary(tempString);
                    }
                    tempString = null; //tempSting se vyresetuje na prázdno
                }
                CharacterCount++;
                tempChar = this.Read();

            }
            if(tempString != null) //pokud soubor nebyl ukončen bílým znakem, tak tempString nebude null, tudíž se do slovníku přidá poslední slovo
            {
                AddWordToDictionary(tempString);
            }

            WordCount = WordOrder.Count();
        }
        public string WriteDictionary() 
        {
            string dictionaryPrint = null;
            foreach (var W in _words) 
            {
                switch (dictionaryPrint) 
                {
                    case null:
                        dictionaryPrint = W.Key + ": " + W.Value;
                        break;

                    default:
                        dictionaryPrint = dictionaryPrint + "\n" + W.Key + ": " + W.Value;
                        break;
                }
            }
            return dictionaryPrint;
        }
        private void AddWordToDictionary(string word) 
        {
            if (_words.ContainsKey(word))
            {
                _words[word] += 1;
            }
            else
            {
                _words.Add(word, 1);
            }
            WordOrder.Add(word);
        }

        public string WriteWordOrder() 
        {
            string orderedWords = null;
            foreach (string word in WordOrder)
            {
               switch(orderedWords) 
               {
                    case null:
                        orderedWords = word;
                        break;
                    default:
                        orderedWords = orderedWords + " " + word;
                        break;
               }
            }
            return orderedWords;
        }
       
    }
}