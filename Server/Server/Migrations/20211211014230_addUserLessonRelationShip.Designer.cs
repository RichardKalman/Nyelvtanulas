// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Server.Data;

namespace Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20211211014230_addUserLessonRelationShip")]
    partial class addUserLessonRelationShip
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.12");

            modelBuilder.Entity("Server.Entities.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Gender")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastActive")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("BLOB");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Server.Entities.Lesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Level")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("Server.Entities.LessonWord", b =>
                {
                    b.Property<int>("LessonId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WordId")
                        .HasColumnType("INTEGER");

                    b.HasKey("LessonId", "WordId");

                    b.HasIndex("WordId");

                    b.ToTable("LessonWords");
                });

            modelBuilder.Entity("Server.Entities.UserLesson", b =>
                {
                    b.Property<int>("LessonId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("AppUserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("LessonId", "AppUserId");

                    b.HasIndex("AppUserId");

                    b.ToTable("UserLesson");
                });

            modelBuilder.Entity("Server.Entities.Word", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("EnglishWord")
                        .HasColumnType("TEXT");

                    b.Property<string>("HungaryWord")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Words");
                });

            modelBuilder.Entity("Server.Entities.LessonWord", b =>
                {
                    b.HasOne("Server.Entities.Lesson", "Lesson")
                        .WithMany("Words")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Server.Entities.Word", "Word")
                        .WithMany("Lessons")
                        .HasForeignKey("WordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");

                    b.Navigation("Word");
                });

            modelBuilder.Entity("Server.Entities.UserLesson", b =>
                {
                    b.HasOne("Server.Entities.AppUser", "AppUser")
                        .WithMany("Lessons")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Server.Entities.Lesson", "Lesson")
                        .WithMany("Users")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("Lesson");
                });

            modelBuilder.Entity("Server.Entities.AppUser", b =>
                {
                    b.Navigation("Lessons");
                });

            modelBuilder.Entity("Server.Entities.Lesson", b =>
                {
                    b.Navigation("Users");

                    b.Navigation("Words");
                });

            modelBuilder.Entity("Server.Entities.Word", b =>
                {
                    b.Navigation("Lessons");
                });
#pragma warning restore 612, 618
        }
    }
}
