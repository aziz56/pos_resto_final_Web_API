using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace posServices.Domain.Models;

[Table("TransaksiReservasi")]
public partial class TransaksiReservasi
{
    [Key]
    [Column("id_reservasi")]
    public int IdReservasi { get; set; }

    [Column("id_pelanggan")]
    public int? IdPelanggan { get; set; }

    [Column("tanggal_reservasi", TypeName = "datetime")]
    public DateTime? TanggalReservasi { get; set; }

    [Column("jam_reservasi")]
    public TimeOnly? JamReservasi { get; set; }

    [Column("jumlah_orang")]
    public int? JumlahOrang { get; set; }

    [Column("keterangan")]
    [StringLength(50)]
    public string? Keterangan { get; set; }

    [Column("status_reservasi")]
    [StringLength(50)]
    public string? StatusReservasi { get; set; }

    [Column("id_menu")]
    public int? IdMenu { get; set; }

    [Column("id_meja")]
    public int? IdMeja { get; set; }

    [ForeignKey("IdMeja")]
    [InverseProperty("TransaksiReservasis")]
    public virtual MasterMeja? IdMejaNavigation { get; set; }

    [ForeignKey("IdMenu")]
    [InverseProperty("TransaksiReservasis")]
    public virtual MasterMenu? IdMenuNavigation { get; set; }

    [ForeignKey("IdPelanggan")]
    [InverseProperty("TransaksiReservasis")]
    public virtual MasterPelanggan? IdPelangganNavigation { get; set; }

  
}
