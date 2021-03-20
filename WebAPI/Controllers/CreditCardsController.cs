using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardsController : ControllerBase
    {
        ICreditCardService _creditCardService;

        public CreditCardsController(ICreditCardService carService)
        {
            _creditCardService = carService;
        }
        [HttpPost("add")]
        public IActionResult Add(CreditCard creditCard)
        {
            var result = _creditCardService.Add(creditCard);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("delete")]
        public IActionResult GetCarDetail(CreditCard creditCard)
        {
            var result = _creditCardService.Delete(creditCard);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("update")]
        public IActionResult Update(CreditCard creditCard)
        {
            var result = _creditCardService.Update(creditCard);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
