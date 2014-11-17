using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS
{
    public class Call
    {
        //Вызывающий
        public Client FromClient { get; set; }
        //Вызываемый
        public Client ToClient { get; set; }
        //Время начала вызова
        public DateTime StartCallTime { get; set; }
        //Время начала разговора
        public DateTime StartTalkTime { get; set; }
        //Время завершения звонка
        public DateTime EndCallTime { get; set; }
        //Результат звонка
        public CallResult CallResult { get; set; }
        //Начат ли разговор
        public bool IsStartTalk { get; set; }
        //Завершен  ли звонок
        public bool IsEndCall { get; set; }
        /// <summary>
        /// Конструктор
        /// </summary>
        public Call()
        {
            StartCallTime = Program.myTimer.GetTime();
            IsStartTalk = false;
            IsEndCall = false;
        }
        /// <summary>
        /// Метод вызываемый при начале разговара
        /// </summary>
        public void StartTalk()
        {
            StartTalkTime = Program.myTimer.GetTime();
            IsStartTalk = true;
        }
        /// <summary>
        /// Метод вызываемый при завершении разговора
        /// </summary>
        public void EndCall()
        {
            CallResult = CallResult.Success;
            EndCallTime = Program.myTimer.GetTime();
            IsEndCall = true;
        }
        /// <summary>
        /// Метод возвращает длительность разговора
        /// </summary>
        /// <returns>Длительность разгововра</returns>
        public int TalkDuration()
        {
            return (int)Math.Ceiling((EndCallTime - StartTalkTime).TotalMinutes);
        }
        /// <summary>
        /// Метод вызываемый при неудачном вызове
        /// </summary>
        /// <param name="callResult">Результат звонка</param>
        public void FailCall(CallResult callResult)
        {
            this.CallResult = callResult;
            IsEndCall = true;
            EndCallTime = StartCallTime;
            StartTalkTime = StartCallTime;
        }
    }
}
