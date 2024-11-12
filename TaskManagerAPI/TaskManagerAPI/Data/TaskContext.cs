using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Models;

namespace TaskManagerAPI.Data
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TaskItem> Tasks { get; set; } 

        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.Address)
                .WithOne(a => a.user)
                .HasForeignKey<Address>(a => a.userId);



            modelBuilder.Entity<User>()
                .HasMany(t => t.TaskItems)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.UserId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
