using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS
{
    public class Client
    {
        //Имя клиента
        public string FirstName { get; set; }
        //Отчество  клиента
        public string MiddleName { get; set; }
        //Фамилия клиента
        public string LastName { get; set; }
        //Договор клиента
        public Contract Contract { get; set; }
        //Терминал  клиента
        public Terminal Terminal { get; set; }

        public Client(string firstName, string middleName, string lastName, Contract contract, Terminal terminal)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.Contract = contract;
            this.Terminal = terminal;
        }
    }
}
