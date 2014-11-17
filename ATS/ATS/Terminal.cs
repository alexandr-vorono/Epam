using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS
{
    public class Terminal
    {
        //Номер вызываемого
        private int opponentNumber;
        //Порт
        public Port Port { get; set; }
        //Является ли телеон  вызывающим
        private bool isCallInitiator = false;
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="port">Порт</param>
        public Terminal(Port port)
        {
            this.Port = port;
        }
        //Соытие исходящего  вызова
        public delegate void ToCall(int output, int input);
        public event ToCall CallToEven;
        //Событие ответа на звонок
        public delegate void AnswerCallDelegate(int output, int input);
        public event AnswerCallDelegate AnswerCallToEvent;
        //Событие завершения звонка
        public delegate void EndCallDelegate(int output, int input);
        public event EndCallDelegate EndCallToEvent;
        /// <summary>
        /// Метод совершения звонка
        /// </summary>
        /// <param name="receiveNumber">Номер телефона вызываемого</param>
        public void CallTo(int receiveNumber)
        {
            if (Port.PhoneNumber != receiveNumber)
            {
                switch (Port.State)
                {
                    case PortState.Connected:
                        Console.WriteLine("Абонент " + Port.PhoneNumber
                        + " звонит абоненту " + receiveNumber);
                        opponentNumber = receiveNumber;
                        isCallInitiator = true;
                        this.Port.State = PortState.Busy;
                        OnCallToEvent(Port.PhoneNumber, receiveNumber);
                        break;
                    case PortState.Busy: Console.WriteLine("Вы уже звоните кому-то");
                        break;
                    case PortState.Disconnected: Console.WriteLine("Ваш номер не подключен");
                        break;
                }
            }
            else Console.WriteLine("Себе звонить нельзя.");
        }
        /// <summary>
        /// Метод вызывающий событие исходящего  звонка
        /// </summary>
        /// <param name="output">Номер вызывающего</param>
        /// <param name="input">Номер вызываемого</param>
        public virtual void OnCallToEvent(int output, int input)
        {
            if (CallToEven != null)
            {
                CallToEven(output, input);
            }
        }
        /// <summary>
        /// Метод вызывающий событие входящего звонка
        /// </summary>
        /// <param name="incomingNumber">Номер вызываемого</param>
        public void IncomingCall(int incomingNumber)
        {
            Port.State = PortState.InputCall;
            this.opponentNumber = incomingNumber;
            isCallInitiator = false;
        }
        /// <summary>
        /// Метод вызываемый при ответе на звонок
        /// </summary>
        public void AnswerCall()
        {
            if (Port.State == PortState.InputCall)
            {
                this.Port.State = PortState.Busy;
                OnAnswerCallToEvent(opponentNumber, Port.PhoneNumber);
                Console.WriteLine("Абонент  {0}  ответил ", Port.PhoneNumber);
            }
        }
        /// <summary>
        /// Метод вызывающий событие ответа на звонок
        /// </summary>
        /// <param name="output">Номер вызывающего</param>
        /// <param name="input">Номер вызываемого</param>
        public virtual void OnAnswerCallToEvent(int output, int input)
        {
            if (AnswerCallToEvent != null)
            {
                AnswerCallToEvent(output, input);
            }
        }
        /// <summary>
        /// Метод завершает звонок
        /// </summary>
        public void EndCall()
        {
            if (Port.State == PortState.Busy)
            {
                if (isCallInitiator)
                    OnEndCallToEvent(Port.PhoneNumber, opponentNumber);
                else
                    OnEndCallToEvent(opponentNumber, Port.PhoneNumber);
                isCallInitiator = false;
                Console.WriteLine("Звонок между {0} и {1} завершен", Port.PhoneNumber, opponentNumber);
            }
        }
        /// <summary>
        /// Метод вызывающий событие завершения звока
        /// </summary>
        /// <param name="output">Номер вызывающего</param>
        /// <param name="input">Номер вызываемого</param>
        public virtual void OnEndCallToEvent(int output, int input)
        {
            if (EndCallToEvent != null)
            {
                EndCallToEvent(output, input);
            }
        }
        /// <summary>
        /// Метод вызываемый при завершении звонка
        /// </summary>
        public void AbonentEndCall()
        {
            Port.State = PortState.Connected;
        }
        /// <summary>
        /// Метод подключения телефона к порту.
        /// </summary>
        public void Connect()
        {
            if (Port.State == PortState.Disconnected)
                Port.State = PortState.Connected;
        }

        /// <summary>
        /// Метод отключения телефона от порта.
        /// </summary>
        public void Disconnect()
        {
            if (Port.State == PortState.Connected)
                Port.State = PortState.Disconnected;
        }
    }
}
