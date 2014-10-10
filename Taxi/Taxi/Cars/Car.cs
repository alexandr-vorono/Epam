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
        public int price { get; set; }

        public Car() { }
        public Car(string name, string model, int speed, int price)
        {
            this.name = name;
            this.model = model;
            this.speed = speed;
            this.price = price;
        }

        protected String Info()
        {
            return "\nНазвание:" + this.name.ToString() + "\nМодель:" + this.model.ToString() +
                "\nМаксимальная скорость:" + this.speed.ToString() + "\nЦена:" + this.price.ToString();
        }
    }
}
