using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            
            ATS ats = new ATS();
            for (int i = 0; i < 10; i++)
            {
                ats.ClientsList.Add(new Client("FirstName" + i, "MiddleName" + i, "LastName" + i,
                    new Terminal(new Port(random.Next(1000000, 9999999), PortState.Connected))));
                ats.ClientsList.Last().Terminal.CallToEven += ats.CallToHandler;
                ats.ClientsList.Last().Terminal.AnswerCallToEvent += ats.AnswerCallHandler;
                ats.ClientsList.Last().Terminal.EndCallToEvent += ats.EndCallHandler;
            }

            for (int i = 0; i < 100; i++)
            {
                int n = random.Next(1, 11);
                int from = random.Next(0, 10);
                int to = random.Next(0, 10);
                switch (n)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                        ats.ClientsList[from].Terminal.CallTo(ats.ClientsList[to].Terminal.Port.PhoneNumber);
                        ats.ClientsList[to].Terminal.AnswerCall();
                        break;
                    case 5:
                        ats.ClientsList[from].Terminal.AnswerCall();
                        break;
                    case 6:
                        ats.ClientsList[to].Terminal.EndCall();
                        break;
                }
            }
            
            Console.ReadKey();
        }
    }
}
