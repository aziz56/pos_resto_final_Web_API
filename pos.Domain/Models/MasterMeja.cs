using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace posServices.Domain.Models;

[Table("MasterMeja")]
public partial class MasterMeja
{
    [Key]
    [Column("id_meja")]
    public int IdMeja { get; set; }

    [Column("no_meja")]
    public int? NoMeja { get; set; }

    [Column("kapasitas_meja")]
    public int? KapasitasMeja { get; set; }

    [Column("status_meja")]
    [StringLength(255)]
    public string? StatusMeja { get; set; }

    [InverseProperty("IdMejaNavigation")]
    public virtual ICollection<TransaksiPenjualan> TransaksiPenjualans { get; set; } = new List<TransaksiPenjualan>();

    [InverseProperty("IdMejaNavigation")]
    public virtual ICollection<TransaksiReservasi> TransaksiReservasis { get; set; } = new List<TransaksiReservasi>();
}
