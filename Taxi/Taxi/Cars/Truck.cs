using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi
{
    public class Truck : Car
    {
        public int load { get; set; }

        public Truck() : base() { }
        public Truck(string name, string model, int speed, int load) :
            base(name, model, speed)
        {
            this.load = load;
        }
        public override String ToString()
        {
            return Info() + "\n" + "Максимальная нагрузка:" + this.load.ToString();
        }
    }
}
