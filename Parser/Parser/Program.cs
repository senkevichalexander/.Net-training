using System;
using System.Collections.Generic;
using System.Xml;

namespace Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @".\\Config\\Info.xml";

            var parserXml = new ParserXml(path);
            var logins = parserXml.ParseXml();

            Print(logins); 

            var incorrectLogins = parserXml.GetIncorrectLogins();

            Print(incorrectLogins);

            var parserJson = new ParserJson();
            parserJson.SerializeJson(logins);

            Console.ReadKey();
        }

        private static void Print(List<Login> logins)
        {
            foreach (var item in logins)
            {
                Console.WriteLine($"Login: {item.Name}");

                foreach (var window in item.Windows)
                {
                    Console.WriteLine($"{window.Title} ({window.Top}, {window.Left}, {window.Width}, {window.Heigth})");
                }
            }
        }
    }
}
