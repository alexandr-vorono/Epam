using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS
{
    public static class Billing
    {
        public static void DetailedReport(List<Call> callList, Client client, DateTime startContractTime, DateTime nowTime)
        {
            var allCalls =
                from x in callList
                where x.IsEndCall && (x.FromClient.Terminal.Port.PhoneNumber == client.Terminal.Port.PhoneNumber ||
                      x.ToClient.Terminal.Port.PhoneNumber == client.Terminal.Port.PhoneNumber)
                select new
                {
                    OpponentNumber =
                        x.FromClient.Terminal.Port.PhoneNumber == client.Terminal.Port.PhoneNumber
                            ? x.ToClient.Terminal.Port.PhoneNumber
                            : x.FromClient.Terminal.Port.PhoneNumber,
                    IsOutputCall = x.FromClient.Terminal.Port.PhoneNumber == client.Terminal.Port.PhoneNumber,
                    StartTalkTime = x.StartCallTime,
                    EndCallTime = x.EndCallTime,
                    TalkDuration = x.TalkDuration(),
                    AllCostTalk =
                        x.FromClient.Terminal.Port.PhoneNumber == client.Terminal.Port.PhoneNumber
                            ? x.TalkDuration()*client.Contract.TariffHistory.GetTariffByDate(nowTime).MinuteCost
                            : 0
                };
            Console.WriteLine("Ваш номер: {0}\nНачало  звонка\t\tСобеседник|Время|Завершение звонка\tТип звонка", client.Terminal.Port.PhoneNumber);
            foreach (var x in allCalls)
            {
                Console.WriteLine("{0}\t{1}\t   {2}\t{3}\t{4}",x.StartTalkTime, x.OpponentNumber, x.TalkDuration, x.EndCallTime, x.IsOutputCall ? "Исходящий" : "Входящий");
            }
        }
    }
}
