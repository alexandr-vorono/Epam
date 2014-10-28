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
        private string word;
        //Количество  повторений слова в тексте
        private int count;
        //Список позиций слов в тексте
        private List<int> Position = new List<int>();

        
        /// <summary>
        /// Метод возвращает слова встречающиеся в тексте
        /// </summary>
        /// <returns>Слово</returns>
        public string GetWord()
        {
            return word;
        }
        /// <summary>
        /// Метод  возвращает список позиции слов в тексте
        /// </summary>
        /// <returns></returns>
        public List<int> GetPosition()
        {
            return Position;
        }

        /// <summary>
        /// Метод получения количества повторений в тексте
        /// </summary>
        /// <returns>Количество повторений</returns>
        public int GetCount()
        {
            return count;
        }
        /// <summary>
        /// Метод добавления позиции и подсчета количества повторений
        /// </summary>
        /// <param name="position">Позиция</param>
        public void AddPosition(int position)
        {
            count++;
            if(Position.Contains(position) == false)
            Position.Add(position);
        }
        /// <summary>
        /// Конструктор  с параметрами
        /// </summary>
        /// <param name="word">Слово</param>
        /// <param name="position">Позиция</param>
        public Word(string word, int position)
        {
            this.word = word;
            count = 1;
            Position.Add(position);
        }
    }
}
