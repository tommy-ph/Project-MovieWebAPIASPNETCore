﻿// <auto-generated />
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
    [Migration("20230228133841_InitDataSeedUpdateLink")]
    partial class InitDataSeedUpdateLink
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
                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.HasKey("MovieId", "CharacterId");

                    b.HasIndex("CharacterId");

                    b.ToTable("CharacterMovie");

                    b.HasData(
                        new
                        {
                            MovieId = 1,
                            CharacterId = 1
                        },
                        new
                        {
                            MovieId = 2,
                            CharacterId = 1
                        },
                        new
                        {
                            MovieId = 3,
                            CharacterId = 1
                        },
                        new
                        {
                            MovieId = 4,
                            CharacterId = 1
                        },
                        new
                        {
                            MovieId = 1,
                            CharacterId = 2
                        },
                        new
                        {
                            MovieId = 2,
                            CharacterId = 2
                        },
                        new
                        {
                            MovieId = 3,
                            CharacterId = 2
                        },
                        new
                        {
                            MovieId = 4,
                            CharacterId = 2
                        });
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
                            Alias = "Newt",
                            FullName = "Thomas Brodie",
                            Gender = "Male",
                            Picture = "https://flxt.tmsimg.com/assets/294818_v9_bc.jpg"
                        },
                        new
                        {
                            CharacterId = 2,
                            Alias = "Minho",
                            FullName = "Ki Hong Lee",
                            Gender = "Male",
                            Picture = "https://static.wikia.nocookie.net/vsbattles/images/a/a7/Minho.jpg/revision/latest?cb=20191010095625"
                        },
                        new
                        {
                            CharacterId = 3,
                            Alias = "Aragorn",
                            FullName = "Aragorn II Elessar",
                            Gender = "Male",
                            Picture = "https://static.wikia.nocookie.net/jadensadventures/images/4/43/Aragorn3.jpg/revision/latest?cb=20140114165013"
                        },
                        new
                        {
                            CharacterId = 4,
                            Alias = "Galadriel",
                            FullName = "Galadriel Stineman",
                            Gender = "Male",
                            Picture = "https://cdn.vox-cdn.com/thumbor/o9vHcxXd56YpUuoysEaC3YsVKco=/1400x1050/filters:format(jpeg)/cdn.vox-cdn.com/uploads/chorus_asset/file/23981590/RPAZ_S1_UT_210709_GRAMAT_00291_R2.jpg"
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
                            Director = "Peter Jackson",
                            FranchiseId = 1,
                            Genre = "Action",
                            Picture = "https://nosomosnonos.com/wp-content/uploads/2022/08/A7A70911-8905-4347-BE36-387C8E2E094B.jpeg",
                            Title = "The Lords of the Ring",
                            Trailer = "https://www.youtube.com/watch?v=uYnQDsaxHZU",
                            Year = 2022
                        },
                        new
                        {
                            MovieId = 2,
                            Director = "Matt Reeves",
                            FranchiseId = 2,
                            Genre = "Action",
                            Picture = "https://www.thebatman.com/images/share.jpg",
                            Title = "Bat Man",
                            Trailer = "https://www.youtube.com/watch?v=lpeeXtsATYo",
                            Year = 2020
                        },
                        new
                        {
                            MovieId = 3,
                            Director = "Sam Raimi",
                            FranchiseId = 2,
                            Genre = "Action",
                            Picture = "https://m.media-amazon.com/images/M/MV5BYTk3MDljOWQtNGI2My00OTEzLTlhYjQtOTQ4ODM2MzUwY2IwXkEyXkFqcGdeQXVyNTIzOTk5ODM@._V1_FMjpg_UX1000_.jpg",
                            Title = "Spider Man",
                            Trailer = "https://www.youtube.com/watch?v=iaD2f2O9wGk",
                            Year = 2020
                        },
                        new
                        {
                            MovieId = 4,
                            Director = "Wes Ball",
                            FranchiseId = 1,
                            Genre = "Action",
                            Picture = "https://d2iltjk184xms5.cloudfront.net/uploads/photo/file/327788/7560e35531bfc0aedca67ebde8156d6b-cure-poster.jpg",
                            Title = "Maze Runner",
                            Trailer = "https://www.youtube.com/watch?v=FPZ3cWWnB_g",
                            Year = 2018
                        });
                });

            modelBuilder.Entity("CharacterMovie", b =>
                {
                    b.HasOne("Project_MovieWebAPIASPNETCore.Models.Domain.Character", null)
                        .WithMany()
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project_MovieWebAPIASPNETCore.Models.Domain.Movie", null)
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Project_MovieWebAPIASPNETCore.Models.Domain.Movie", b =>
                {
                    b.HasOne("Project_MovieWebAPIASPNETCore.Models.Domain.Franchise", "Franchise")
                        .WithMany("Movies")
                        .HasForeignKey("FranchiseId")
                        .OnDelete(DeleteBehavior.SetNull);

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
