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
            var read = new Reader();
            var str = read.Read();
           
            var parser = new Parser();
            Concordance concordance = parser.Parsers(str);

            Result result = new Result();
            string res = result.Results(concordance);
            Console.WriteLine(res);

            Writer writer = new Writer();
            writer.Write(res);

            Console.ReadKey();
        }
    }
}
