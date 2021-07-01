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

                    b.Property<byte>("Category")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint")
                        .HasDefaultValue((byte)1);

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
                            Id = new Guid("64c73e39-08f4-47e6-bf8f-2b704bbc93ad"),
                            Category = (byte)0,
                            Content = "Today is a good day.",
                            CreatedOn = new DateTime(2021, 7, 1, 5, 26, 48, 398, DateTimeKind.Utc).AddTicks(8520),
                            UserId = new Guid("2eb554c1-28cb-4629-97da-960753f13234")
                        });
                });

            modelBuilder.Entity("Emotional.Data.Entities.Emotion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte>("Category")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint")
                        .HasDefaultValue((byte)1);

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
                            Id = new Guid("e037bbf0-088e-46cc-9349-f30e6feeac9c"),
                            Category = (byte)1,
                            CreatedOn = new DateTime(2021, 7, 1, 5, 26, 48, 398, DateTimeKind.Utc).AddTicks(6616),
                            Percentage = 70f,
                            UserId = new Guid("2eb554c1-28cb-4629-97da-960753f13234")
                        });
                });

            modelBuilder.Entity("Emotional.Data.Entities.Music", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte>("Category")
                        .HasColumnType("tinyint");

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
                            Id = new Guid("98339f19-04e0-4622-8e37-f60d8d3608b7"),
                            Category = (byte)1,
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
                            Id = new Guid("2eb554c1-28cb-4629-97da-960753f13234"),
                            Email = "Emotional@gmail.com",
                            HashPassword = "AQAAAAEAACcQAAAAEBdVbiJm41NS4ZQTD1CMGRX7PzhoEVBUXtPGEwtGPha57Ox56hUh6MvIKIJg/qjhOw==",
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