using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.Entities
{
    interface IEntity
    {
        long Id { get; set; }
        long LastUpdateId { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string Note { get; set; }
    }
}
