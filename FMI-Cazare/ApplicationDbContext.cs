using FMI_Cazare.Models;
using Microsoft.EntityFrameworkCore;

namespace FMI_Cazare
{
    public class ApplicationDbContext : DbContext
    {
        public static DbContextOptions<ApplicationDbContext> DefaultContextOptions = null;

        public static ApplicationDbContext Default
        {
            get => new ApplicationDbContext(DefaultContextOptions);
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<UserModel> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<DocumentModel> Documents { get; set; }

        public DbSet<DormCategoryModel> DormCategories { get; set; }

        public DbSet<DormModel> Dorms { get; set; }

        public DbSet<DormPreferenceModel> DormPreferences { get; set; }

        public DbSet<FormModel> Forms { get; set; }

        public DbSet<MessageModel> Messages { get; set; }

        public DbSet<NotificationModel> Notifications { get; set; }

        public DbSet<RoomatePreferenceModel> RoomatePreferences { get; set; }

        public DbSet<RoomModel> Rooms { get; set; }
        
        public DbSet<SessionModel> Sessions { get; set; }

        public DbSet<SpotModel> Spots { get; set; }

        public DbSet<HistoryModel> Histories { get; set; }
    }
}
