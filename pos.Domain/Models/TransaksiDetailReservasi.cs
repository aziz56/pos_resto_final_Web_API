using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace posServices.Domain.Models;

[Keyless]
[Table("TransaksiDetailReservasi")]
public partial class TransaksiDetailReservasi
{
    [Column("id_detail_reservasi")]
    [StringLength(10)]
    public string? IdDetailReservasi { get; set; }

    [Column("id_reservasi")]
    [StringLength(10)]
    public string? IdReservasi { get; set; }

    [Column("id_meja")]
    [StringLength(10)]
    public string? IdMeja { get; set; }

    [Column("id_menu")]
    [StringLength(10)]
    public string? IdMenu { get; set; }
}
