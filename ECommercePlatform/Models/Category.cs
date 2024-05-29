using System.ComponentModel.DataAnnotations;

namespace ECommercePlatform.Models;

public class Category {
    [Key]
    public int Id { get; set;}

    [Required]
    public required string CategoryName { get; set;}

    public string? Description { get; set;}
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}