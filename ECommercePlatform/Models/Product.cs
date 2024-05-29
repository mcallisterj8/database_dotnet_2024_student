using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommercePlatform.Models;

public class Product {
    [Key]
    public int Id { get; set;}

    [Required]
    public required string ProductName {get; set;}

    public string? Description { get; set;}

    [Required]
    public decimal Price { get; set;}

    [Required]
    public int StockQuantity { get; set; }
    
    [ForeignKey("Category")]
    public int CategoryId { get; set; }
    public virtual Category? Category { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

}