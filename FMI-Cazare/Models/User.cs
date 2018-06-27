using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMI_Cazare.Models
{
    public class UserModel
    {
        [Key]
        public long UserId { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public long Uid { get; set; }

        public string Cnp { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string IcSerie { get; set; }

        public string IcNumber { get; set; }

        public string BirthPlace { get; set; }

        public string Address { get; set; }

        public string FatherFirstName { get; set; }

        public string MotherFirstName { get; set; }

        public string Specialization { get; set; }

        public string Year { get; set; }

        public enum UserGender : byte { Unknown = 0, Male = 1, Female = 2, Other = 3 }

        [DefaultValue(UserGender.Unknown)]
        public UserGender Gender { get; set; }

        public enum UserRole : byte { Unknown = 0, Admin = 1, Management = 2, Student = 3, Teacher = 4 }

        [DefaultValue(UserRole.Unknown)]
        public UserRole Role { get; set; }

        public String Token { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public DateTime DateDeleted { get; set; }
    }
}
