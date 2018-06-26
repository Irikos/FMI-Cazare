using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMI_Cazare.Models
{
    public class NotificationModel
    {
        [Key]
        public long NotificationId { get; set; }

        [Required]
        public long SessionId { get; set; }

        [ForeignKey("SessionId")]
        public SessionModel Session { get; set; }

        [Required] 
        public long SenderId { get; set; }

        [ForeignKey("SenderId")]
        public UserModel Sender { get; set; }

        [Required]
        public long ReceiverId { get; set; }

        [ForeignKey("ReceiverId")]
        public UserModel Receiver { get; set; }

        public enum NotificationType { Unknown = 0 }

        [DefaultValue(NotificationType.Unknown)]
        public NotificationType Type { get; set; }

        public string Text { get; set; }

        public DateTime DateSent { get; set; }

        public int Priority { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public DateTime DateDeleted { get; set; }
    }
}
