using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMI_Cazare.Models
{
    public class DormPreferenceModel
    {
        [Key]
        public long DormPreferenceId { get; set; }

        [Required]
        public long DormId { get; set; }

        [ForeignKey("DormId")]
        public DormModel Dorm { get; set; }

        public int Priority { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public DateTime DateDeleted { get; set; }
    }
}
