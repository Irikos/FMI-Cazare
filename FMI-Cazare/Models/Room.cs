using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMI_Cazare.Models
{
    public class RoomModel
    {
        [Key]
        public long RoomId { get; set; }

        //[Required]
        //public long DormId { get; set; }

        //[ForeignKey("DormId")]
        //public DormModel Dorm { get; set; }


        public IEnumerable<SpotModel> Spots { get; set; }

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

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public DateTime DateDeleted { get; set; }
    }
}
