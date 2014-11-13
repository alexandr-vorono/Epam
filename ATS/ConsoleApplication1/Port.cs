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
       
        public Port(int phoneNumber, PortState state)
        {
            this.State = state;
            this.PhoneNumber = phoneNumber;
        }
        
    }
}
