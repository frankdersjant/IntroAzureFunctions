using AzureFunctionDependencyInjection.Models;

namespace AzureFunctionDependencyInjection.DAL
{
    public interface IFakeProductDB
    {
        Product CreateProduct(string productname);
        Product GetProductById(int id);
        IEnumerable<Product> GetProducts();
    }
}
