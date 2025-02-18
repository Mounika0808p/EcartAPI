using EcartAPI.Data;
using EcartAPI.Models;
using EcartAPI.Services.Interface;

namespace EcartAPI.Services
{
    public class InsertCustomerDataService : IInsertCustomerDataService
    {
         private readonly ApplicationDbContext _context;

        public InsertCustomerDataService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddCustomerDetails(Customers customers)
        {
            // Add customer details to the database
            _context.Customers.Add(customers);
            await _context.SaveChangesAsync(); // Save changes to the database
        }

        public async Task UpdateCustomerDetails(Customers customers)
        {
            // Update customer details in the database
            //_context.Customers.Update(customers);
            //await _context.SaveChangesAsync(); // Save changes to the database
        }



    }
}
