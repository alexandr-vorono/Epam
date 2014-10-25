using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concordance
{
    class Concordance
    {
        private List<string> _words = new List<string>();

        public void addWord(string math)
        {
            _words.Add(math);
        }
    }
}
