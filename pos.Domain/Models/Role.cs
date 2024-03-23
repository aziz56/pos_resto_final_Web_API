using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace posServices.Domain.Models;

public partial class Role
{
    [StringLength(50)]
    public string? RoleName { get; set; }

    [Key]
    [Column("RoleID")]
    public int RoleId { get; set; }

    [ForeignKey("RoleId")]
    [InverseProperty("Roles")]
    public virtual ICollection<User> Usernames { get; set; } = new List<User>();
}
