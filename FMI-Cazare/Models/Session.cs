using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMI_Cazare.Models
{
    public class SessionModel
    {
        [Key]
        public long SessionId { get; set; }

        //public long IdSession { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        //[ForeignKey("IdSession")]
        //public SessionModel SubSession { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime Deadline { get; set; }

        public DateTime DateEnd { get; set; }

        public enum SessionStatus : byte
        {
            [Description("Unknown")] Unknown = 0,
            [Description("Saved")] Saved = 1,
            [Description("Open")] Open = 2,
            [Description("Closed")] Closed = 3
        }

        [Required, DefaultValue(SessionStatus.Unknown)]
        public SessionStatus Status { get; set; }

        public IEnumerable<DormCategoryModel> DormCategories { get; set; }

        public string StatusDescription
        => Status.ToString();

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public DateTime DateDeleted { get; set; }
    }
}
