using ECommercePlatform.Data;
using ECommercePlatform.Models;

namespace ECommercePlatform.Services;
public class SeedingService {
    private readonly ApplicationDbContext _context;

    public SeedingService(ApplicationDbContext context) {
        _context = context;
    }

    public void SeedDatabase() {
        if (_context.Customers.Any() || _context.Products.Any() || _context.Categories.Any() || _context.Orders.Any()) {
            return; // Database has already been seeded
        }

        // Create Categories
        var electronics = new Category { CategoryName = "Electronics", Description = "Electronic gadgets and devices" };
        var books = new Category { CategoryName = "Books", Description = "Books and literature" };

        _context.Categories.AddRange(electronics, books);
        _context.SaveChanges();

        // Create Products
        var phone = new Product { ProductName = "Smartphone", Description = "Latest model smartphone", Price = 699, StockQuantity = 50, Category = electronics };
        var laptop = new Product { ProductName = "Laptop", Description = "High-performance laptop", Price = 999, StockQuantity = 30, Category = electronics };
        var novel = new Product { ProductName = "Novel", Description = "Bestselling novel", Price = 19.99M, StockQuantity = 100, Category = books };

        _context.Products.AddRange(phone, laptop, novel);
        _context.SaveChanges();

        // Create Customers
        var customer1 = new Customer { FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", Address = "123 Main St", PhoneNumber = "123-456-7890" };
        var customer2 = new Customer { FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", Address = "456 Elm St", PhoneNumber = "987-654-3210" };

        _context.Customers.AddRange(customer1, customer2);
        _context.SaveChanges();

        // Create Orders
        var order1 = new Order { OrderDate = DateTime.Now, TotalAmount = 718.99M, Customer = customer1 };
        var order2 = new Order { OrderDate = DateTime.Now, TotalAmount = 1018, Customer = customer2 };

        _context.Orders.AddRange(order1, order2);
        _context.SaveChanges();

        // Create OrderItems
        var orderItem1 = new OrderItem { Order = order1, Product = phone, Quantity = 1, UnitPrice = 699 };
        var orderItem2 = new OrderItem { Order = order1, Product = novel, Quantity = 1, UnitPrice = 19.99M };
        var orderItem3 = new OrderItem { Order = order2, Product = laptop, Quantity = 1, UnitPrice = 999 };
        var orderItem4 = new OrderItem { Order = order2, Product = novel, Quantity = 1, UnitPrice = 19.99M };

        _context.OrderItems.AddRange(orderItem1, orderItem2, orderItem3, orderItem4);
        _context.SaveChanges();
    }
}
