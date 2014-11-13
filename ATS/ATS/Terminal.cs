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
        private int polu4atel;
        public Port Port { get; set; }
        private bool isCallInitiator = false;
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

        public void CallTo(int receiveNumber)
        {
            if (Port.PhoneNumber != receiveNumber)
            {
                switch (Port.State)
                {
                    case PortState.Connected:
                        Console.WriteLine("Абонент " + Port.PhoneNumber
                        + " звонит абоненту " + receiveNumber);
                        polu4atel = receiveNumber;
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
            this.polu4atel = incomingNumber;
            isCallInitiator = false;
        }

        public void AnswerCall()
        {
            if (Port.State == PortState.InputCall)
            {
                this.Port.State = PortState.Busy;
                OnAnswerCallToEvent(polu4atel, Port.PhoneNumber);
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
                if (isCallInitiator)
                    OnEndCallToEvent(Port.PhoneNumber, polu4atel);
                else
                    OnEndCallToEvent(polu4atel, Port.PhoneNumber);
                isCallInitiator = false;
                Console.WriteLine("Звонок между {0} и {1} завершен", Port.PhoneNumber, polu4atel);
            }
        }
        public virtual void OnEndCallToEvent(int output, int input)
        {
            if (EndCallToEvent != null)
            {
                EndCallToEvent(output, input);
            }
        }

        public void AbonentEndCall()
        {
            Port.State = PortState.Connected;
        }
    }
}
