using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DatabaseTask.DatabaseFirst.Models;

[Table("Employee")]
public partial class Employee
{
    [Key]
    public Guid Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int Gender { get; set; }

    [InverseProperty("Employee")]
    public virtual ICollection<Child> Children { get; set; } = new List<Child>();
}
