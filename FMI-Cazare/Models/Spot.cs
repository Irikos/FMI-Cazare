using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMI_Cazare.Models
{
    public class SpotModel
    {
        [Key]
        public long SpotId { get; set; }

        //[Required]
        //public long RoomId { get; set; }

        //[ForeignKey("RoomId")]
        //public RoomModel Room { get; set; }

        [Required]
        public long UserId { get; set; }

        [ForeignKey("UserId")]
        public UserModel User { get; set; }
        
        public enum SpotStatus : byte { Unknown = 0, Free = 1, Occupied = 2, Reserved = 3 }

        [Required, DefaultValue(SpotStatus.Free)]
        public SpotStatus Status { get; set; }

        public DateTime DateCheckIn { get; set; }

        public DateTime DateCheckOut { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public DateTime DateDeleted { get; set; }
    }
}
