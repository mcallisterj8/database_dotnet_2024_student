using ECommercePlatform.Models;

namespace ECommercePlatform.Interfaces;

public interface IDatabaseService {
    // Retrieve all customers
    Task<List<Customer>> GetAllCustomers();

    // Retrieve all products in a given category
    Task<List<Product>> GetAllProductsInCategory(int categoryId);

    // Retrieve all categories with their products
    Task<List<Category>> GetAllCategoriesWithProducts();

    // Retrieve all orders with their items
    Task<List<Order>> GetAllOrdersWithItems();

    // Retrieve a customer by ID with their orders
    Task<Customer?> GetCustomerById(int id);

    // Add a new customer
    Task AddCustomer(Customer customer);

    // Add a new product
    Task AddProduct(Product product);

    // Add a new category
    Task AddCategory(Category category);

    // Add a new order
    Task AddOrder(Order order);

    // Add a new order item
    Task AddOrderItem(OrderItem orderItem);

    // Update an order
    Task<Order?> UpdateOrder(Order orderDetails);

    // Delete a customer
    Task DeleteCustomer(int id);

    // Add multiple new customers using AddRangeAsync
    Task AddMultipleCustomersAsync(IEnumerable<Customer> customers);
}