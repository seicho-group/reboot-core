using System.ComponentModel.DataAnnotations;

namespace Reboot.DB.Domain.Entities;

public class PhoneModelModification
{
    [Key]
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public PhoneModel PhoneModel { get; set; }
}