using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FMI_Cazare.Models
{
    public class Dorm
    {
        [Key]
        public long DormId { get; set; }

        [ForeignKey("DormCategoryId")]
        public long DormCategoryId { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public DateTime DateModified { get; set; }

        [Required]
        public DateTime DateDeleted { get; set; }
    }
}
