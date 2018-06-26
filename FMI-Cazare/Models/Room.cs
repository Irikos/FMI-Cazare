using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FMI_Cazare.Models
{
    public class Room
    {
        [Key]
        public long RoomId { get; set; }

        [ForeignKey("DormId")]
        public long DormId { get; set; }

        [Required]
        public string RoomNumber { get; set; }

        public enum RoomType : byte { Unknown = 0, Masculin = 1, Feminin = 2 }

        [Required, DefaultValue(RoomType.Unknown)]
        public RoomType Type { get; set; }

        [Required]
        public int SpotsNumerTotal { get; set; }

        [Required]
        public int SpotsNumberFree { get; set; }

        [Required]
        public bool HasBathroom { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public DateTime DateModified { get; set; }

        [Required]
        public DateTime DateDeleted { get; set; }
    }
}
