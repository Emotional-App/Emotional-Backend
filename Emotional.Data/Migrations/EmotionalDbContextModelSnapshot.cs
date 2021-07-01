﻿// <auto-generated />
using System;
using Emotional.Data.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Emotional.Data.Migrations
{
    [DbContext(typeof(EmotionalDbContext))]
    partial class EmotionalDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Emotional.Data.Entities.Diary", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Diaries");

                    b.HasData(
                        new
                        {
                            Id = new Guid("66a9ef91-ca1c-4eaa-812a-4e0f166c1053"),
                            Category = "HAPPY",
                            Content = "Today is a good day.",
                            CreatedOn = new DateTime(2021, 7, 1, 12, 5, 24, 272, DateTimeKind.Utc).AddTicks(1753),
                            UserId = new Guid("3a5a4a27-b0cc-4c17-bf1f-a97b79888c9c")
                        });
                });

            modelBuilder.Entity("Emotional.Data.Entities.Emotion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<float>("Percentage")
                        .HasColumnType("real");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Emotions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b3033c02-7849-451a-b34c-3d2306f6401d"),
                            Category = "PEACEFUL",
                            CreatedOn = new DateTime(2021, 7, 1, 12, 5, 24, 272, DateTimeKind.Utc).AddTicks(80),
                            Percentage = 70f,
                            UserId = new Guid("3a5a4a27-b0cc-4c17-bf1f-a97b79888c9c")
                        });
                });

            modelBuilder.Entity("Emotional.Data.Entities.Music", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MusicUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Musics");

                    b.HasData(
                        new
                        {
                            Id = new Guid("76850e5c-38e9-4ea7-92e3-046e0a12bada"),
                            Category = "PEACEFUL",
                            MusicUrl = "https://freesound.org/data/previews/554/554415_2975501-lq.mp3",
                            Name = "Peaceful-sound-001"
                        });
                });

            modelBuilder.Entity("Emotional.Data.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AvatarUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("HashPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3a5a4a27-b0cc-4c17-bf1f-a97b79888c9c"),
                            Email = "Emotional@gmail.com",
                            HashPassword = "AQAAAAEAACcQAAAAEH2W6nOQOkg6ugEx9xy9jfJ2/cYMxcT3Oav12rY4cr/EmFqSqT+LvTVURl0solClZQ==",
                            Name = "Emotional"
                        });
                });

            modelBuilder.Entity("Emotional.Data.Entities.Diary", b =>
                {
                    b.HasOne("Emotional.Data.Entities.User", "User")
                        .WithMany("Diaries")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Emotional.Data.Entities.Emotion", b =>
                {
                    b.HasOne("Emotional.Data.Entities.User", "User")
                        .WithMany("Emotions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Emotional.Data.Entities.User", b =>
                {
                    b.Navigation("Diaries");

                    b.Navigation("Emotions");
                });
#pragma warning restore 612, 618
        }
    }
}
