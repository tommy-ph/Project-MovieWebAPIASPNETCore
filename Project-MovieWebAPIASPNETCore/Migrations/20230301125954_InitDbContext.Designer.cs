// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project_MovieWebAPIASPNETCore.Models;

#nullable disable

namespace Project_MovieWebAPIASPNETCore.Migrations
{
    [DbContext(typeof(MovieDBContext))]
    [Migration("20230301125954_InitDbContext")]
    partial class InitDbContext
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CharacterMovie", b =>
                {
                    b.Property<int>("CharactersCharacterId")
                        .HasColumnType("int");

                    b.Property<int>("MoviesMovieId")
                        .HasColumnType("int");

                    b.HasKey("CharactersCharacterId", "MoviesMovieId");

                    b.HasIndex("MoviesMovieId");

                    b.ToTable("CharacterMovie");
                });

            modelBuilder.Entity("Project_MovieWebAPIASPNETCore.Models.Domain.Character", b =>
                {
                    b.Property<int>("CharacterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CharacterId"));

                    b.Property<string>("Alias")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FullName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Gender")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Picture")
                        .HasMaxLength(2055)
                        .HasColumnType("nvarchar(2055)");

                    b.HasKey("CharacterId");

                    b.ToTable("Characters");

                    b.HasData(
                        new
                        {
                            CharacterId = 1,
                            Alias = "HBO",
                            FullName = "David Swax",
                            Gender = "Male",
                            Picture = "PicturLink"
                        },
                        new
                        {
                            CharacterId = 2,
                            Alias = "HBO",
                            FullName = "Sven Swax",
                            Gender = "Female",
                            Picture = "PicturLink"
                        });
                });

            modelBuilder.Entity("Project_MovieWebAPIASPNETCore.Models.Domain.Franchise", b =>
                {
                    b.Property<int>("FranchiseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FranchiseId"));

                    b.Property<string>("Description")
                        .HasMaxLength(3000)
                        .HasColumnType("nvarchar(3000)");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("FranchiseId");

                    b.ToTable("Franchises");

                    b.HasData(
                        new
                        {
                            FranchiseId = 1,
                            Description = "Welcome to GothenburgBIO",
                            Name = "HBOGothernburg"
                        },
                        new
                        {
                            FranchiseId = 2,
                            Description = "Welcome to StockholmBIO",
                            Name = "HBOStockholm"
                        });
                });

            modelBuilder.Entity("Project_MovieWebAPIASPNETCore.Models.Domain.Movie", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MovieId"));

                    b.Property<string>("Director")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("FranchiseId")
                        .HasColumnType("int");

                    b.Property<int?>("FranchisedId")
                        .HasColumnType("int");

                    b.Property<string>("Genre")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Picture")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("Title")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Trailer")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<int?>("Year")
                        .HasColumnType("int");

                    b.HasKey("MovieId");

                    b.HasIndex("FranchiseId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            MovieId = 1,
                            Director = "David",
                            Genre = "Action",
                            Picture = "Link",
                            Title = "The memory",
                            Trailer = "YouTubeLink",
                            Year = 2021
                        },
                        new
                        {
                            MovieId = 2,
                            Director = "John",
                            Genre = "Action",
                            Picture = "Link",
                            Title = "Bat Man",
                            Trailer = "YouTubeLink",
                            Year = 2020
                        });
                });

            modelBuilder.Entity("CharacterMovie", b =>
                {
                    b.HasOne("Project_MovieWebAPIASPNETCore.Models.Domain.Character", null)
                        .WithMany()
                        .HasForeignKey("CharactersCharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project_MovieWebAPIASPNETCore.Models.Domain.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesMovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Project_MovieWebAPIASPNETCore.Models.Domain.Movie", b =>
                {
                    b.HasOne("Project_MovieWebAPIASPNETCore.Models.Domain.Franchise", "Franchise")
                        .WithMany("Movies")
                        .HasForeignKey("FranchiseId");

                    b.Navigation("Franchise");
                });

            modelBuilder.Entity("Project_MovieWebAPIASPNETCore.Models.Domain.Franchise", b =>
                {
                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}
