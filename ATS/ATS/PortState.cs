using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS
{
    /// <summary>
    /// Статус порта
    /// </summary>
    public enum PortState
    {
        //Подключен
        Connected,
        //Не подключен
        Disconnected,
        //Занято
        Busy,
        //Входящий вызов
        InputCall
    }
}
