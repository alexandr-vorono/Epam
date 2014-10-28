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
            var wordQuery =
            from word in _words
            group word by word.GetWord()[0] into wordGroup
            orderby wordGroup.Key
            select wordGroup;

            foreach (var groupOfWords in wordQuery)
            {
                Console.WriteLine(groupOfWords.Key.ToString().ToUpper());
                foreach (var word in groupOfWords)
                {
                    Console.WriteLine("{0} {1} : {2}", word.GetWord(), word.GetCount(), 
                    word.Posit.Aggregate(" ", (current, temp) => current + (temp + " "))+ "\n");
                }
            }
        }
    }
}
