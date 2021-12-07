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


        public DataContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder
                .Entity<Lesson>()
                .HasMany(x => x.Words)
                .WithMany(x => x.Lessons)
                .UsingEntity(x => x.ToTable("LessonWords"));


            /*
             * 
             * modelBuilder
    .Entity<Post>()
    .HasMany(p => p.Tags)
    .WithMany(p => p.Posts)
    .UsingEntity(j => j.ToTable("PostTags"));*/
        }
    }
}
