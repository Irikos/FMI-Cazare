using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FMI_Cazare.Models
{
    public class DormCategoryModel
    {
        [Key]
        public long DormCategoryId { get; set; }

        //[Required]
        //public long SessionId { get; set; }

        //[ForeignKey("SessionId")]
        //public SessionModel Session { get; set; }

        public IEnumerable<DormModel> Dorms { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public DateTime DateDeleted { get; set; }
    }
}
