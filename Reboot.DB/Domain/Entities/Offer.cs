using System.ComponentModel.DataAnnotations;

namespace Reboot.DB.Domain.Entities;

public class Offer
{
    [Key]
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
}