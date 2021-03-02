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
    public class CategoryController : Controller
    {
        ICategoryService CategoryService { get; }
        public CategoryController(ICategoryService categoryService)
        {
            this.CategoryService = categoryService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<CategoryDTO>> GetAllResuts()
        {
            try
            {
                var result = CategoryService.GetAll().ToArray();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
