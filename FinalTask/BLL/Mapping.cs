using Models;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class Mapping
    {
        public Sensor SensorToDalSensor(DalSensor dalSensor)
        {
            return new Sensor(dalSensor.Id, dalSensor.Variety, dalSensor.Interval);
        }

        public DalSensor SensorToDalSensor(Sensor dalSensor)
        {
            return new DalSensor(dalSensor.Id, dalSensor.Variety, dalSensor.Interval);
        }

        public List<Sensor> GetSensorsFromDal(List<DalSensor> dalSensors)
        {
            return dalSensors.Select(x => new Sensor(x.Id, x.Variety, x.Interval)).ToList();
        }

        public List<DalSensor> GetDalSensorsFromBll(List<Sensor> sensors)
        {
            return sensors.Select(x => new DalSensor(x.Id, x.Variety, x.Interval)).ToList();
        }
    }
}
