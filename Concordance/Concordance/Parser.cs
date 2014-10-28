using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Concordance
{
    class Parser
    {
        /// <summary>
        /// Метод парсит строку
        /// </summary>
        /// <param name="str">Строка</param>
        /// <returns>Список слов</returns>
        public Concordance Parsers(string[] str)
        {
            string result;
            Concordance list = new Concordance();
            var newReg = new Regex("[a-zа-я]+-?[а-яa-z]*");
            for (int i = 0; i < str.Count(); i++)
            {
                result = str[i].ToLower();
                MatchCollection match = newReg.Matches(result);
                foreach (var mat in match)
                {
                    list.AddWord(mat.ToString(), i/10 + 1);
                }
            }
            return list;
        }
    }
}
