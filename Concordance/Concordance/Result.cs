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
        public StringBuilder Results(Concordance concordance)
        {
            var wordQuery =
                from word in concordance.GetWords()
                orderby word.GetWord()
                select word; 
            var resultBuilder = new StringBuilder();
            string letter2 = "";
            foreach (var word in wordQuery)
            {
                string letter = word.GetWord().Substring(0, 1).ToUpper();
                if (letter != letter2)
                {
                    resultBuilder.Append("\n" + letter + "\n");
                    letter2 = letter;
                }
                resultBuilder.Append(word.GetWord() + " " + word.GetCount() + ":" +
                        word.GetPosition().Aggregate(" ", (current, temp) => current + (temp + " ")) + "\n");
            }
            return resultBuilder;
        }
    }
}
