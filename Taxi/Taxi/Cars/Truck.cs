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
        public Truck(string name, string model, int speed, int price, int load) :
            base(name, model, speed, price)
        {
            this.load = load;
        }
        public override String ToString()
        {
            return "Грузовой:" + Info() + "\n" + "Грузоподъёмность:" + this.load.ToString() + "\n";
        }
    }
}
