using DAL.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace DAL.Xml
{
    public class XmlRepository : IRepository
    {
        private readonly XDocument _xDoc;
        private readonly string _path = "xmlData.xml";
        public XmlRepository()
        {
            _xDoc = XDocument.Load(_path);
        }

        public void AddSensor(DalSensor sensor)
        {
            var root = new XElement("sensor");
            root.Add(new XElement("id", sensor.Id));
            root.Add(new XElement("variety", sensor.Variety));
            root.Add(new XElement("interval", sensor.Interval));
            _xDoc.Element("sensors")?.Add(root);
            _xDoc.Save(_path);
  
        }

        public List<DalSensor> GetSensors()
        {
            var dataElement = _xDoc.Element("sensors");
            var sensorsElements = dataElement.Elements("sensor");

            var sensors = new List<DalSensor>();

            foreach (var item in sensorsElements)
            {
                var id = Guid.Parse(item.Element("id").Value);

                var variety = (Variety)Enum.Parse(typeof(Variety), item.Element("variety").Value);

                var interval = Convert.ToInt32(item.Element("interval").Value);

                var newSensor = new DalSensor(id, variety, interval);
                sensors.Add(newSensor);
            }

            return sensors;
        }

        public void Remove(Guid id)
        {
            var removeElement = _xDoc.Element("sensors").Elements().
                FirstOrDefault(x => x.Attribute("id").Value == id.ToString());

            removeElement.Remove();
            _xDoc.Save(_path);
        }
    }
}
