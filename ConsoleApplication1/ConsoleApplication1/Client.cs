using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS
{
    public class Client
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public Contract Contract { get; set; }
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
