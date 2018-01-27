using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.Entities
{
    public class Customer : Entity, ICustomer
    {
        public string Alias { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
