using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concordance
{
    class Concordance
    {
        private List<Word> _words = new List<Word>();

        public void AddWord(string math, int position)
        {
            Word searchWord = _words.Find(x => x.GetWord().Equals(math));
            if(searchWord==null)
            {
                _words.Add(new Word(math, position));
            }
            else
            {
                searchWord.AddPosition(position);
            }
        }

        public void Result()
        {
            foreach (var word in _words)
            {
                Console.WriteLine(word.GetWord() + " " + word.GetCount());
            }
        }
    }
}
