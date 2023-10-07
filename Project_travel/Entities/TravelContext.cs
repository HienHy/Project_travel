using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Project_travel.Entities;

public partial class TravelContext : DbContext
{
    public TravelContext()
    {
    }

    public TravelContext(DbContextOptions<TravelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<Route> Routes { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<Trip> Trips { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source =localhost,1433;Database=Travel;User Id=sa;Password=Password123@jkl#;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Admins__3214EC07924093C5");

            entity.Property(e => e.Role)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("User_id");

            entity.HasOne(d => d.User).WithMany(p => p.Admins)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Admins__User_id__5535A963");
        });

        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Car__3214EC0713F3164E");

            entity.ToTable("Car");

            entity.Property(e => e.Company)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Route>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Route__3214EC07792B398D");

            entity.ToTable("Route");

            entity.Property(e => e.Code)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.EndTime)
                .HasColumnType("datetime")
                .HasColumnName("End_Time");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.StartTime)
                .HasColumnType("datetime")
                .HasColumnName("Start_Time");
            entity.Property(e => e.Starting)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ticket__3214EC07FF0BB363");

            entity.ToTable("Ticket");

            entity.Property(e => e.Code)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TripId).HasColumnName("Trip_id");
            entity.Property(e => e.UserId).HasColumnName("User_id");

            entity.HasOne(d => d.Trip).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.TripId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ticket__Trip_id__5812160E");

            entity.HasOne(d => d.User).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ticket__User_id__59063A47");
        });

        modelBuilder.Entity<Trip>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Trip__3214EC07B433864B");

            entity.ToTable("Trip");

            entity.Property(e => e.CarId).HasColumnName("Car_id");
            entity.Property(e => e.Code)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.DepatureDate)
                .HasColumnType("date")
                .HasColumnName("Depature_Date");
            entity.Property(e => e.DepatureTime).HasColumnName("Depature_Time");
            entity.Property(e => e.EmptySeat).HasColumnName("Empty_Seat");
            entity.Property(e => e.RouteId).HasColumnName("Route_id");

            entity.HasOne(d => d.Car).WithMany(p => p.Trips)
                .HasForeignKey(d => d.CarId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Trip__Car_id__4F7CD00D");

            entity.HasOne(d => d.Route).WithMany(p => p.Trips)
                .HasForeignKey(d => d.RouteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Trip__Route_id__4E88ABD4");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC0714D7E814");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D105345D3FA9C0").IsUnique();

            entity.Property(e => e.Cccd)
                .HasMaxLength(30)
                .HasColumnName("CCCD");
            entity.Property(e => e.Dob)
                .HasColumnType("date")
                .HasColumnName("DOB");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Fullname).HasMaxLength(255);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(12);
            entity.Property(e => e.Token).HasColumnType("text");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
