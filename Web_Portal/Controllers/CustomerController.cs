using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Portal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomerService CustomerService { get; }
        public CustomerController(ICustomerService CustomerService)
        {
            this.CustomerService = CustomerService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CustomerDTO>> GetAllResuts()
        {
            try
            {
                var result = CustomerService.GetAll().ToArray();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] CustomerDTO customerDTO)
        {

            try
            {
                if (customerDTO == null)
                {
                    return BadRequest("Customer object is null");
                }

                await CustomerService.AddAsync(customerDTO);

                return CreatedAtRoute("CustomerId", new { id = customerDTO.CustomerId }, customerDTO);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
