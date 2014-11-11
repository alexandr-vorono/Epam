using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Terminal
    {
        private int numberVhod;
        public Port Port { get; set; }
        public Terminal(Port port)
        {
            this.Port = port;
        }
        public delegate void ToCall(int output, int input);
        public event ToCall CallToEven;

        public delegate void AnswerCallDelegate(int output, int input);
        public event AnswerCallDelegate AnswerCallToEvent;

        public delegate void EndCallDelegate(int output, int input);
        public event EndCallDelegate EndCallToEvent;

        public void CallTo(int input)
        {
            if (Port.PhoneNumber != input)
            {
                switch (Port.State)
                {
                    case PortState.Connected: Console.WriteLine("Абонент " + Port.PhoneNumber
                        + " звонит абоненту " + input);
                        numberVhod = input;
                        this.Port.State = PortState.Busy;
                        OnCallToEvent(Port.PhoneNumber, input);
                        break;
                    case PortState.Busy: Console.WriteLine("Вы уже звоните кому-то\n");
                        break;
                    case PortState.Disconnected:Console.WriteLine("Ваш номер не подключен");
                        break;
                }
            }
            else Console.WriteLine("Себе звонить нельзя.\n");
        }

        public virtual void OnCallToEvent(int output, int input)
        {
            if (CallToEven != null)
            {
                CallToEven(output, input);
            }
        }

        public void IncomingCall(int incomingNumber)
        {
            Port.State = PortState.InputCall;
            this.numberVhod = incomingNumber;
        }

        public void AnswerCall()
        {
            if (Port.State == PortState.InputCall)
            {
                this.Port.State = PortState.Busy;
                OnAnswerCallToEvent(numberVhod, Port.PhoneNumber);
                Console.WriteLine("Абонент  {0}  ответил ", Port.PhoneNumber);
            }
        }

        public virtual void OnAnswerCallToEvent(int output, int input)
        {
            if (AnswerCallToEvent != null)
            {
                AnswerCallToEvent(output, input);
            }
        }

        public void EndCall()
        {
            if (Port.State == PortState.Busy)
            {
                this.Port.State = PortState.Connected;
                OnEndCallToEvent(Port.PhoneNumber, numberVhod);
                Console.WriteLine("Звонок между {0} и {1} завершен \n", Port.PhoneNumber, numberVhod);
            }
        }
        public virtual void OnEndCallToEvent(int output, int input)
        {
            if (EndCallToEvent != null)
            {
                EndCallToEvent(output, input);
            }
        }

        public void abonentEndCall()
        {
            Port.State = PortState.Connected;
        }
    }
}
