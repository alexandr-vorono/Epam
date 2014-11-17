using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS
{
    /// <summary>
    /// Результат звонка
    /// </summary>
    public enum CallResult
    {
        //Успешный звонок
        Success,
        //Неудачный звонок
        Fail,
        //Вызываемый не подключен
        NoConected,
        //вызываемый занят
        CalledSubscriberBusy,
        //вызываемый не отвечает
        NotAnswer
    }
}
