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

        public DbSet<UserLesson> UserLesson { get; set; }
        public DbSet<LessonResult> LessonResult { get; set; }

        public DbSet<LessonLessonResult> LessonLessonResults { get; set; } 

        public DbSet<UserLessonResult> UserLessonResults { get; set; }

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

            builder.Entity<UserLesson>().HasKey(sc => new { sc.LessonId, sc.AppUserId });

            builder.Entity<UserLesson>()
                .HasOne<Lesson>(l => l.Lesson)
                .WithMany(l => l.Users)
                .HasForeignKey(l => l.LessonId);

            builder.Entity<UserLesson>()
                .HasOne<AppUser>(l => l.AppUser)
                .WithMany(l => l.Lessons)
                .HasForeignKey(l => l.AppUserId);


            builder.Entity<UserLessonResult>()
                .HasKey(ulr => new { ulr.AppUserId, ulr.LessonResultId });

            builder.Entity<UserLessonResult>()
                .HasOne<LessonResult>(l => l.LessonResult)
                .WithMany(l => l.Users)
                .HasForeignKey(l => l.LessonResultId);

            builder.Entity<UserLessonResult>()
                .HasOne<AppUser>(l => l.AppUser)
                .WithMany(l => l.LessonResults)
                .HasForeignKey(l => l.AppUserId);

            //Lesson -> LessonResult
            builder.Entity<LessonLessonResult>()
                .HasKey(llr => new { llr.LessonResultId, llr.LessonId });

            builder.Entity<LessonLessonResult>()
                .HasOne<LessonResult>(l => l.LessonResult)
                .WithMany(l => l.Lessons)
                .HasForeignKey(l => l.LessonResultId);

            builder.Entity<LessonLessonResult>()
                .HasOne<Lesson>(l => l.Lesson)
                .WithMany(l => l.LessonResults)
                .HasForeignKey(l => l.LessonId);

    

        }
    }
}
