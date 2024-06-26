using System.ComponentModel.DataAnnotations;

namespace Reboot.DB.Domain.Entities;

public class PhoneFabric
{
    [Key]
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public string? ProducerCountry { get; set; }
    
};