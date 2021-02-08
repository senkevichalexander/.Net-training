using DAL.Interfaces;
using Factory;
using Models;
using Models.Observer;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class SensorService : IObserver
    {
        private readonly IRepository _repository;
        private readonly Mapping _mapping;

        public SensorService(string fileType)
        {
            IFactory factory = new Factory.Factory();
            _mapping = new Mapping();
            _repository = factory.GetRepository(fileType);
        }

        public void SwitchMode(Sensor sensor)
        {
            sensor.SwitchMode();
        }

        public List<Sensor> GetSensors()
        {
            var dalSensors = _repository.GetSensors();
            var sensors = _mapping.GetSensorsFromDal(dalSensors);

            foreach (var item in sensors)
            {
                item.AddObserver(this);
            }

            return sensors;
        }

        public void AddSensor(Sensor sensor)
        {
            _repository.AddSensor(_mapping.SensorToDalSensor(sensor));
        }

        public void Remove(Guid id)
        {
            _repository.Remove(id);
        }

        public void Update(Sensor sensor)
        {
            sensor.Message = $"Mode: {sensor.Mode}, measure: {sensor.Measure}";
        }
    }
}
