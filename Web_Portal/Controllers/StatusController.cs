using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Portal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : Controller
    {
        IProductStatusService StatusService { get; }
        public StatusController(IProductStatusService StatusService)
        {
            this.StatusService = StatusService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<ProductStatusDTO>> GetAllResuts()
        {
            try
            {
                var result = StatusService.GetAll().ToArray();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
