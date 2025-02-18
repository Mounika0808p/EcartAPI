using EcartAPI.Models;

namespace EcartAPI.Services.Interface
{
    public interface IInsertCustomerDataService
    {
        Task AddCustomerDetails(Customers customers);
        Task UpdateCustomerDetails(Customers customers);

    }
}
