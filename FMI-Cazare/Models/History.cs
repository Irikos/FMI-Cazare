using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMI_Cazare.Models
{
    public class HistoryModel
    {
        [Key]
        public long HistoryId { get; set; }

        [Required]
        public long UserId { get; set; }

        [ForeignKey("UserId")]
        public UserModel User { get; set; }

        [Required]
        public long SessionId { get; set; }

        [ForeignKey("SessionId")]
        public SessionModel Session { get; set; }
        
        public string DormCode { get; set; }

        public string RoomCode { get; set; }

        public string SpotCode { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public DateTime DateDeleted { get; set; }
    }
}
