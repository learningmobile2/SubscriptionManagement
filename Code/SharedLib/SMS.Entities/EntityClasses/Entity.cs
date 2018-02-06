using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.Entities
{
    public abstract class Entity : IEntity
    {
        public virtual long Id { get ; set ; }
        public virtual long LastUpdateId { get; set; }
        public virtual string Code { get; set; }
        public virtual string Description { get; set; }
        public virtual string Note { get; set; }
        public virtual bool IsActive { get; set; }
    }
}
