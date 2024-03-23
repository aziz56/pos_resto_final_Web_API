using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace posServices.Domain.Models;

[Table("MasterMenu")]
public partial class MasterMenu
{
    [Key]
    [Column("id_menu")]
    public int IdMenu { get; set; }

    [Column("nama_menu")]
    [StringLength(50)]
    public string? NamaMenu { get; set; }

    [Column("harga_menu", TypeName = "decimal(18, 2)")]
    public decimal? HargaMenu { get; set; }

    [Column("deskripsi_menu")]
    [StringLength(100)]
    public string? DeskripsiMenu { get; set; }

    [InverseProperty("IdMenuNavigation")]
    public virtual ICollection<TransaksiDetailPenjualan> TransaksiDetailPenjualans { get; set; } = new List<TransaksiDetailPenjualan>();

    [InverseProperty("IdMenuNavigation")]
    public virtual ICollection<TransaksiReservasi> TransaksiReservasis { get; set; } = new List<TransaksiReservasi>();
}
