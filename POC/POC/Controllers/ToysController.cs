using Microsoft.AspNetCore.Mvc;
using POC_Models.Models;
using POC_Services.Contracts;
using System;
using System.Threading.Tasks;

namespace POC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToysController : ControllerBase
    {
        private readonly IToysService _toysService;
        public ToysController(IToysService toysService)
        {
            _toysService = toysService;
        }

        [HttpGet("ToysList")]
        public async Task<IActionResult> Toys()
        {
            try
            {
                return Ok(await _toysService.GetToysAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Save([FromBody] Toys toy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                await _toysService.CreateToy(toy);
                return Ok("Toy saved succesfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            try
            {
                var res = await _toysService.DeleteToy(id);

                if (res)
                {
                    return Ok("Toy deleted successfully");
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Toys toy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (toy.Id == 0)
            {
                return NotFound();
            }

            try
            {
                var res = await _toysService.UpdateToy(toy);

                if (res)
                {
                    return Ok("Toy updated successfully");
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
