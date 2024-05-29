using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommercePlatform.Models;

public class OrderItem {
    [Key]
    public int Id { get; set;}

    [Required]
    public int Quantity { get; set; }

    [Required]
    public decimal UnitPrice { get; set; }

    [ForeignKey("Order")]
    public int OrderId { get; set; }
    public virtual Order? Order { get; set; }

    [ForeignKey("Product")]
    public int ProductId { get; set; }
    public virtual Product? Product { get; set; }
}