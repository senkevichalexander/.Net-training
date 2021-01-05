using System.Xml.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Parser
{
    public class ParserXml
    {
        private XDocument _xDoc;
        public ParserXml(string path)
        {
            _xDoc = XDocument.Load(path);
        }
        public List<Login> ParseXml()
        {
            var configElement = _xDoc.Element("config");
            var loginElements = configElement.Elements("login");

            var logins = new List<Login>();

            foreach(var item in loginElements)
            {
                var name = item.Attribute("name")?.Value;
                var windowElements = item.Elements("window");

                var windows = new List<Window>();

                foreach(var window in windowElements)
                {
                    var title = window.Attribute("title")?.Value;
                    var top = ConvertNullableInt(window.Element("top"));
                    var width = ConvertNullableInt(window.Element("width"));
                    var left = ConvertNullableInt(window.Element("left"));
                    var height = ConvertNullableInt(window.Element("height"));

                    var newWindow = new Window(title, top, left, width, height);

                    windows.Add(newWindow);
                }
                var login = new Login(name, windows);

                logins.Add(login);
            }

            return logins;
        }
        
        private int? ConvertNullableInt(XElement element)
        {
            return element != null 
                ? Convert.ToInt32(element.Value) 
                : (int?)null;
        }

        public List<Login> GetIncorrectLogins()
        {
            var logins = ParseXml();

            return logins.Where(x => !x.IsValid()).ToList();
        }
    }
}
