using System.ComponentModel.DataAnnotations;

namespace Reboot.DB.Domain.Entities;

public class OfferPrice
{
    [Key]
    public required Guid Id { get; set; }
    public required Offer Offer { get; set; }
    public required PhoneModelModification Model { get; set; }
    public required int Price { get; set; }
    public int ReplicaPrice { get; set; }
    public int BudgetReplicaPrice { get; set; }
}