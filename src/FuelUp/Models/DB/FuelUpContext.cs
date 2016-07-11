using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FuelUp.Models.DB
{
    public partial class FuelUpContext : DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //    optionsBuilder.UseSqlServer(@"Server=MEGAMOZG\SQLEXPRESS;Database=FuelUp;Integrated Security=True;");
        //}

        public FuelUpContext ( DbContextOptions<FuelUpContext> options )
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex");

                entity.Property(e => e.Id).HasMaxLength(450);

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId)
                    .HasName("IX_AspNetUserClaims_UserId");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey })
                    .HasName("PK_AspNetUserLogins");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(450);

                entity.Property(e => e.ProviderKey).HasMaxLength(450);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PK_AspNetUserRoles");

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_AspNetUserRoles_RoleId");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_AspNetUserRoles_UserId");

                entity.Property(e => e.UserId).HasMaxLength(450);

                entity.Property(e => e.RoleId).HasMaxLength(450);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name })
                    .HasName("PK_AspNetUserTokens");

                entity.Property(e => e.UserId).HasMaxLength(450);

                entity.Property(e => e.LoginProvider).HasMaxLength(450);

                entity.Property(e => e.Name).HasMaxLength(450);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex");

                entity.Property(e => e.Id).HasMaxLength(450);

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Cities>(entity =>
            {
                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.Property(e => e.CItyName).HasColumnType("nchar(100)");

                entity.Property(e => e.PhoneCode).HasColumnType("nchar(50)");

                entity.HasOne(d => d.CItyType)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.CItyTypeID)
                    .HasConstraintName("FK_Cities_CityTypes");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.RegionID)
                    .HasConstraintName("FK_Cities_Regions");
            });

            modelBuilder.Entity<CityTypes>(entity =>
            {
                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.Property(e => e.Name).HasColumnType("nchar(100)");
            });

            modelBuilder.Entity<FuelTypes>(entity =>
            {
                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.Property(e => e.FuelName).HasColumnType("nchar(20)");
            });

            modelBuilder.Entity<ObjectTypes>(entity =>
            {
                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.Property(e => e.Type).HasColumnType("nchar(50)");
            });

            modelBuilder.Entity<Operators>(entity =>
            {
                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.Property(e => e.NameEN).HasColumnType("nchar(100)");

                entity.Property(e => e.NameRU).HasColumnType("nchar(100)");
            });

            modelBuilder.Entity<Regions>(entity =>
            {
                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.Property(e => e.NameRU).HasColumnType("nchar(100)");
            });

            modelBuilder.Entity<Roads>(entity =>
            {
                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.Property(e => e.RoadCode1).HasColumnType("nchar(10)");

                entity.Property(e => e.RoadCode2).HasColumnType("nchar(10)");

                entity.Property(e => e.RoadNameEN).HasColumnType("nchar(100)");

                entity.Property(e => e.RoadNameRU).HasColumnType("nchar(100)");
            });

            modelBuilder.Entity<ServiceTypes>(entity =>
            {
                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.Property(e => e.Service).HasColumnType("nchar(50)");
            });

            modelBuilder.Entity<Stations>(entity =>
            {
                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.Property(e => e.Adress).HasColumnType("nchar(150)");

                entity.Property(e => e.DateUpdate).HasColumnType("date");

                entity.Property(e => e.Name).HasColumnType("nchar(100)");

                entity.Property(e => e.OpenHours).HasColumnType("nchar(50)");

                entity.Property(e => e.OperatorName).HasColumnType("nchar(50)");

                entity.Property(e => e.Phone).HasColumnType("nchar(100)");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Stations)
                    .HasForeignKey(d => d.CityID)
                    .HasConstraintName("FK_Stations_Cities");

                entity.HasOne(d => d.Operator)
                    .WithMany(p => p.Stations)
                    .HasForeignKey(d => d.OperatorID)
                    .HasConstraintName("FK_Stations_Operators");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Stations)
                    .HasForeignKey(d => d.RegionID)
                    .HasConstraintName("FK_Stations_Regions");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Stations)
                    .HasForeignKey(d => d.TypeID)
                    .HasConstraintName("FK_Stations_ObjectTypes");
            });

            modelBuilder.Entity<sysdiagrams>(entity =>
            {
                entity.HasKey(e => e.diagram_id)
                    .HasName("PK__sysdiagr__C2B05B61B8E75719");

                entity.HasIndex(e => new { e.principal_id, e.name })
                    .HasName("UK_principal_name")
                    .IsUnique();

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasColumnType("sysname");
            });
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<CityTypes> CityTypes { get; set; }
        public virtual DbSet<FuelTypes> FuelTypes { get; set; }
        public virtual DbSet<ObjectTypes> ObjectTypes { get; set; }
        public virtual DbSet<Operators> Operators { get; set; }
        public virtual DbSet<Regions> Regions { get; set; }
        public virtual DbSet<Roads> Roads { get; set; }
        public virtual DbSet<ServiceTypes> ServiceTypes { get; set; }
        public virtual DbSet<Stations> Stations { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}