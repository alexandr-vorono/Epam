using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Concordance
{
    class Reader
    {
        public string[] Read()
        {
            string[] mass = {};
            try
            {
                mass = File.ReadAllLines("../../Files/test.txt", Encoding.Default);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception:" + e.Message);
            }
            return mass;
        }
    }
}
