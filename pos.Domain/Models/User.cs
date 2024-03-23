using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace posServices.Domain.Models;

[Table("User")]
public partial class User
{
    [Key]
    [StringLength(50)]
    public string Username { get; set; } = null!;

    [StringLength(50)]
    public string Password { get; set; } = null!;

    [InverseProperty("UsernameNavigation")]
    public virtual ICollection<TransaksiPenjualan> TransaksiPenjualans { get; set; } = new List<TransaksiPenjualan>();

    [ForeignKey("Username")]
    [InverseProperty("Usernames")]
    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
