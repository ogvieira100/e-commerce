
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperEvaluation.Core.Domain
{
    public abstract class BaseEntity 
    {
        public long Id { get; set; }
        public DateTime? DateUpdated { get; set; }
        public long? IdUserUpdated { get; set; }
        public DateTime? DateDeleted { get; set; }
        public long? IdUserDeleted { get; set; }
        public DateTime DateCreated { get; set; }
        public long IdUserInserted { get; set; }
        public bool Active { get; set; }

        protected BaseEntity()
        {
            DateCreated = DateTime.Now;
            Active = true;
        }

    }
}
