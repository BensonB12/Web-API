﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Web_API.Models;

#nullable disable

namespace Web_API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Web_API.Models.BoardGame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("ComplexityAverage")
                        .HasPrecision(4, 2)
                        .HasColumnType("decimal(4,2)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MaxPlayers")
                        .HasColumnType("int");

                    b.Property<int>("MinAge")
                        .HasColumnType("int");

                    b.Property<int>("MinPlayers")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("OwnedUsers")
                        .HasColumnType("int");

                    b.Property<int>("PlayTime")
                        .HasColumnType("int");

                    b.Property<int>("UsersRated")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("BoardGames");
                });

            modelBuilder.Entity("Web_API.Models.BoardGames_Domains", b =>
                {
                    b.Property<int>("BoardgameId")
                        .HasColumnType("int");

                    b.Property<int>("DomainId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("BoardgameId", "DomainId");

                    b.HasIndex("DomainId");

                    b.ToTable("BoardGames_Domains");
                });

            modelBuilder.Entity("Web_API.Models.BoardGames_Mechanics", b =>
                {
                    b.Property<int>("BoardgameId")
                        .HasColumnType("int");

                    b.Property<int>("MechanicId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DomainId")
                        .HasColumnType("int");

                    b.Property<int>("MechanicId1")
                        .HasColumnType("int");

                    b.HasKey("BoardgameId", "MechanicId");

                    b.HasIndex("DomainId");

                    b.HasIndex("MechanicId");

                    b.HasIndex("MechanicId1");

                    b.ToTable("BoardGames_Mechanics");
                });

            modelBuilder.Entity("Web_API.Models.Domain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Domains");
                });

            modelBuilder.Entity("Web_API.Models.Mechanic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Mechanic");
                });

            modelBuilder.Entity("Web_API.Models.BoardGames_Domains", b =>
                {
                    b.HasOne("Web_API.Models.BoardGame", "BoardGame")
                        .WithMany("BoardGames_Domains")
                        .HasForeignKey("BoardgameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Web_API.Models.Domain", "Domain")
                        .WithMany("BoardGames_Domains")
                        .HasForeignKey("DomainId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BoardGame");

                    b.Navigation("Domain");
                });

            modelBuilder.Entity("Web_API.Models.BoardGames_Mechanics", b =>
                {
                    b.HasOne("Web_API.Models.Domain", "Domain")
                        .WithMany()
                        .HasForeignKey("DomainId");

                    b.HasOne("Web_API.Models.BoardGame", "BoardGame")
                        .WithMany("BoardGames_Mechanics")
                        .HasForeignKey("MechanicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Web_API.Models.Mechanic", null)
                        .WithMany("BoardGames_Mechanics")
                        .HasForeignKey("MechanicId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BoardGame");

                    b.Navigation("Domain");
                });

            modelBuilder.Entity("Web_API.Models.BoardGame", b =>
                {
                    b.Navigation("BoardGames_Domains");

                    b.Navigation("BoardGames_Mechanics");
                });

            modelBuilder.Entity("Web_API.Models.Domain", b =>
                {
                    b.Navigation("BoardGames_Domains");
                });

            modelBuilder.Entity("Web_API.Models.Mechanic", b =>
                {
                    b.Navigation("BoardGames_Mechanics");
                });
#pragma warning restore 612, 618
        }
    }
}
