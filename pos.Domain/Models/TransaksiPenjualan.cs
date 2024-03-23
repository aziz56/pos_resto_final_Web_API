using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace posServices.Domain.Models;

[Table("TransaksiPenjualan")]
[Index("IdPenjualan", Name = "IX_TransaksiPenjualan", IsUnique = true)]
public partial class TransaksiPenjualan
{
    [Key]
    [Column("id_penjualan")]
    public int IdPenjualan { get; set; }

    [Column("tanggal_penjualan")]
    public DateOnly? TanggalPenjualan { get; set; }

    [Column("waktu_penjualan")]
    public TimeOnly? WaktuPenjualan { get; set; }

    [Column("id_pelanggaan")]
    public int? IdPelanggaan { get; set; }

    [Column("id_meja")]
    public int? IdMeja { get; set; }

    [StringLength(50)]
    public string? Username { get; set; }

    [Column("keterangan")]
    [StringLength(50)]
    public string? Keterangan { get; set; }

    [Column("kembalian", TypeName = "decimal(18, 2)")]
    public decimal? Kembalian { get; set; }

    [Column("amount", TypeName = "decimal(18, 2)")]
    public decimal? Amount { get; set; }

    [Column("metode_pembayaran")]
    [StringLength(50)]
    public string? MetodePembayaran { get; set; }

    [Column("total_penjualan", TypeName = "decimal(18, 2)")]
    public decimal? TotalPenjualan { get; set; }

    [ForeignKey("IdMeja")]
    [InverseProperty("TransaksiPenjualans")]
    public virtual MasterMeja? IdMejaNavigation { get; set; }

    [ForeignKey("IdPelanggaan")]
    [InverseProperty("TransaksiPenjualans")]
    public virtual MasterPelanggan? IdPelanggaanNavigation { get; set; }

    [InverseProperty("IdPenjualanNavigation")]
    public virtual ICollection<TransaksiDetailPenjualan> TransaksiDetailPenjualans { get; set; } = new List<TransaksiDetailPenjualan>();

    [ForeignKey("Username")]
    [InverseProperty("TransaksiPenjualans")]
    public virtual User? UsernameNavigation { get; set; }
}
