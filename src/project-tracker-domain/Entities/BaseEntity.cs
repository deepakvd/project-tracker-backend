using project_tracker_domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace project_tracker_domain.Entities
{
    public abstract class BaseEntity : IAuditable
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Guid CreatedBy { get; set; }

        public Guid UpdatedBy { get; set; }




    }
}
