using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi
{
    public class Bus : Car
    {
        public int count { get; set; }

        public Bus() : base() { }
        public Bus(string name, string model, int speed, int count) :
            base(name, model, speed)
        {
            this.count = count;
        }
        public override String ToString()
        {
            return "Автобус:" + Info() + "Количество пассажиров:" + this.count.ToString();
        }
    }
}
