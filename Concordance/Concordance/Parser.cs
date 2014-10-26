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
        public Concordance Parsers(string[] va)
        {
            string result;
            Concordance list = new Concordance();
            var newReg = new Regex("[a-zа-я]+-?[а-яa-z]*");
            for (int i = 0; i < va.Count(); i++)
            {
                result = va[i].ToLower();
                MatchCollection match = newReg.Matches(result);
                foreach (var mat in match)
                {
                    list.AddWord(mat.ToString(), i);
                   // Console.WriteLine(mat + "  "+i);

                }

            }

            return list;
        }
    }
}
