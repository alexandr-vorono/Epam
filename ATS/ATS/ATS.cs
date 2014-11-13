using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS
{
    public class ATS
    {
        public List<Client> ClientsList { get; set; }
        public List<Call> CallList { get; set; }
        public ATS()
        {
            ClientsList = new List<Client>();
            CallList = new List<Call>();
        }

        public Client FindClientByPhoneNumber(int number)
        {
            return ClientsList.Find(x => x.Terminal.Port.PhoneNumber == number);
        }

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

        public void CallToHandler(int ishod, int vhod)
        {
            Client ishodClient = FindClientByPhoneNumber(ishod);
            Client vhodClient = FindClientByPhoneNumber(vhod);
            Call call = new Call()
            {
                FromClient = ishodClient,
                ToClient = vhodClient
            };
            switch (vhodClient.Terminal.Port.State)
            {
                case PortState.Connected:
                    vhodClient.Terminal.IncomingCall(ishod);
                    call.StartTalk();
                    break;
                case PortState.Busy:
                case PortState.InputCall:
                    Console.WriteLine("Абонент занят");
                    ishodClient.Terminal.AbonentEndCall();
                    call.FailCall(CallResult.CalledSubscriberBusy);
                    break;
                case PortState.Disconnected: Console.WriteLine("Абонента с таким номером нет");
                    call.FailCall(CallResult.NoConected);
                    ishodClient.Terminal.AbonentEndCall();
                    break;
            }
            CallList.Add(call);
        }

        public void AnswerCallHandler(int ishod, int vhod)
        {
            Call call = new Call();
            call.StartTalk();
        }

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
