namespace Reboot.DB.Domain.Entities;

public class PhoneFabric
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public string? ProducerCountry { get; set; }
    
};