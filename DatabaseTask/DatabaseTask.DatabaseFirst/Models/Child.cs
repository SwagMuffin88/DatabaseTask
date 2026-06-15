using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DatabaseTask.DatabaseFirst.Models;

[Index("EmployeeId", Name = "IX_Children_EmployeeId")]
public partial class Child
{
    [Key]
    public Guid Id { get; set; }

    [StringLength(100)]
    public string FirstName { get; set; } = null!;

    public Guid EmployeeId { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("Children")]
    public virtual Employee Employee { get; set; } = null!;
}
