using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi
{
    public class Car
    {
        public string name { get; set; }
        public int model { get; set; }
        public int speed { get; set; }

        public Car() { }
        public Car(string name, int model, int speed)
        {
            this.name = name;
            this.model = model;
            this.speed = speed;
            Console.WriteLine("sfgsdfgsdfgsdfgsdfg");
        }

        protected String Info()
        {
            return "\n\n\n bvz" + this.name.ToString();
        }
    }
}
