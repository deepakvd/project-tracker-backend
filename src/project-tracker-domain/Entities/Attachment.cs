using System;
using System.Collections.Generic;
using System.Text;

namespace project_tracker_domain.Entities
{
    public class Attachment : BaseEntity
    {
        public Guid TaskId { get; set; } // Foreign key to Task

        public Task Task { get; set; } // Navigation property to Task

        public string FileName { get; set; }

        public string FilePath { get; set; }

        public long FileSize { get; set; } // Size in bytes

        public string FileType { get; set; } // MIME type of the file

    }
}
