using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi
{
    public abstract class Car
    {
        public string name { get; set; }
        public string model { get; set; }
        public int speed { get; set; }

        public Car() { }
        public Car(string name, string model, int speed)
        {
            this.name = name;
            this.model = model;
            this.speed = speed;
        }

        protected String Info()
        {
            return "\nТип:" + this.name.ToString() + "\n Модель:" + this.model.ToString() + "\n Максимальная скорость:" + this.speed.ToString();
        }
    }
}
