using System;

namespace Models
{
    public class DalSensor
    {
        public Guid Id { get; }
        public Variety Variety { get; }
        public int Interval { get; }

        public DalSensor(Guid id, Variety variety, int interval)
        {
            Id = id;
            Variety = variety;
            Interval = interval;
        }
    }
}

