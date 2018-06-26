using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMI_Cazare.Models
{
    public class MessageModel
    {
        [Key]
        public long MessageId { get; set; }

        [Required]
        public long FormId { get; set; }

        [ForeignKey("FormId")]
        public FormModel Form { get; set; }

        [Required]
        public long SenderId { get; set; }

        [ForeignKey("SenderId")]
        public UserModel Sender { get; set; }

        [Required]
        public long ReceiverId { get; set; }

        [ForeignKey("ReceiverId")]
        public UserModel Receiver { get; set; }

        public enum MessageType : byte { Unknown = 0 }

        [DefaultValue(MessageType.Unknown)]
        public MessageType Type { get; set; }

        public string Text { get; set; }

        public DateTime DateSent { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public DateTime DateDeleted { get; set; }
    }
}
