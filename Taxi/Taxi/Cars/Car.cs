using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi
{
    public abstract class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Speed { get; set; }
        public int Price { get; set; }

        public Car() { }
        public Car(string name, string model, int speed, int price)
        {
            this.Make = name;
            this.Model = model;
            this.Speed = speed;
            this.Price = price;
        }

        protected String Info()
        {
            return "\nНазвание:" + this.Make.ToString() + "\nМодель:" + this.Model.ToString() +
                "\nМаксимальная скорость:" + this.Speed.ToString() + "\nЦена:" + this.Price.ToString();
        }
    }
}
