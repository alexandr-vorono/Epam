using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concordance
{
    class Program
    {
        static void Main(string[] args)
        {
            var str = new Reader();
            var va = str.Read();
           
            var parser = new Parser();
            var res = parser.Parsers(va);
            res.Result();
            Console.ReadKey();
        }
    }
}
