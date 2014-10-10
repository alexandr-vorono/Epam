using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi
{
    public class PassengerCar : Car
    {
        public int obem { get; set; }

        public PassengerCar() : base() { }
        public PassengerCar(string name, string model, int speed, int abem) :
            base(name, model, speed)
        {
            this.obem = obem;
        }
        public override String ToString()
        {
            return "Легковой:" + Info() + "Объем:" + this.obem.ToString();
        }

    }
}
