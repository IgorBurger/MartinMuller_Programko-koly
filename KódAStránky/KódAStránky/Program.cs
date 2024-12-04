using System;
using System.Reflection;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string statement = null;
            string readHtmlFile = null;
            string title = null;
            bool titleFound = false;
            try 
            {
                using (StreamReader sr = new StreamReader("Stranka1.html"))
                {
                    char character = (char)sr.Read();
                    readHtmlFile = readHtmlFile + character;
                    while (titleFound == false)
                    {
                        if (character == '<')
                        {
                            while (character != '>')
                            {
                                character = (char)sr.Read();
                                readHtmlFile = readHtmlFile + character;
                                if (character != '>')
                                {
                                    statement = statement + character;
                                }
                            }
                            if (statement == "div id=\"comic\"")
                            {
                                //Console.WriteLine("div id=comic");
                                //Console.WriteLine(statement);
                                sr.Read();
                                statement = sr.ReadLine();


                                //Console.WriteLine(statement);
                                int index = statement.IndexOf("title=\"") + 7;
                                while (statement[index] != '\"')
                                {
                                    character = statement[index];
                                    title = title + character;
                                    index++;
                                }
                                //Console.WriteLine(title);
                                titleFound = true;
                                //Console.ReadKey();
                                readHtmlFile = readHtmlFile + "\n" + statement;
                                //Console.WriteLine(readHtmlFile);

                            }
                            //Console.WriteLine(statement);
                            statement = null;
                        }
                        if (!titleFound) { character = (char)sr.Read(); readHtmlFile = readHtmlFile + character; }
                    }
                    //int InsertIndex = readHtmlFile.IndexOf(statement) + statement.Length;
                    using (StreamWriter sw = new StreamWriter("Stranka1Vystup.html"))
                    {
                        //Console.WriteLine(readHtmlFile);
                        sw.Write(readHtmlFile);
                        sw.Write("\n <p>" + title + "</p>");
                        sw.Write(sr.ReadToEnd());
                    }
                }
            }
            catch 
            {
                Console.WriteLine("Nastal nečekaný problém s načítáním souboru");
            }
        }
    }
}