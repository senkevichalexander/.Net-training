using BLL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace UI
{
    public partial class Sensors : Form
    {
        private Timer _timer;
        private List<Sensor> _sensors;

        public Sensors()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var service = new SensorService(comboBox1.Text);
            _sensors = service.GetSensors();
            listBox1.Items.Clear();

            foreach (var item in _sensors)
            {
                listBox1.Items.Add(item.Id + " " + item.Variety);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var sensorAdd = new SensorAdd(comboBox1.Text);
            sensorAdd.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var sensorId = listBox1.SelectedItem.ToString().Split(' ').First();
            var service = new SensorService(comboBox1.Text);
            service.Remove(Guid.Parse(sensorId));

            var sensors = service.GetSensors();
            listBox1.Items.Clear();

            foreach (var item in sensors)
            {
                listBox1.Items.Add(item.Id + " " + item.Variety);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var sensorId = listBox1.SelectedItem.ToString().Split(' ').First();
            var service = new SensorService(comboBox1.Text);
            var sensor = _sensors.FirstOrDefault(x => x.Id.ToString() == sensorId);

            _timer?.Dispose();
            service.SwitchMode(sensor);
            _timer = new Timer() { Interval = 1000 };
            _timer.Tick += new EventHandler((o, e) => OnTimer(sensor));
            _timer.Start();
        }

        private void OnTimer(Sensor sensor)
        {
            label1.Text = sensor.Message;
        }
    }
}
