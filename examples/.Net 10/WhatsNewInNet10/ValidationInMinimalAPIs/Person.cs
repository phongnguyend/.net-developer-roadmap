using System.ComponentModel.DataAnnotations;

namespace ValidationInMinimalAPIs;

public class Person
{
    [Required]
    public string? FirstName { get; set; }

    public string? LastName { get; set; }
}
