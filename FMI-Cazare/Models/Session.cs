using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FMI_Cazare.Models
{
    public class Session
    {
        [Key]
        public long SessionId { get; set; }

        [ForeignKey("SessionId")]
        public long IdSession { get; set; }

        [Required]
        public DateTime DateStart { get; set; }

        [Required]
        public DateTime Deadline { get; set; }

        [Required]
        public DateTime DateEnd { get; set; }

        public enum SessionStatus: byte { Unknown = 0 }

        [Required, DefaultValue(SessionStatus.Unknown)]
        public SessionStatus Status { get; set; }

        [Required]
        public DateTime DateCheckIn { get; set; }

        [Required]
        public DateTime DateCheckOut { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public DateTime DateModified { get; set; }

        [Required]
        public DateTime DateDeleted { get; set; }
    }
}
