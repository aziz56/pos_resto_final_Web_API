using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace posServices.Domain.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MasterMeja> MasterMejas { get; set; }

    public virtual DbSet<MasterMenu> MasterMenus { get; set; }

    public virtual DbSet<MasterPelanggan> MasterPelanggans { get; set; }

    public virtual DbSet<Pembayaran> Pembayarans { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<TransaksiDetailPenjualan> TransaksiDetailPenjualans { get; set; }

    public virtual DbSet<TransaksiDetailReservasi> TransaksiDetailReservasis { get; set; }

    public virtual DbSet<TransaksiPenjualan> TransaksiPenjualans { get; set; }

    public virtual DbSet<TransaksiReservasi> TransaksiReservasis { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS01;Initial Catalog=pos_resto;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pembayaran>(entity =>
        {
            entity.Property(e => e.IdPembayaran).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.Property(e => e.RoleId).ValueGeneratedNever();
        });

        modelBuilder.Entity<TransaksiDetailPenjualan>(entity =>
        {
            entity.Property(e => e.IdDetailpenjualan).ValueGeneratedNever();

            entity.HasOne(d => d.IdMenuNavigation).WithMany(p => p.TransaksiDetailPenjualans).HasConstraintName("FK_TransaksiDetailPenjualan_MasterMenu");

            entity.HasOne(d => d.IdPenjualanNavigation).WithMany(p => p.TransaksiDetailPenjualans)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TransaksiDetailPenjualan_TransaksiPenjualan");
        });

        modelBuilder.Entity<TransaksiDetailReservasi>(entity =>
        {
            entity.Property(e => e.IdDetailReservasi).IsFixedLength();
            entity.Property(e => e.IdMeja).IsFixedLength();
            entity.Property(e => e.IdMenu).IsFixedLength();
            entity.Property(e => e.IdReservasi).IsFixedLength();
        });

        modelBuilder.Entity<TransaksiPenjualan>(entity =>
        {
            entity.HasOne(d => d.IdMejaNavigation).WithMany(p => p.TransaksiPenjualans).HasConstraintName("FK_TransaksiPenjualan_MasterMeja");

            entity.HasOne(d => d.IdPelanggaanNavigation).WithMany(p => p.TransaksiPenjualans).HasConstraintName("FK_TransaksiPenjualan_MasterPelanggan");

            entity.HasOne(d => d.UsernameNavigation).WithMany(p => p.TransaksiPenjualans).HasConstraintName("FK_TransaksiPenjualan_User");
        });

        modelBuilder.Entity<TransaksiReservasi>(entity =>
        {
            entity.HasKey(e => e.IdReservasi).HasName("PK_Tabel TransaksiReservasi");

            entity.HasOne(d => d.IdMejaNavigation).WithMany(p => p.TransaksiReservasis).HasConstraintName("FK_TransaksiReservasi_MasterMeja");

            entity.HasOne(d => d.IdMenuNavigation).WithMany(p => p.TransaksiReservasis).HasConstraintName("FK_TransaksiReservasi_MasterMenu");

            entity.HasOne(d => d.IdPelangganNavigation).WithMany(p => p.TransaksiReservasis).HasConstraintName("FK_TransaksiReservasi_MasterPelanggan");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasMany(d => d.Roles).WithMany(p => p.Usernames)
                .UsingEntity<Dictionary<string, object>>(
                    "UsersRole",
                    r => r.HasOne<Role>().WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_UsersRoles_Roles"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("Username")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_UsersRoles_User"),
                    j =>
                    {
                        j.HasKey("Username", "RoleId").HasName("PK_UserRoles");
                        j.ToTable("UsersRoles");
                        j.IndexerProperty<string>("Username").HasMaxLength(50);
                        j.IndexerProperty<int>("RoleId").HasColumnName("RoleID");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
