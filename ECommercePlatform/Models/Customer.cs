
using System.ComponentModel.DataAnnotations;

namespace ECommercePlatform.Models;

public class Customer {
    [Key]
    public int Id { get; set;}

    public string? FirstName {get; set;}

    public string? LastName {get; set;}

    [Required]
    public required string Email {get; set;}

    public string? Address {get; set;}

    public string? PhoneNumber {get; set;}

    public virtual ICollection<Order> Orders {get; set;} = new List<Order>();
}
