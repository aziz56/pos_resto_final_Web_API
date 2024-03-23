using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace posServices.Domain.Models;

[PrimaryKey("IdPembayaran", "IdPenjualan")]
[Table("Pembayaran")]
public partial class Pembayaran
{
    [Key]
    [Column("id_pembayaran")]
    public int IdPembayaran { get; set; }

    [Key]
    [Column("id_penjualan")]
    public int IdPenjualan { get; set; }

    [Column("metode_pembayaran")]
    [StringLength(50)]
    public string? MetodePembayaran { get; set; }

    [Column("amount", TypeName = "decimal(18, 2)")]
    public decimal? Amount { get; set; }

    [Column("kembalian", TypeName = "decimal(18, 2)")]
    public decimal? Kembalian { get; set; }

    [Column("tanggal_pembayaran")]
    public DateOnly? TanggalPembayaran { get; set; }

    [Column("waktu_pembayaran")]
    [Precision(6)]
    public TimeOnly? WaktuPembayaran { get; set; }

    [Column("keterangan")]
    [StringLength(50)]
    public string? Keterangan { get; set; }
}
