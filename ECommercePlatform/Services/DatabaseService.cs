
using ECommercePlatform.Interfaces;
using ECommercePlatform.Models;

namespace ECommercePlatform.Services;

public class DatabaseService : IDatabaseService
{
    public Task AddCategory(Category category)
    {
        throw new NotImplementedException();
    }

    public Task AddCustomer(Customer customer)
    {
        throw new NotImplementedException();
    }

    public Task AddMultipleCustomersAsync(IEnumerable<Customer> customers)
    {
        throw new NotImplementedException();
    }

    public Task AddOrder(Order order)
    {
        throw new NotImplementedException();
    }

    public Task AddOrderItem(OrderItem orderItem)
    {
        throw new NotImplementedException();
    }

    public Task AddProduct(Product product)
    {
        throw new NotImplementedException();
    }

    public Task DeleteCustomer(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Category>> GetAllCategoriesWithProducts()
    {
        throw new NotImplementedException();
    }

    public Task<List<Customer>> GetAllCustomers()
    {
        throw new NotImplementedException();
    }

    public Task<List<Order>> GetAllOrdersWithItems()
    {
        throw new NotImplementedException();
    }

    public Task<List<Product>> GetAllProductsInCategory(int categoryId)
    {
        throw new NotImplementedException();
    }

    public Task<Customer?> GetCustomerById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Order?> UpdateOrder(Order orderDetails)
    {
        throw new NotImplementedException();
    }
}
