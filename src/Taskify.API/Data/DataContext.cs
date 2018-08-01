using Taskify.API.Models;
using Microsoft.EntityFrameworkCore;
using Taskify.API.Models.Tasks;

namespace Taskify.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}

        public DbSet<User> Users {get; set;}
        public DbSet<Photo> Photos {get; set;}
        public DbSet<Like> Likes { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<MowLawn> TasksMowLawn { get; set; }
        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Like>()
                .HasKey(k => new {k.LikerId, k.LikeeId});

            builder.Entity<Like>()
                .HasOne(u => u.Likee)
                .WithMany(u => u.Liker)
                .HasForeignKey(u => u.LikerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Like>()
                .HasOne(u => u.Liker)
                .WithMany(u => u.Likee)
                .HasForeignKey(u => u.LikeeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Message>()
                .HasOne(u => u.Sender)
                .WithMany(m => m.MessageSent)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Message>()
                .HasOne(u => u.Recipient)
                .WithMany(m => m.MessageReceived)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Task>()
                .HasKey(k => k.Id);

            builder.Entity<Task>()
                .Property(i => i.AdditionalInformation)
                .IsRequired(false);

            builder.Entity<Task>()
                .HasOne(u => u.Client)
                .WithMany(u => u.Clients)
                .HasForeignKey(u => u.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Task>()
                .HasOne(u => u.Worker)
                .WithMany(u => u.Workers)
                .HasForeignKey(u => u.WorkerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<MowLawn>()
                .ToTable("Tasks.MowLawn")
                .HasKey(k => k.Id);

        }
    }
}