using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace project_tracker_domain.Interfaces
{
    public interface IAuditable
    {
        DateTime CreatedAt { get; set; }

        DateTime UpdatedAt { get; set; }

        Guid CreatedBy { get; set; }

        Guid UpdatedBy { get; set; }
    }
}
