using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POS__System.Models;
using POS__System.Services.Interface;
using POS__System.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS__System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct _db;

        public ProductController(IProduct db)
        {
            _db = db;
        }

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {

            if (!ModelState.IsValid)
                return BadRequest();
            var result = await _db.GetAll();
            return Ok(result);
        }

        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct(NewProductModel P)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var result = await _db.Add(P);
            return Ok(result);
        }
        [HttpGet("GetProductbyId")]
        public async Task<IActionResult> GetProductbyId(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var result = await _db.GetProductByID(id);
            return Ok(result);
        }

        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var result = await _db.DeleteProduct(id);
            return Ok(result);
        }
    }
}
