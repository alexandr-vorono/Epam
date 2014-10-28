using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concordance
{
    public class Result
    {
        /// <summary>
        /// Метод возвращает строку-результат
        /// </summary>
        /// <param name="concordance">Конкорданс</param>
        /// <returns>Строка-результат</returns>
        public string Results(Concordance concordance)
        {
            var wordQuery =
            from word in concordance.GetWords()
            group word by word.GetWord()[0] into wordGroup
            orderby wordGroup.Key
            select wordGroup;
            string result = "";
            foreach (var groupOfWords in wordQuery)
            {
                result += string.Format("{0} \n", groupOfWords.Key.ToString().ToUpper());
                foreach (var word in groupOfWords)
                {
                    result += string.Format("{0} {1}:{2} \n\n", word.GetWord(), word.GetCount(),
                    word.GetPosition().Aggregate("", (current, temp) => current + (temp + " ")));
                }
            }
            return result;
        }
    }
}
