using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FMI_Cazare.Models
{
    public class DormModel
    {
        [Key]
        public long DormId { get; set; }

        //[Required]
        //public long DormCategoryId { get; set; }

        //[ForeignKey("DormCategoryId")]
        //public DormCategoryModel DormCategory { get; set; }

        public IEnumerable<RoomModel> Rooms { get; set; }

        [Required]
        public string Name { get; set; }
        
        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public DateTime DateDeleted { get; set; }
    }
}
