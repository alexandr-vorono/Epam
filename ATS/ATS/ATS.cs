using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS
{
    public class ATS
    {  
        //Список клиентов
        public List<Client> ClientsList { get; set; }
        //Список звонков
        public List<Call> CallList { get; set; }
        /// <summary>
        /// Конструктор
        /// </summary>
        public ATS()
        {
            ClientsList = new List<Client>();
            CallList = new List<Call>();
        }
        /// <summary>
        /// Метод поиска клиента по его номеру
        /// </summary>
        /// <param name="number">Номер телефона</param>
        /// <returns>Клиент</returns>
        public Client FindClientByPhoneNumber(int number)
        {
            return ClientsList.Find(x => x.Terminal.Port.PhoneNumber == number);
        }
        /// <summary>
        /// Поиск звонка по номерам разговаривающтх
        /// </summary>
        /// <param name="otput"> Номер вызывающего</param>
        /// <param name="input">Номер вызываемого</param>
        /// <returns>Вызов</returns>
        public Call FindCallByPhoneNumber(int otput, int input)
        {
            try
            {
                return CallList.Find(x => x.FromClient.Terminal.Port.PhoneNumber == otput
                                          && x.ToClient.Terminal.Port.PhoneNumber == input
                                          && x.IsEndCall == false);
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Обработчик события исходящего звонка
        /// </summary>
        /// <param name="output">Номер вызывающего</param>
        /// <param name="input">Номер  вызываемого</param>
        public void CallToHandler(int output, int input)
        {
            Client outputClient = FindClientByPhoneNumber(output);
            Client inputClient = FindClientByPhoneNumber(input);
            Call call = new Call()
            {
                FromClient = outputClient,
                ToClient = inputClient
            };
            switch (inputClient.Terminal.Port.State)
            {
                case PortState.Connected:
                    inputClient.Terminal.IncomingCall(output);
                    call.StartTalk();
                    break;
                case PortState.Busy:
                case PortState.InputCall:
                    Console.WriteLine("Абонент занят");
                    outputClient.Terminal.AbonentEndCall();
                    call.FailCall(CallResult.CalledSubscriberBusy);
                    break;
                case PortState.Disconnected: Console.WriteLine("Абонента с таким номером нет");
                    call.FailCall(CallResult.NoConected);
                    outputClient.Terminal.AbonentEndCall();
                    break;
            }
            CallList.Add(call);
        }
        /// <summary>
        /// Обработчик события ответа на звонок
        /// </summary>
        /// <param name="output">Номер вызывающего</param>
        /// <param name="input">Номер вызываемого</param>
        public void AnswerCallHandler(int output, int input)
        {
            Call call = new Call();
            call.StartTalk();
        }
        /// <summary>
        /// Обработчик события завершения вызова
        /// </summary>
        /// <param name="output">Номер вызывающего</param>
        /// <param name="input">Номер  вызываемого</param>
        public void EndCallHandler(int output, int input)
        {
            Client vhodClient = FindClientByPhoneNumber(input);
            Client ishodClient = FindClientByPhoneNumber(output);
            Call call = new Call();
            call = FindCallByPhoneNumber(output, input);
            if (call.IsStartTalk)
            {
                call.EndCall();
                vhodClient.Terminal.AbonentEndCall();
                ishodClient.Terminal.AbonentEndCall();

            }
            else
            {
                call.FailCall(CallResult.NotAnswer);
            }
        }
    }
}
