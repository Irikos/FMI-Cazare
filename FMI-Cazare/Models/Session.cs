using System;
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

        public enum SessionStatus: byte { Unknown = 0 }

        [Required, DefaultValue(SessionStatus.Unknown)]
        public SessionStatus Status { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public DateTime DateDeleted { get; set; }
    }
}
