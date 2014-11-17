using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS
{
    public class Port
    {
        //Состояние порта.
        public PortState State { get; set; }
        //Телефонный номер абонента.
        public int PhoneNumber { get; set; }
        /// <summary>
        /// Конструктор  с параметрами
        /// </summary>
        /// <param name="phoneNumber">Номер телефна</param>
        /// <param name="state">Статус порта</param>
        public Port(int phoneNumber, PortState state)
        {
            this.State = state;
            this.PhoneNumber = phoneNumber;
        }

    }
}
