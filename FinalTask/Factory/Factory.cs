using DAL.Xml;
using DAL.Interfaces;
using DAL.Json;
using System;

namespace Factory
{
    public class Factory : IFactory
    {
        public IRepository GetRepository(string fileType)
        {
            if (string.IsNullOrEmpty(fileType))
            {
                throw new ArgumentException();
            }

            if (fileType == "Xml")
            {
                return new XmlRepository();
            }

            return new JsonRepository();
        }
    }
}
