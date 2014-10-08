using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Cars
{
    public class Truck:Car
    {
        public int load { get; set; }

        public Truck() : base() { }
        public Truck(string name, int model, int speed, int load) :
            base(name, model, speed)
        {
            this.load = load;
        }
        public override string ToString()
        {
            return "Грузовой автомобиль:" + Info() + "Максимальная нагрузка:" + this.load.ToString();
        }
    }
}
