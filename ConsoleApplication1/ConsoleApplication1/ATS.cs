using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
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

        public Client PoiskClient(int number)
        {
            return ClientsList.Find(x => x.Terminal.Port.PhoneNumber == number);
        }

        public void CallToHandler(int ishod, int vhod)
        {
            Client ishodClient = PoiskClient(ishod);
            Client vhodClient = PoiskClient(vhod);
            Call call = new Call();
            switch (vhodClient.Terminal.Port.State)
            {
                    case PortState.Connected:
                    vhodClient.Terminal.IncomingCall(ishod);
                    //Console.WriteLine("Абонент {0}  звонит", vhod);
                    break;
                case PortState.Busy:
                    Console.WriteLine("Абонент занят");
                    break;
                case PortState.Disconnected: Console.WriteLine("Абонента с таким номером нет");
                    break;
                case PortState.InputCall: Console.WriteLine("Абонент занят");
                    break;
            }
            CallList.Add(call);
        }

        public void AnswerCallHandler(int ishod, int vhod)
        {
            Call call = new Call();
            call.StartCall();
        }

        public void EndCallHandler(int output, int input)
        {
            Call call = new Call();
            Client vhodClient = PoiskClient(input);
            switch (vhodClient.Terminal.Port.State)
            {
                case PortState.Busy:
                    vhodClient.Terminal.Port.State = PortState.Connected;
                    call.EndCall();
                    vhodClient.Terminal.abonentEndCall();
                    break;
            }
        }
    }
}
