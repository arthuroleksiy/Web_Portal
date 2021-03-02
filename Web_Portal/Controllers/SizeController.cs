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
    public class SizeController : Controller
    {
        IProductSizeService SizeService { get; }
        public SizeController(IProductSizeService SizeService)
        {
            this.SizeService = SizeService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<ProductSizeDTO>> GetAllResuts()
        {
            try
            {
                var result = SizeService.GetAll().ToArray();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
