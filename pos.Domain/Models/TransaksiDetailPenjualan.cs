using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace posServices.Domain.Models;

[Table("TransaksiDetailPenjualan")]
public partial class TransaksiDetailPenjualan
{
    [Column("id_penjualan")]
    public int IdPenjualan { get; set; }

    [Key]
    [Column("id_detailpenjualan")]
    public int IdDetailpenjualan { get; set; }

    [Column("id_menu")]
    public int? IdMenu { get; set; }

    [Column("harga_menu", TypeName = "decimal(18, 2)")]
    public decimal? HargaMenu { get; set; }

    [Column("jumlah_pesasan")]
    public int? JumlahPesasan { get; set; }

    [ForeignKey("IdMenu")]
    [InverseProperty("TransaksiDetailPenjualans")]
    public virtual MasterMenu? IdMenuNavigation { get; set; }

    [ForeignKey("IdPenjualan")]
    [InverseProperty("TransaksiDetailPenjualans")]
    public virtual TransaksiPenjualan IdPenjualanNavigation { get; set; } = null!;
}
