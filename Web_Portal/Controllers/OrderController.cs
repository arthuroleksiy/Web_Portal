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
    public class OrderController : ControllerBase
    {
        IOrderService OrderService { get; }
        public OrderController(IOrderService OrderService)
        {
            this.OrderService = OrderService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<OrderDTO>> GetAllResuts()
        {
            try
            {
                var result = OrderService.GetAll().ToArray();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] OrderDTO orderDTO)
        {

            try
            {
                if (orderDTO == null)
                {
                    return BadRequest("Customer object is null");
                }

                await OrderService.AddAsync(orderDTO);
                return Ok(orderDTO);


            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
