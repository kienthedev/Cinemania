﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SelfProjectDataAccess.Models;

#nullable disable

namespace SelfProjectDataAccess.Migrations
{
    [DbContext(typeof(SelfProjectContext))]
    partial class SelfProjectContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ActorAward", b =>
                {
                    b.Property<int>("ActorId")
                        .HasColumnType("int");

                    b.Property<int>("AwardId")
                        .HasColumnType("int");

                    b.HasKey("ActorId", "AwardId");

                    b.HasIndex("AwardId");

                    b.ToTable("ActorAwards", (string)null);
                });

            modelBuilder.Entity("ActorMovie", b =>
                {
                    b.Property<int>("ActorId")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.HasKey("ActorId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("ActorMovies", (string)null);
                });

            modelBuilder.Entity("DirectorAward", b =>
                {
                    b.Property<int>("DirectorId")
                        .HasColumnType("int");

                    b.Property<int>("AwardId")
                        .HasColumnType("int");

                    b.HasKey("DirectorId", "AwardId");

                    b.HasIndex("AwardId");

                    b.ToTable("DirectorAwards", (string)null);
                });

            modelBuilder.Entity("DirectorMovie", b =>
                {
                    b.Property<int>("DirectorId")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.HasKey("DirectorId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("DirectorMovies", (string)null);
                });

            modelBuilder.Entity("DirectorNews", b =>
                {
                    b.Property<int>("DirectorId")
                        .HasColumnType("int");

                    b.Property<int>("NewsId")
                        .HasColumnType("int");

                    b.HasKey("DirectorId", "NewsId");

                    b.HasIndex("NewsId");

                    b.ToTable("DirectorNews", (string)null);
                });

            modelBuilder.Entity("MovieGenre", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.HasKey("MovieId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("MovieGenres", (string)null);
                });

            modelBuilder.Entity("MovieLanguage", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.HasKey("MovieId", "LanguageId");

                    b.HasIndex("LanguageId");

                    b.ToTable("MovieLanguages", (string)null);
                });

            modelBuilder.Entity("MovieTag", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.HasKey("MovieId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("MovieTags", (string)null);
                });

            modelBuilder.Entity("SelfProjectDataAccess.Models.Actor", b =>
                {
                    b.Property<int>("ActorId")
                        .HasColumnType("int");

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Biography")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Images")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ActorId");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("SelfProjectDataAccess.Models.Award", b =>
                {
                    b.Property<int>("AwardId")
                        .HasColumnType("int");

                    b.Property<int?>("ActorId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("DirectorId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("MovieId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("Year")
                        .HasColumnType("datetime");

                    b.HasKey("AwardId");

                    b.HasIndex("ActorId");

                    b.HasIndex("DirectorId");

                    b.HasIndex("MovieId");

                    b.ToTable("Awards");
                });

            modelBuilder.Entity("SelfProjectDataAccess.Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MovieId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("ReplyTo")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Time")
                        .HasColumnType("datetime");

                    b.Property<int?>("UserId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("CommentId");

                    b.HasIndex("MovieId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("SelfProjectDataAccess.Models.Director", b =>
                {
                    b.Property<int>("DirectorId")
                        .HasColumnType("int");

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Biography")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Images")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("DirectorId");

                    b.ToTable("Directors");
                });

            modelBuilder.Entity("SelfProjectDataAccess.Models.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GenreName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("GenreId");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("SelfProjectDataAccess.Models.Language", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("IsoCode")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("SelfProjectDataAccess.Models.Movie", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<decimal?>("BoxOffice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Plot")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Poster")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Production")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rated")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime?>("ReleasedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Trailer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Website")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MovieId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("SelfProjectDataAccess.Models.News", b =>
                {
                    b.Property<int>("NewsId")
                        .HasColumnType("int");

                    b.Property<int?>("ActorId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DatePublished")
                        .HasColumnType("datetime");

                    b.Property<int?>("DirectorId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("MovieId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("NewsId");

                    b.HasIndex("ActorId");

                    b.HasIndex("DirectorId");

                    b.HasIndex("MovieId");

                    b.ToTable("News");
                });

            modelBuilder.Entity("SelfProjectDataAccess.Models.Rate", b =>
                {
                    b.Property<int>("RateId")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<decimal?>("NumericRating")
                        .HasColumnType("decimal(5,2)");

                    b.Property<DateTime?>("Time")
                        .HasColumnType("datetime");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("RateId");

                    b.HasIndex("MovieId");

                    b.HasIndex("UserId");

                    b.ToTable("Rates");
                });

            modelBuilder.Entity("SelfProjectDataAccess.Models.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TagName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("TagId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("SelfProjectDataAccess.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool?>("Gender")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("ProfileImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Type")
                        .HasColumnType("bit");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SelfProjectDataAccess.Models.UserInteraction", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Timestamp")
                        .HasColumnType("datetime");

                    b.HasKey("UserId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("UserInteractions");
                });

            modelBuilder.Entity("SelfProjectDataAccess.Models.Writer", b =>
                {
                    b.Property<int>("WriterId")
                        .HasColumnType("int");

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Biography")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Images")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("WriterId");

                    b.ToTable("Writers");
                });

            modelBuilder.Entity("WriterMovie", b =>
                {
                    b.Property<int>("WriterId")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.HasKey("WriterId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("WriterMovies", (string)null);
                });

            modelBuilder.Entity("ActorAward", b =>
                {
                    b.HasOne("SelfProjectDataAccess.Models.Actor", null)
                        .WithMany()
                        .HasForeignKey("ActorId")
                        .IsRequired()
                        .HasConstraintName("FK_ActorAwards_Actor");

                    b.HasOne("SelfProjectDataAccess.Models.Award", null)
                        .WithMany()
                        .HasForeignKey("AwardId")
                        .IsRequired()
                        .HasConstraintName("FK_ActorAwards_Award");
                });

            modelBuilder.Entity("ActorMovie", b =>
                {
                    b.HasOne("SelfProjectDataAccess.Models.Actor", null)
                        .WithMany()
                        .HasForeignKey("ActorId")
                        .IsRequired()
                        .HasConstraintName("FK_ActorMovies_Actor");

                    b.HasOne("SelfProjectDataAccess.Models.Movie", null)
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .IsRequired()
                        .HasConstraintName("FK_ActorMovies_Movie");
                });

            modelBuilder.Entity("DirectorAward", b =>
                {
                    b.HasOne("SelfProjectDataAccess.Models.Award", null)
                        .WithMany()
                        .HasForeignKey("AwardId")
                        .IsRequired()
                        .HasConstraintName("FK_DirectorAwards_Award");

                    b.HasOne("SelfProjectDataAccess.Models.Director", null)
                        .WithMany()
                        .HasForeignKey("DirectorId")
                        .IsRequired()
                        .HasConstraintName("FK_DirectorAwards_Director");
                });

            modelBuilder.Entity("DirectorMovie", b =>
                {
                    b.HasOne("SelfProjectDataAccess.Models.Director", null)
                        .WithMany()
                        .HasForeignKey("DirectorId")
                        .IsRequired()
                        .HasConstraintName("FK_DirectorMovies_Director");

                    b.HasOne("SelfProjectDataAccess.Models.Movie", null)
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .IsRequired()
                        .HasConstraintName("FK_DirectorMovies_Movie");
                });

            modelBuilder.Entity("DirectorNews", b =>
                {
                    b.HasOne("SelfProjectDataAccess.Models.Director", null)
                        .WithMany()
                        .HasForeignKey("DirectorId")
                        .IsRequired()
                        .HasConstraintName("FK_DirectorNews_Director");

                    b.HasOne("SelfProjectDataAccess.Models.News", null)
                        .WithMany()
                        .HasForeignKey("NewsId")
                        .IsRequired()
                        .HasConstraintName("FK_DirectorNews_News");
                });

            modelBuilder.Entity("MovieGenre", b =>
                {
                    b.HasOne("SelfProjectDataAccess.Models.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .IsRequired()
                        .HasConstraintName("FK_MovieGenres_Genre");

                    b.HasOne("SelfProjectDataAccess.Models.Movie", null)
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .IsRequired()
                        .HasConstraintName("FK_MovieGenres_Movie");
                });

            modelBuilder.Entity("MovieLanguage", b =>
                {
                    b.HasOne("SelfProjectDataAccess.Models.Language", null)
                        .WithMany()
                        .HasForeignKey("LanguageId")
                        .IsRequired()
                        .HasConstraintName("FK_MovieLanguages_Language");

                    b.HasOne("SelfProjectDataAccess.Models.Movie", null)
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .IsRequired()
                        .HasConstraintName("FK_MovieLanguages_Movie");
                });

            modelBuilder.Entity("MovieTag", b =>
                {
                    b.HasOne("SelfProjectDataAccess.Models.Movie", null)
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .IsRequired()
                        .HasConstraintName("FK_MovieTags_Movie");

                    b.HasOne("SelfProjectDataAccess.Models.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagId")
                        .IsRequired()
                        .HasConstraintName("FK_MovieTags_Tag");
                });

            modelBuilder.Entity("SelfProjectDataAccess.Models.Award", b =>
                {
                    b.HasOne("SelfProjectDataAccess.Models.Actor", "Actor")
                        .WithMany("AwardsNavigation")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Award_Actor");

                    b.HasOne("SelfProjectDataAccess.Models.Director", "Director")
                        .WithMany("Awards")
                        .HasForeignKey("DirectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Award_Director");

                    b.HasOne("SelfProjectDataAccess.Models.Movie", "Movie")
                        .WithMany("Awards")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Award_Movie");

                    b.Navigation("Actor");

                    b.Navigation("Director");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("SelfProjectDataAccess.Models.Comment", b =>
                {
                    b.HasOne("SelfProjectDataAccess.Models.Movie", "Movie")
                        .WithMany("Comments")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Comment_Movie");

                    b.HasOne("SelfProjectDataAccess.Models.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Comment_User");

                    b.Navigation("Movie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SelfProjectDataAccess.Models.News", b =>
                {
                    b.HasOne("SelfProjectDataAccess.Models.Actor", "Actor")
                        .WithMany("News")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_News_Actor");

                    b.HasOne("SelfProjectDataAccess.Models.Director", "Director")
                        .WithMany("NewsNavigation")
                        .HasForeignKey("DirectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_News_Director");

                    b.HasOne("SelfProjectDataAccess.Models.Movie", "Movie")
                        .WithMany("News")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_News_Movie");

                    b.Navigation("Actor");

                    b.Navigation("Director");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("SelfProjectDataAccess.Models.Rate", b =>
                {
                    b.HasOne("SelfProjectDataAccess.Models.Movie", "Movie")
                        .WithMany("Rates")
                        .HasForeignKey("MovieId")
                        .IsRequired()
                        .HasConstraintName("FK_Rate_Movie");

                    b.HasOne("SelfProjectDataAccess.Models.User", "User")
                        .WithMany("Rates")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_Rate_User");

                    b.Navigation("Movie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SelfProjectDataAccess.Models.UserInteraction", b =>
                {
                    b.HasOne("SelfProjectDataAccess.Models.Movie", "Movie")
                        .WithMany("UserInteractions")
                        .HasForeignKey("MovieId")
                        .IsRequired()
                        .HasConstraintName("FK_UserInteractions_Movie");

                    b.HasOne("SelfProjectDataAccess.Models.User", "User")
                        .WithMany("UserInteractions")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_UserInteractions_User");

                    b.Navigation("Movie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WriterMovie", b =>
                {
                    b.HasOne("SelfProjectDataAccess.Models.Movie", null)
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .IsRequired()
                        .HasConstraintName("FK_WriterMovies_Movie");

                    b.HasOne("SelfProjectDataAccess.Models.Writer", null)
                        .WithMany()
                        .HasForeignKey("WriterId")
                        .IsRequired()
                        .HasConstraintName("FK_WriterMovies_Writer");
                });

            modelBuilder.Entity("SelfProjectDataAccess.Models.Actor", b =>
                {
                    b.Navigation("AwardsNavigation");

                    b.Navigation("News");
                });

            modelBuilder.Entity("SelfProjectDataAccess.Models.Director", b =>
                {
                    b.Navigation("Awards");

                    b.Navigation("NewsNavigation");
                });

            modelBuilder.Entity("SelfProjectDataAccess.Models.Movie", b =>
                {
                    b.Navigation("Awards");

                    b.Navigation("Comments");

                    b.Navigation("News");

                    b.Navigation("Rates");

                    b.Navigation("UserInteractions");
                });

            modelBuilder.Entity("SelfProjectDataAccess.Models.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Rates");

                    b.Navigation("UserInteractions");
                });
#pragma warning restore 612, 618
        }
    }
}
