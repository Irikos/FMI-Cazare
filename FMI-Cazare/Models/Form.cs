using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FMI_Cazare.Models
{
    public class FormModel
    {
        [Key]
        public long FormId { get; set; }

        [Required]
        public long SessionId { get; set; }

        [ForeignKey("SessionId")]
        public SessionModel Session { get; set; }

        [Required]
        public long UserId { get; set; }

        [ForeignKey("UserId")]
        public UserModel User { get; set; }

        public enum FormState : byte
        {
            [Description("Unknown")] Unknown = 0,
            [Description("Saved")] Saved = 1,
            [Description("Sent")] Sent = 2,
            [Description("Approved")] Approved = 3,
            [Description("Rejected")] Rejected = 4
        }
        public List<RoomatePreferenceModel> RoomatePreferenceModels { get; set; }

        public List<DormPreferenceModel> DormPreferenceModel { get; set; }


        [Required, DefaultValue(FormState.Unknown)]
        public FormState State { get; set; }

        public string StateDescription
            => State.ToString();

        public bool IsContinuity { get; set; }

        public bool IsSocial { get; set; }

        public int SocialPoints { get; set; }

        public int Score { get; set; }

        public DateTime DateSent { get; set; }

        public String Observations { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public DateTime DateModified { get; set; }

        [Required]
        public DateTime DateDeleted { get; set; }
    }
}
