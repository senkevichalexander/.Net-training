using System.Timers;

namespace Models
{
    public class CalibrationMode : IMode
    {
        public CalibrationMode(Sensor sensor)
        {
            sensor.Timer?.Dispose();
            ChangeMeasure(sensor);
        }
        public void ChangeMeasure(Sensor sensor)
        {
            sensor.Measure = 0;
            
            sensor.Timer = new Timer
            {
                Interval = 1000
            };

            sensor.Timer.Elapsed += new ElapsedEventHandler((sender, e) => OnChangedEvent(sensor));

            sensor.Timer.AutoReset = true;
            sensor.Timer.Enabled = true;
        }

        public void SwitchMode(Sensor sensor)
        {
            sensor.Mode = new WorkingMode(sensor);
        }

        private void OnChangedEvent(Sensor sensor )
        {
            sensor.Measure += 1;
            sensor.NotifyObservers();
        }

        public override string ToString()
        {
            return "Calibration mode";
        }
    }
}
