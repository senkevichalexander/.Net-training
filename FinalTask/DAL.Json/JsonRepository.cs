using DAL.Interfaces;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DAL.Json
{
    public class JsonRepository : IRepository
    {
        private readonly string _path = "jsonData.json";

        public void AddSensor(DalSensor sensor)
        {
            var sensors = GetSensors();
            sensors.Add(sensor);

            var json = JsonConvert.SerializeObject(sensors);
            using (var fs = new StreamWriter(_path, false))
            {
                fs.Write(json);
            }
        }

        public List<DalSensor> GetSensors()
        {
            var sensors = new List<DalSensor>();

            using (var st = new StreamReader(_path))
            {
                var json = st.ReadToEnd();
                sensors = JsonConvert.DeserializeObject<List<DalSensor>>(json);
            }

            return sensors;
        }

        public void Remove(Guid id)
        {
            var listSensors = GetSensors().Where(x => x.Id != id);
            var json = JsonConvert.SerializeObject(listSensors);

            using (var st = new StreamWriter(_path, false))
            {
                st.Write(json);             
            }
        }
    }
}
