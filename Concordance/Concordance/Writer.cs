using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concordance
{
    public class Writer
    {
        /// <summary>
        /// Метод записи в файл
        /// </summary>
        /// <param name="result">Строка которую надо  записать</param>
        public void Write(StringBuilder result)
        {
            try
            {
                StreamWriter writer = new StreamWriter("../../Files/ouput.txt");
                writer.WriteLine(result);
                writer.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
    }
}
