using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace posServices.Domain.Models;

[Table("MasterPelanggan")]
public partial class MasterPelanggan
{
    [Key]
    [Column("id_pelanggan")]
    public int IdPelanggan { get; set; }

    [Column("nama_pelanggan")]
    [StringLength(255)]
    public string? NamaPelanggan { get; set; }

    [Column("no_telp_pelanggan")]
    [StringLength(255)]
    public string? NoTelpPelanggan { get; set; }

    [Column("email_pelanggan")]
    [StringLength(255)]
    public string? EmailPelanggan { get; set; }

    [InverseProperty("IdPelanggaanNavigation")]
    public virtual ICollection<TransaksiPenjualan> TransaksiPenjualans { get; set; } = new List<TransaksiPenjualan>();

    [InverseProperty("IdPelangganNavigation")]
    public virtual ICollection<TransaksiReservasi> TransaksiReservasis { get; set; } = new List<TransaksiReservasi>();
}
