using System.ComponentModel.DataAnnotations;

namespace DatabaseTask.Core.Domain;

public class Employee
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    public string LastName { get; set; } = string.Empty;

    public Gender Gender { get; set; } = Gender.Unknown;

    public ICollection<Child> Children { get; set; } = new List<Child>();
}
