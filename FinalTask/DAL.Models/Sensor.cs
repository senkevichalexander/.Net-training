using Models.Observer;
using System;
using System.Collections.Generic;
using System.Timers;

namespace Models
{
    public class Sensor : IObservable
    {
        private readonly List<IObserver> _observers;

        public Guid Id { get; }
        public Variety Variety { get; }
        public int Interval { get; }
        public IMode Mode { get; set; }
        public int Measure { get; set; }

        public Timer Timer { get; set; }

        public string Message { get; set; }

        public Sensor(Guid id, Variety variety, int interval)
        {
            Id = id;
            Variety = variety;
            Interval = interval;
            Mode = new SimpleMode(this);
            Measure = 0;
            _observers = new List<IObserver>();
        }

        public void SwitchMode()
        {
            Mode.SwitchMode(this);
        }

        public void AddObserver(IObserver o)
        {
            _observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            _observers.Remove(o);
        }

        public void NotifyObservers()
        {
            if (_observers != null)
            {
                foreach (var item in _observers)
                {
                    item.Update(this);
                }
            }
        }
    }
}

