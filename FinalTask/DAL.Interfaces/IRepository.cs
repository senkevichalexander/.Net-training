using Models;
using System;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IRepository
    {
        public List<DalSensor> GetSensors();
        public void AddSensor(DalSensor sensor);
        public void Remove(Guid id);
    }
}
