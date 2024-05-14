using Hubtel.eCommerce.Cart.Api.Data;
using Hubtel.eCommerce.Cart.Api.Models;
using Hubtel.eCommerce.Cart.Api.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hubtel.eCommerce.Cart.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController
        (ICartDatabaseService cartDatabaseService) 
        : ControllerBase
    {
        //CartDbContext _dbContext = dbContext;
        ICartDatabaseService _service = cartDatabaseService;

       
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public ActionResult<IEnumerable<ICartItem>> Get()
        {
            return Ok(_service.GetItems());
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("quantity/{quantity:int}")]
        public ActionResult<ICartItem> GetByQuatity( int quantity )
        {
            if(quantity > 0)
                return Ok(_service.GetByQuantity(quantity));
            return BadRequest("Quantity should be above 0");
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id:int}",Name ="GetItem")]
        public ActionResult<ICartItem> Get(int id)
        {
            if(id > 0)
                return Ok(_service.GetById(id));
            return BadRequest();
        }

        // POST api/<CartController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult Post([FromBody] CartItem value)
        {
            if(ModelState.IsValid)
            {
                var result =_service.AddItem(value);
                if(result == true)
                  return CreatedAtRoute("GetItem", new {id = value.ItemId}, value);
                return BadRequest("Inputs were not valid");
            }
            return BadRequest(ModelState);
         }



        // DELETE api/<CartController>/5
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        [HttpDelete("delete/{id:int}")]
        public ActionResult<string> Delete(int id)
        {
            if (_service.Remove(id).itemRemoved)
                return NoContent();
            return NotFound("Item was not found");
        }
    }
}
