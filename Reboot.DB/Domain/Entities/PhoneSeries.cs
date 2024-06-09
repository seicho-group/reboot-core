using System.ComponentModel.DataAnnotations;

namespace Reboot.DB.Domain.Entities;

public class PhoneSeries
{
    [Key]
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public PhoneFabric? Fabric { get; set; }
}