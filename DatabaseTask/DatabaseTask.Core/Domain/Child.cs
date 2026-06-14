using System.ComponentModel.DataAnnotations;

namespace DatabaseTask.Core.Domain;

public class Child
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;

    public Guid EmployeeId { get; set; }

    public Employee Employee { get; set; } = null!;
}
