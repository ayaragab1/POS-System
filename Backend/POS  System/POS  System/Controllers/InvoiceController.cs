using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoice _db;

        public InvoiceController(IInvoice db)
        {
            _db = db;
        }

        [HttpGet("GetAllInvoices")]
        public async Task<IActionResult> GetAllInvoices()
        {

            if (!ModelState.IsValid)
                return BadRequest();
            var result = await _db.GetAll();
            return Ok(result);
        }

        [HttpPost("AddInvoice")]
        public async Task<IActionResult> AddProduct(InvoiceDetailsModel Inv)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var result = await _db.Add(Inv);
            return Ok(result);
        }
        [HttpGet("GetInvoicebyId")]
        public async Task<IActionResult> GetInvoiceByID(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var result = await _db.GetInvoiceByID(id);
            return Ok(result);
        }

        [HttpDelete("DeleteInvoiceDetails")]
        public async Task<IActionResult> DeleteInvoice(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var result = await _db.DeleteInvoiceDetails(id);
            return Ok(result);
        }
    }
}
