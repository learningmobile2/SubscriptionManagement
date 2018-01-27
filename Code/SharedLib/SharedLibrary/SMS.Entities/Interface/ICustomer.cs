using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.Entities
{
    public interface ICustomer : IEntity
    {
        string Alias { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
    }
}
