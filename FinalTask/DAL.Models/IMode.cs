using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public interface IMode
    {
        public void SwitchMode(Sensor sensor);
        public void ChangeMeasure(Sensor sensor);

    }
}
