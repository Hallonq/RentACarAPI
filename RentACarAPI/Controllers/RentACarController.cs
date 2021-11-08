using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACarAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentACarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentACarController : ControllerBase
    {
        private readonly RentalService _service;
        public RentACarController(RentalService service)
        {
            _service = service;
        }

        [Route("RentOut")]
        [HttpPost]
        public async Task<ActionResult> RegisterRental(Rental rental)
        {
            try
            {
                await _service.RegisterRental(rental);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [Route("Return")]
        [HttpPost]
        public async Task<ActionResult> RegisterReturnRental(ReturnRental returnRental)
        {
            try
            {
                double price = await _service.RegisterReturnRental(returnRental);
                return Ok($"Price: { price }");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
