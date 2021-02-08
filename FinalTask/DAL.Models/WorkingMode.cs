using System;
using System.Timers;

namespace Models
{
    public class WorkingMode : IMode
    {        
        public WorkingMode(Sensor sensor)
        {
            sensor.Timer?.Dispose();
            ChangeMeasure(sensor);
        }

        public void ChangeMeasure(Sensor sensor)
        {
            sensor.Measure = 0;

            sensor.Timer = new Timer
            {
                Interval = sensor.Interval
            };

            sensor.Timer.Elapsed += new ElapsedEventHandler((sender, e) => OnChangedEvent(/*sender, e,*/ sensor));

            sensor.Timer.AutoReset = true;
            sensor.Timer.Enabled = true;
        }

        public void SwitchMode(Sensor sensor)
        {
            sensor.Mode = new SimpleMode(sensor);
        }

        private void OnChangedEvent(/*object source, ElapsedEventArgs e,*/ Sensor sensor)
        {
            var random = new Random();

            sensor.Measure = random.Next(1, 100);
            sensor.NotifyObservers();
        }

        public override string ToString()
        {
            return "Working mode";
        }
    }
}
