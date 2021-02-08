using BLL;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class SensorAdd : Form
    {
        private readonly string _repository;

        public SensorAdd(string repository)
        {
            _repository = repository;
            InitializeComponent();
        }

        private void SensorAdd_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var generatorId = GuidGenerator.GetInstance();
            var id = generatorId.GenerateNewGuid();
            var variety = (Variety)Enum.Parse(typeof(Variety), comboBox1.Text);
            var interval = Convert.ToInt32(textBox3.Text);

            var sensor = new Sensor(id, variety, interval);
            var service = new SensorService(_repository);
            service.AddSensor(sensor);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
