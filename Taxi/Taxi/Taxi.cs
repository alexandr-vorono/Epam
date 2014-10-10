using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi
{
    public class Taxi
    {

        private List<Car> list = new List<Car>();

        public List<Car> CarsList
        {
            get { return list; }
            set { list = value; }
        }

        public int TotalCoast()
        {
            int summ = 0;
            foreach (var t in list)
            {
                summ += t.price;
            }
            return summ;
        }
        public override String ToString()
        {
            string s = "";
            foreach (var t in list)
                s += t + "\n";
            return s;
        }
    }
}
