using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concordance
{
    /// <summary>
    ///Класс добавления слов в конкорданс
    /// </summary>
    public class Concordance
    {
        //Конкорданс
        private List<Word> _words = new List<Word>();
        //Возвращает список слов
        public List<Word> GetWords()
        {
            return _words;
        }
        /// <summary>
        /// Добавление слов и позиция в конкорданс
        /// </summary>
        /// <param name="math">Слово</param>
        /// <param name="position">Позиция слова в тексте</param>
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
       
    }
}
