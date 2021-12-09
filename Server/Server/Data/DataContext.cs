using Server.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.AspNetCore.Identity;

namespace Server.Data
{
    public class DataContext : DbContext
    {
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<LessonWord> LessonWords { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<LessonWord>().HasKey(sc => new {  sc.LessonId ,sc.WordId });

            builder.Entity<LessonWord>()
                .HasOne<Lesson>(sc => sc.Lesson)
                .WithMany(l => l.Words)
                .HasForeignKey(sc => sc.LessonId);

            builder.Entity<LessonWord>()
                .HasOne<Word>(sc => sc.Word)
                .WithMany(sc => sc.Lessons)
                .HasForeignKey(sc => sc.WordId); 
        }
    }
}
