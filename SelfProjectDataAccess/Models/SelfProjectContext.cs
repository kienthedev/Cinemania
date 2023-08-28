using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace SelfProjectDataAccess.Models
{
    public partial class SelfProjectContext : DbContext
    {
        public SelfProjectContext()
        {
        }

        public SelfProjectContext(DbContextOptions<SelfProjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Award> Awards { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Director> Directors { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Rate> Rates { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserInteraction> UserInteractions { get; set; }
        public virtual DbSet<Writer> Writers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                IConfigurationRoot configuration = builder.Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("SelfProject"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>(entity =>
            {
                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.Gender).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Nationality).HasMaxLength(100);

                entity.HasMany(d => d.Awards)
                    .WithMany(p => p.Actors)
                    .UsingEntity<Dictionary<string, object>>(
                        "ActorAward",
                        l => l.HasOne<Award>().WithMany().HasForeignKey("AwardId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ActorAwards_Award"),
                        r => r.HasOne<Actor>().WithMany().HasForeignKey("ActorId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ActorAwards_Actor"),
                        j =>
                        {
                            j.HasKey("ActorId", "AwardId");

                            j.ToTable("ActorAwards");
                        });

                entity.HasMany(d => d.Movies)
                    .WithMany(p => p.Actors)
                    .UsingEntity<Dictionary<string, object>>(
                        "ActorMovie",
                        l => l.HasOne<Movie>().WithMany().HasForeignKey("MovieId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ActorMovies_Movie"),
                        r => r.HasOne<Actor>().WithMany().HasForeignKey("ActorId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ActorMovies_Actor"),
                        j =>
                        {
                            j.HasKey("ActorId", "MovieId");

                            j.ToTable("ActorMovies");
                        });
            });

            modelBuilder.Entity<Award>(entity =>
            {
                entity.Property(e => e.Category).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Year).HasColumnType("datetime");

                entity.HasOne(d => d.Actor)
                    .WithMany(p => p.AwardsNavigation)
                    .HasForeignKey(d => d.ActorId)
                    .HasConstraintName("FK_Award_Actor");

                entity.HasOne(d => d.Director)
                    .WithMany(p => p.Awards)
                    .HasForeignKey(d => d.DirectorId)
                    .HasConstraintName("FK_Award_Director");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Awards)
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("FK_Award_Movie");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.Time).HasColumnType("datetime");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("FK_Comment_Movie");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Comment_User");
            });

            modelBuilder.Entity<Director>(entity =>
            {
                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.Gender).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Nationality).HasMaxLength(100);

                entity.HasMany(d => d.AwardsNavigation)
                    .WithMany(p => p.Directors)
                    .UsingEntity<Dictionary<string, object>>(
                        "DirectorAward",
                        l => l.HasOne<Award>().WithMany().HasForeignKey("AwardId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_DirectorAwards_Award"),
                        r => r.HasOne<Director>().WithMany().HasForeignKey("DirectorId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_DirectorAwards_Director"),
                        j =>
                        {
                            j.HasKey("DirectorId", "AwardId");

                            j.ToTable("DirectorAwards");
                        });

                entity.HasMany(d => d.Movies)
                    .WithMany(p => p.Directors)
                    .UsingEntity<Dictionary<string, object>>(
                        "DirectorMovie",
                        l => l.HasOne<Movie>().WithMany().HasForeignKey("MovieId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_DirectorMovies_Movie"),
                        r => r.HasOne<Director>().WithMany().HasForeignKey("DirectorId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_DirectorMovies_Director"),
                        j =>
                        {
                            j.HasKey("DirectorId", "MovieId");

                            j.ToTable("DirectorMovies");
                        });

                entity.HasMany(d => d.News)
                    .WithMany(p => p.Directors)
                    .UsingEntity<Dictionary<string, object>>(
                        "DirectorNews",
                        l => l.HasOne<News>().WithMany().HasForeignKey("NewsId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_DirectorNews_News"),
                        r => r.HasOne<Director>().WithMany().HasForeignKey("DirectorId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_DirectorNews_Director"),
                        j =>
                        {
                            j.HasKey("DirectorId", "NewsId");

                            j.ToTable("DirectorNews");
                        });
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.Property(e => e.GenreName).HasMaxLength(100);
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.Property(e => e.IsoCode).HasMaxLength(2);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Region).HasMaxLength(100);
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.Property(e => e.BoxOffice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Country).HasMaxLength(100);

                entity.Property(e => e.Rated).HasMaxLength(10);

                entity.Property(e => e.ReleasedDate).HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(255);

                entity.HasMany(d => d.AwardsNavigation)
                    .WithMany(p => p.Movies)
                    .UsingEntity<Dictionary<string, object>>(
                        "MovieAward",
                        l => l.HasOne<Award>().WithMany().HasForeignKey("AwardId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_MovieAwards_Award"),
                        r => r.HasOne<Movie>().WithMany().HasForeignKey("MovieId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_MovieAwards_Movie"),
                        j =>
                        {
                            j.HasKey("MovieId", "AwardId");

                            j.ToTable("MovieAwards");
                        });

                entity.HasMany(d => d.Genres)
                    .WithMany(p => p.Movies)
                    .UsingEntity<Dictionary<string, object>>(
                        "MovieGenre",
                        l => l.HasOne<Genre>().WithMany().HasForeignKey("GenreId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_MovieGenres_Genre"),
                        r => r.HasOne<Movie>().WithMany().HasForeignKey("MovieId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_MovieGenres_Movie"),
                        j =>
                        {
                            j.HasKey("MovieId", "GenreId");

                            j.ToTable("MovieGenres");
                        });

                entity.HasMany(d => d.Languages)
                    .WithMany(p => p.Movies)
                    .UsingEntity<Dictionary<string, object>>(
                        "MovieLanguage",
                        l => l.HasOne<Language>().WithMany().HasForeignKey("LanguageId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_MovieLanguages_Language"),
                        r => r.HasOne<Movie>().WithMany().HasForeignKey("MovieId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_MovieLanguages_Movie"),
                        j =>
                        {
                            j.HasKey("MovieId", "LanguageId");

                            j.ToTable("MovieLanguages");
                        });

                entity.HasMany(d => d.Tags)
                    .WithMany(p => p.Movies)
                    .UsingEntity<Dictionary<string, object>>(
                        "MovieTag",
                        l => l.HasOne<Tag>().WithMany().HasForeignKey("TagId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_MovieTags_Tag"),
                        r => r.HasOne<Movie>().WithMany().HasForeignKey("MovieId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_MovieTags_Movie"),
                        j =>
                        {
                            j.HasKey("MovieId", "TagId");

                            j.ToTable("MovieTags");
                        });
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.Property(e => e.Category).HasMaxLength(50);

                entity.Property(e => e.DatePublished).HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(255);

                entity.HasOne(d => d.Actor)
                    .WithMany(p => p.News)
                    .HasForeignKey(d => d.ActorId)
                    .HasConstraintName("FK_News_Actor");

                entity.HasOne(d => d.Director)
                    .WithMany(p => p.NewsNavigation)
                    .HasForeignKey(d => d.DirectorId)
                    .HasConstraintName("FK_News_Director");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.News)
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("FK_News_Movie");
            });

            modelBuilder.Entity<Rate>(entity =>
            {
                entity.Property(e => e.NumericRating).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Time).HasColumnType("datetime");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Rates)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rate_Movie");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Rates)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rate_User");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.Property(e => e.TagName).HasMaxLength(100);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.Country).HasMaxLength(100);

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.LastName).HasMaxLength(100);

                entity.Property(e => e.Password).HasMaxLength(255);

                entity.Property(e => e.Phone).HasMaxLength(20);
            });

            modelBuilder.Entity<UserInteraction>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.MovieId });

                entity.Property(e => e.Timestamp).HasColumnType("datetime");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.UserInteractions)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserInteractions_Movie");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserInteractions)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserInteractions_User");
            });

            modelBuilder.Entity<Writer>(entity =>
            {
                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.Gender).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Nationality).HasMaxLength(100);

                entity.HasMany(d => d.Movies)
                    .WithMany(p => p.Writers)
                    .UsingEntity<Dictionary<string, object>>(
                        "WriterMovie",
                        l => l.HasOne<Movie>().WithMany().HasForeignKey("MovieId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_WriterMovies_Movie"),
                        r => r.HasOne<Writer>().WithMany().HasForeignKey("WriterId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_WriterMovies_Writer"),
                        j =>
                        {
                            j.HasKey("WriterId", "MovieId");

                            j.ToTable("WriterMovies");
                        });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
