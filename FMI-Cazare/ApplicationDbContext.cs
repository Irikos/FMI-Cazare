using FMI_Cazare.Models;
using Microsoft.EntityFrameworkCore;

namespace FMI_Cazare
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<UserModel> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<FMI_Cazare.Models.DocumentModel> DocumentModel { get; set; }

        public DbSet<FMI_Cazare.Models.DormCategoryModel> DormCategoryModel { get; set; }

        public DbSet<FMI_Cazare.Models.DormModel> DormModel { get; set; }

        public DbSet<FMI_Cazare.Models.DormPreferenceModel> DormPreferenceModel { get; set; }

        public DbSet<FMI_Cazare.Models.FormModel> FormModel { get; set; }

        public DbSet<FMI_Cazare.Models.MessageModel> MessageModel { get; set; }

        public DbSet<FMI_Cazare.Models.NotificationModel> NotificationModel { get; set; }

        public DbSet<FMI_Cazare.Models.RoomatePreferenceModel> RoomatePreferenceModel { get; set; }

        public DbSet<FMI_Cazare.Models.RoomModel> RoomModel { get; set; }

        public DbSet<FMI_Cazare.Models.SessionModel> SessionModel { get; set; }

        public DbSet<FMI_Cazare.Models.SpotModel> SpotModel { get; set; }

        public DbSet<FMI_Cazare.Models.HistoryModel> HistoryModel { get; set; }
    }
}
