using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EcartAPI.Data;
using EcartAPI.Models;

namespace EcartAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Customers1
        //[HttpGet]
        //public async Task<IActionResult> Index()
        //{
        //    var data = _context.Customers.ToListAsync();
        //    if (data == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(data);
        //}

        //// GET: Customers1/Details/5
        
        //[HttpGet("{id}")]
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var customers = await _context.Customers
        //        .FirstOrDefaultAsync(m => m.CustomerId == id);
        //    if (customers == null)
        //    {
        //        return NotFound();
        //    }

        //    var data = customers;
        //    return Ok(data);
        //}

        // POST: Customers1/Create
      //  [HttpPost("createcustomer")]
        
        //public async Task<ActionResult<Customers>> Create([FromBody] Customers customers)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(customers);
        //        await _context.SaveChangesAsync();
        //        return Ok(customers);
        //    }
        //    return BadRequest();
        //}

        [HttpPost("Createcustomer")]
        public async Task<ActionResult<Customers>> PostCustomer([FromBody] Customers customers)
        {
            try
            {
                if (customers == null)
                {
                    return BadRequest("Invalid customer data.");
                }
                foreach (var order in customers.Orders)
                {
                    var existingProduct = await _context.Products.FindAsync(order.Product.ProductId);
                    if (existingProduct == null)
                    {
                        return BadRequest($"Product with ID {order.Product.ProductId} does not exist.");
                    }
                    order.Product = existingProduct;
                }
                _context.Customers.Add(customers);
                await _context.SaveChangesAsync();
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Ok(customers);
        }





        //[HttpPost]
        //public async Task<IActionResult> Edit(int id, [FromBody] Customers customers)
        //{
        //    if (id != customers.CustomerId)
        //    {
        //        return NotFound();
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(customers);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!CustomersExists(customers.CustomerId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return Ok(customers);
        //    }
        //    return BadRequest();
        //}

        //private bool CustomersExists(int customerId)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
