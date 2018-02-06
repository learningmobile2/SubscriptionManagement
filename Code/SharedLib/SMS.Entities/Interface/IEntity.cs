using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.Entities
{
    public interface IEntity
    {
        long Id { get; set; }
        long LastUpdateId { get; set; }
        string Code { get; set; }
        string Description { get; set; }
        string Note { get; set; }
        bool IsActive { get; set; }
    }
}
