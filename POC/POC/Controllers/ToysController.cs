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
        public async Task<ActionResult> Toys()
        {
            var result = await _toysService.GetToysAsync();

            if (result is null)
            {
                return NotFound();
            }

            return Ok(result); 
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
                await _toysService.CreateToyAsync(toy);
                return Ok("Toy saved succesfully");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            //TODO:We can move this into the else of the res variable instead
            try
            {
                var res = await _toysService.DeleteToyAsync(id);

                if (res)
                {
                    return Ok("Toy deleted successfully");
                }
                //TODO:If the result was not succeded this should be a not found as well, Bad request should be something wrong in the coming data
                //This migh be an 
                return NotFound();
            }
            catch (Exception e)
            {
                //TODO: I changed the bad request to an internal server error here
                return StatusCode(500,e.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Toys toy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var res = await _toysService.UpdateToyAsync(toy);

                if (res)
                {
                    return Ok("Toy updated successfully");
                }

                return NotFound();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
