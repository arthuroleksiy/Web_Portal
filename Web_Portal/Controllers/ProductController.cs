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
    public class ProductController : ControllerBase
    {
        IProductService ProductService { get; }
        public ProductController(IProductService productService)
        {
            this.ProductService = productService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductDTO>> GetAllResuts()
        {
            try
            {
                var result = ProductService.GetAll().ToArray();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductById(int id)
        {
            try
            {
                var result = await ProductService.GetByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] ProductDTO productDTO)
        {

            try
            {
                if (productDTO == null)
                {
                    return BadRequest("Customer object is null");
                }

                await ProductService.AddAsync(productDTO);
                return Ok(productDTO);
                // return CreatedAtRoute("Product", new { id = productDTO.ProductId }, productDTO);
                

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await ProductService.DeleteByIdAsync(id);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }

        }
    }
}
