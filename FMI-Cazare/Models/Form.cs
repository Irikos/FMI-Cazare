using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMI_Cazare.Models
{
    public class FormModel
    {
        [Key]
        public long FormId { get; set; }

        [Required]
        public long SessionId { get; set; }

        [ForeignKey("SessionId")]
        public SessionModel Session { get; set; }

        [Required]
        public long UserId { get; set; }

        [ForeignKey("UserId")]
        public UserModel User { get; set; }
        
        public enum FormState : byte { Unknown = 0, Saved = 1, Sent = 2, Approved = 3, Rejected = 4 }

        [Required, DefaultValue(FormState.Unknown)]
        public FormState State { get; set; }

        public bool IsContinuity { get; set; }

        public bool IsSocial { get; set; }

        public int SocialPoints { get; set; }

        public int Score { get; set; }

        public DateTime DateSent { get; set; }

        public String Observations { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public DateTime DateModified { get; set; }

        [Required]
        public DateTime DateDeleted { get; set; }
    }
}
