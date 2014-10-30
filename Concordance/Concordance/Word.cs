using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concordance
{
    public class Word
    {
        //Слово
        private string _word;
        //Количество  повторений слова в тексте
        private int _count;
        //Список позиций слов в тексте
        private List<int> _position = new List<int>();

        
        /// <summary>
        /// Метод возвращает слова встречающиеся в тексте
        /// </summary>
        /// <returns>Слово</returns>
        public string GetWord()
        {
            return _word;
        }
        /// <summary>
        /// Метод  возвращает список позиции слов в тексте
        /// </summary>
        /// <returns></returns>
        public List<int> GetPosition()
        {
            return _position;
        }

        /// <summary>
        /// Метод получения количества повторений в тексте
        /// </summary>
        /// <returns>Количество повторений</returns>
        public int GetCount()
        {
            return _count;
        }
        /// <summary>
        /// Метод добавления позиции и подсчета количества повторений
        /// </summary>
        /// <param name="position">Позиция</param>
        public void AddPosition(int position)
        {
            _count++;
            if(_position.Contains(position) == false)
            _position.Add(position);
        }
        /// <summary>
        /// Конструктор  с параметрами
        /// </summary>
        /// <param name="word">Слово</param>
        /// <param name="position">Позиция</param>
        public Word(string word, int position)
        {
            this._word = word;
            _count = 1;
            _position.Add(position);
        }
    }
}
