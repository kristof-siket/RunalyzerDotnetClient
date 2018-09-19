using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RunalyzerCLI.Model
{
    public partial class sportsdirectorsystemContext : DbContext
    {
        public sportsdirectorsystemContext()
        {
        }

        public sportsdirectorsystemContext(DbContextOptions<sportsdirectorsystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AnalyzerResults> AnalyzerResults { get; set; }
        public virtual DbSet<Competitions> Competitions { get; set; }
        public virtual DbSet<CompetitionsDistances> CompetitionsDistances { get; set; }
        public virtual DbSet<Distances> Distances { get; set; }
        public virtual DbSet<Levels> Levels { get; set; }
        public virtual DbSet<Migrations> Migrations { get; set; }
        public virtual DbSet<Results> Results { get; set; }
        public virtual DbSet<Sports> Sports { get; set; }
        public virtual DbSet<Teams> Teams { get; set; }
        public virtual DbSet<TrainingPlans> TrainingPlans { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        // Unable to generate entity type for table 'password_resets'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=;database=sportsdirectorsystem");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnalyzerResults>(entity =>
            {
                entity.HasKey(e => e.AresultId);

                entity.ToTable("analyzer_results");

                entity.HasIndex(e => e.AresultResult)
                    .HasName("analyzer_results_aresult_result_foreign");

                entity.Property(e => e.AresultId).HasColumnName("aresult_id");

                entity.Property(e => e.AresultKilometers).HasColumnName("aresult_kilometers");

                entity.Property(e => e.AresultPulse)
                    .HasColumnName("aresult_pulse")
                    .HasColumnType("double(8,2) unsigned");

                entity.Property(e => e.AresultResult).HasColumnName("aresult_result");

                entity.Property(e => e.AresultTimestamp)
                    .HasColumnName("aresult_timestamp")
                    .HasColumnType("double(8,2) unsigned");

                entity.HasOne(d => d.AresultResultNavigation)
                    .WithMany(p => p.AnalyzerResults)
                    .HasForeignKey(d => d.AresultResult)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("analyzer_results_aresult_result_foreign");
            });

            modelBuilder.Entity<Competitions>(entity =>
            {
                entity.HasKey(e => e.CompId);

                entity.ToTable("competitions");

                entity.HasIndex(e => e.CompPromoter)
                    .HasName("competitions_comp_promoter_foreign");

                entity.HasIndex(e => e.CompSport)
                    .HasName("competitions_comp_sport_foreign");

                entity.Property(e => e.CompId).HasColumnName("comp_id");

                entity.Property(e => e.CompDate)
                    .HasColumnName("comp_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CompLocation)
                    .IsRequired()
                    .HasColumnName("comp_location")
                    .HasColumnType("varchar(191)");

                entity.Property(e => e.CompName)
                    .IsRequired()
                    .HasColumnName("comp_name")
                    .HasColumnType("varchar(191)");

                entity.Property(e => e.CompPromoter).HasColumnName("comp_promoter");

                entity.Property(e => e.CompSport).HasColumnName("comp_sport");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");

                entity.HasOne(d => d.CompPromoterNavigation)
                    .WithMany(p => p.Competitions)
                    .HasForeignKey(d => d.CompPromoter)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("competitions_comp_promoter_foreign");

                entity.HasOne(d => d.CompSportNavigation)
                    .WithMany(p => p.Competitions)
                    .HasForeignKey(d => d.CompSport)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("competitions_comp_sport_foreign");
            });

            modelBuilder.Entity<CompetitionsDistances>(entity =>
            {
                entity.ToTable("competitions_distances");

                entity.HasIndex(e => e.CompetitionId)
                    .HasName("competitions_distances_competition_id_foreign");

                entity.HasIndex(e => e.DistanceId)
                    .HasName("competitions_distances_distance_id_foreign");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CompetitionId).HasColumnName("competition_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.DistanceId).HasColumnName("distance_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");

                entity.HasOne(d => d.Competition)
                    .WithMany(p => p.CompetitionsDistances)
                    .HasForeignKey(d => d.CompetitionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("competitions_distances_competition_id_foreign");

                entity.HasOne(d => d.Distance)
                    .WithMany(p => p.CompetitionsDistances)
                    .HasForeignKey(d => d.DistanceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("competitions_distances_distance_id_foreign");
            });

            modelBuilder.Entity<Distances>(entity =>
            {
                entity.HasKey(e => e.DistanceId);

                entity.ToTable("distances");

                entity.HasIndex(e => e.MultiId)
                    .HasName("distances_multi_id_foreign");

                entity.HasIndex(e => e.SportId)
                    .HasName("distances_sport_id_foreign");

                entity.Property(e => e.DistanceId).HasColumnName("distance_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.DistanceKilometers)
                    .HasColumnName("distance_kilometers")
                    .HasColumnType("double(8,2) unsigned");

                entity.Property(e => e.DistanceName)
                    .HasColumnName("distance_name")
                    .HasColumnType("varchar(191)");

                entity.Property(e => e.MultiId).HasColumnName("multi_id");

                entity.Property(e => e.SportId).HasColumnName("sport_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");

                entity.HasOne(d => d.Multi)
                    .WithMany(p => p.DistancesMulti)
                    .HasForeignKey(d => d.MultiId)
                    .HasConstraintName("distances_multi_id_foreign");

                entity.HasOne(d => d.Sport)
                    .WithMany(p => p.DistancesSport)
                    .HasForeignKey(d => d.SportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("distances_sport_id_foreign");
            });

            modelBuilder.Entity<Levels>(entity =>
            {
                entity.HasKey(e => e.LevelId);

                entity.ToTable("levels");

                entity.Property(e => e.LevelId).HasColumnName("level_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.LevelDesc)
                    .HasColumnName("level_desc")
                    .HasColumnType("longtext");

                entity.Property(e => e.LevelNum).HasColumnName("level_num");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");
            });

            modelBuilder.Entity<Migrations>(entity =>
            {
                entity.ToTable("migrations");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Batch)
                    .HasColumnName("batch")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Migration)
                    .IsRequired()
                    .HasColumnName("migration")
                    .HasColumnType("varchar(191)");
            });

            modelBuilder.Entity<Results>(entity =>
            {
                entity.HasKey(e => e.ResultId);

                entity.ToTable("results");

                entity.HasIndex(e => e.ResultAthlete)
                    .HasName("results_result_athlete_foreign");

                entity.HasIndex(e => e.ResultCompetition)
                    .HasName("results_result_competition_foreign");

                entity.HasIndex(e => e.ResultDistance)
                    .HasName("results_result_distance_foreign");

                entity.HasIndex(e => e.ResultMultisport)
                    .HasName("results_result_multisport_foreign");

                entity.HasIndex(e => e.ResultSport)
                    .HasName("results_result_sport_foreign");

                entity.Property(e => e.ResultId).HasColumnName("result_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.Disqualified)
                    .HasColumnName("disqualified")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.ResultAthlete).HasColumnName("result_athlete");

                entity.Property(e => e.ResultCompetition).HasColumnName("result_competition");

                entity.Property(e => e.ResultDistance).HasColumnName("result_distance");

                entity.Property(e => e.ResultMultisport).HasColumnName("result_multisport");

                entity.Property(e => e.ResultSport).HasColumnName("result_sport");

                entity.Property(e => e.ResultTime)
                    .HasColumnName("result_time")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");

                entity.HasOne(d => d.ResultAthleteNavigation)
                    .WithMany(p => p.Results)
                    .HasForeignKey(d => d.ResultAthlete)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("results_result_athlete_foreign");

                entity.HasOne(d => d.ResultCompetitionNavigation)
                    .WithMany(p => p.Results)
                    .HasForeignKey(d => d.ResultCompetition)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("results_result_competition_foreign");

                entity.HasOne(d => d.ResultDistanceNavigation)
                    .WithMany(p => p.Results)
                    .HasForeignKey(d => d.ResultDistance)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("results_result_distance_foreign");

                entity.HasOne(d => d.ResultMultisportNavigation)
                    .WithMany(p => p.ResultsResultMultisportNavigation)
                    .HasForeignKey(d => d.ResultMultisport)
                    .HasConstraintName("results_result_multisport_foreign");

                entity.HasOne(d => d.ResultSportNavigation)
                    .WithMany(p => p.ResultsResultSportNavigation)
                    .HasForeignKey(d => d.ResultSport)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("results_result_sport_foreign");
            });

            modelBuilder.Entity<Sports>(entity =>
            {
                entity.HasKey(e => e.SportId);

                entity.ToTable("sports");

                entity.HasIndex(e => e.SportName)
                    .HasName("sports_sport_name_unique")
                    .IsUnique();

                entity.Property(e => e.SportId).HasColumnName("sport_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.Multisport)
                    .IsRequired()
                    .HasColumnName("multisport")
                    .HasColumnType("varchar(191)");

                entity.Property(e => e.SportDesc)
                    .HasColumnName("sport_desc")
                    .HasColumnType("longtext");

                entity.Property(e => e.SportName)
                    .IsRequired()
                    .HasColumnName("sport_name")
                    .HasColumnType("varchar(191)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");
            });

            modelBuilder.Entity<Teams>(entity =>
            {
                entity.HasKey(e => e.TeamId);

                entity.ToTable("teams");

                entity.Property(e => e.TeamId).HasColumnName("team_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.TeamLocation)
                    .HasColumnName("team_location")
                    .HasColumnType("varchar(191)");

                entity.Property(e => e.TeamName)
                    .IsRequired()
                    .HasColumnName("team_name")
                    .HasColumnType("varchar(191)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");
            });

            modelBuilder.Entity<TrainingPlans>(entity =>
            {
                entity.HasKey(e => e.TpId);

                entity.ToTable("training_plans");

                entity.HasIndex(e => e.TpCreator)
                    .HasName("training_plans_tp_creator_foreign");

                entity.HasIndex(e => e.TpDistance)
                    .HasName("training_plans_tp_distance_foreign");

                entity.HasIndex(e => e.TpLevel)
                    .HasName("training_plans_tp_level_foreign");

                entity.HasIndex(e => e.TpSport)
                    .HasName("training_plans_tp_sport_foreign");

                entity.Property(e => e.TpId).HasColumnName("tp_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.TpCreator).HasColumnName("tp_creator");

                entity.Property(e => e.TpDesc)
                    .HasColumnName("tp_desc")
                    .HasColumnType("longtext");

                entity.Property(e => e.TpDistance).HasColumnName("tp_distance");

                entity.Property(e => e.TpFilepath)
                    .HasColumnName("tp_filepath")
                    .HasColumnType("varchar(191)");

                entity.Property(e => e.TpLevel).HasColumnName("tp_level");

                entity.Property(e => e.TpName)
                    .IsRequired()
                    .HasColumnName("tp_name")
                    .HasColumnType("varchar(191)");

                entity.Property(e => e.TpSport).HasColumnName("tp_sport");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");

                entity.HasOne(d => d.TpCreatorNavigation)
                    .WithMany(p => p.TrainingPlans)
                    .HasForeignKey(d => d.TpCreator)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("training_plans_tp_creator_foreign");

                entity.HasOne(d => d.TpDistanceNavigation)
                    .WithMany(p => p.TrainingPlans)
                    .HasForeignKey(d => d.TpDistance)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("training_plans_tp_distance_foreign");

                entity.HasOne(d => d.TpLevelNavigation)
                    .WithMany(p => p.TrainingPlans)
                    .HasForeignKey(d => d.TpLevel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("training_plans_tp_level_foreign");

                entity.HasOne(d => d.TpSportNavigation)
                    .WithMany(p => p.TrainingPlans)
                    .HasForeignKey(d => d.TpSport)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("training_plans_tp_sport_foreign");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Email)
                    .HasName("users_email_unique")
                    .IsUnique();

                entity.HasIndex(e => e.TeamId)
                    .HasName("users_team_id_foreign");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnName("date_of_birth")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("varchar(191)");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasColumnType("varchar(191)");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasColumnType("varchar(191)");

                entity.Property(e => e.Location)
                    .HasColumnName("location")
                    .HasColumnType("varchar(191)");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasColumnType("varchar(191)");

                entity.Property(e => e.RememberToken)
                    .HasColumnName("remember_token")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TeamId).HasColumnName("team_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("users_team_id_foreign");
            });
        }
    }
}
