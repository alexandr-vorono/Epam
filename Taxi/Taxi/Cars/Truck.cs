using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi
{
    public class Truck : Car
    {
        public int Load { get; set; }

        public Truck() : base() { }
        public Truck(string make, string model, int speed, int price, int load) :
            base(make, model, speed, price)
        {
            this.Load = load;
        }
        public override String ToString()
        {
            return "Грузовой:" + Info() + "\n" + "Грузоподъёмность:" + this.Load.ToString() + "\n";
        }
    }
}
