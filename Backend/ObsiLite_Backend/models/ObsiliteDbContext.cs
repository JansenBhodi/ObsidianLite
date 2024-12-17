using Microsoft.EntityFrameworkCore;
namespace ObsiLite_Backend.models
{
    public partial class ObsiliteDbContext : DbContext
    {
        public ObsiliteDbContext(DbContextOptions<ObsiliteDbContext> options) 
            : base(options)
        {

        }

        public virtual DbSet<Note> Note { get; set; }
        public virtual DbSet<Folder> Folder { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)  
        {
            modelBuilder.Entity<Note>(entity =>
            {
                entity.HasKey(k => k.Id);
            });
            modelBuilder.Entity<Folder>(entity =>
            {
                entity.HasKey(k => k.Id);
            });

            OnModelCreatingPartial(modelBuilder);    
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
