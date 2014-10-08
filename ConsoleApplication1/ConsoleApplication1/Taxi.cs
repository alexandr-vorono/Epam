using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Taxi
    {
       
        private List<Car> list = new List<Car>();

        public List<Car> CarsList
        {
            get { return list; }
            set { list = value; }
        }
        public override String ToString()
        {
            string s = "";
            foreach (var t in list)
                s += "\n" + t.name + "\n" + t.model;
            return s;
        }
     }
}
