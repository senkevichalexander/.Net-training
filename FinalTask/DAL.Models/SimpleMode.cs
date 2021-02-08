namespace Models
{
    public class SimpleMode : IMode
    {
        public SimpleMode(Sensor sensor)
        {
            sensor.Timer?.Dispose();
            ChangeMeasure(sensor);
        }
        public void ChangeMeasure(Sensor sensor)
        {
            sensor.Measure = 0;
            sensor.NotifyObservers();
        }

        public void SwitchMode(Sensor sensor)
        {
            sensor.Mode = new CalibrationMode(sensor);
        }

        public override string ToString()
        {
            return "Simple mode";
        }
    }
}
