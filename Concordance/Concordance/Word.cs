using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concordance
{
    public class Word
    {
        private string word;
        private int count;
        private List<int> Position = new List<int>();

        public string GetWord()
        {
            return word;
        }

        public int GetCount()
        {
            return count;
        }

        public void AddPosition(int position)
        {
            count++;
            Position.Add(position);
        }

        public Word(string word, int position)
        {
            this.word = word;
            count = 1;
            Position.Add(position);
        }
    }
}
