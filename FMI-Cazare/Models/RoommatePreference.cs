using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMI_Cazare.Models
{
    public class RoomatePreferenceIdModel
    {
        [Key]
        public long RoommatePreferenceId { get; set; }

        [Required]
        public long UserId { get; set; }

        [ForeignKey("UserId")]
        public UserModel User { get; set; }

        [Required]
        public long FormId { get; set; }

        [ForeignKey("FormId")]
        public FormModel Form { get; set; }

        [Required]
        public long StudentId { get; set; }

        [ForeignKey("StudentId")]
        public UserModel Student { get; set; }
        
        public int Priority { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public DateTime DateDeleted { get; set; }
    }
}
