using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS
{
    public static class Billing
    {
        /// <summary>
        /// Метод генерирующий отчет
        /// </summary>
        /// <param name="callList">Список всех  звонков</param>
        /// <param name="client">Клиент</param>
        /// <param name="startContractTime">Вркмя подписания контракта</param>
        /// <param name="nowTime">Настоящее время</param>
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
                    CallResult = x.CallResult,
                    TalkDuration = x.TalkDuration(),
                    AllCostTalk =
                        x.FromClient.Terminal.Port.PhoneNumber == client.Terminal.Port.PhoneNumber
                            ? x.TalkDuration() * client.Contract.TariffHistory.GetTariffByDate(nowTime).MinuteCost
                            : 0
                };
            Console.WriteLine("Ваш номер: {0}\nНачало  звонка\t\tСобеседник|Время|Завершение звонка\tТип звонка | Стоимость  вызова|\tРезультат вызова", client.Terminal.Port.PhoneNumber);
            int allCost = 0;
            foreach (var x in allCalls)
            {
                Console.WriteLine("{0}\t{1}\t   {2}\t{3}\t{4}\t{5}\t\t{6}", x.StartTalkTime, x.OpponentNumber, x.TalkDuration, x.EndCallTime, x.IsOutputCall ? "Исходящий" : "Входящий", x.AllCostTalk, x.CallResult );
                allCost += x.AllCostTalk;
            }
            int monthlyFee = 0;
            while (startContractTime< nowTime)
            {
                if (startContractTime > client.Contract.LastChangeTime)
                    monthlyFee += (int)client.Contract.TariffHistory.GetTariffByDate(startContractTime).DayCost(DateTime.DaysInMonth(startContractTime.Year, startContractTime.Month));
                startContractTime = startContractTime.AddDays(1);
            }
            Console.WriteLine("Общая сумма за разговоры: {0}\nАбонентская плата: {1}\nИтого:{2}", allCost, monthlyFee, allCost+monthlyFee );
        }
    }
}
