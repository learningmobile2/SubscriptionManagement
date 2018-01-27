using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.Entities
{
    public abstract class Entity : IEntity
    {
        public long Id { get ; set ; }
        public long LastUpdateId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public bool IsActive { get; set; }
    }
}
