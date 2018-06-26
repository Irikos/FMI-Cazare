using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMI_Cazare.Models
{
    public class DocumentModel
    {
        [Key]
        public long DocumentId { get; set; }

        [Required]
        public long FormId { get; set; }

        [ForeignKey("FormId")]
        public FormModel Form { get; set; }

        public string Name { get; set; }

        public string Link { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public DateTime DateDeleted { get; set; }
    }
}
