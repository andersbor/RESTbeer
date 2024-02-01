using Microsoft.AspNetCore.Mvc;
using RESTbeer.Models;

namespace RESTbeer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeersController : ControllerBase
    {
        private readonly BeersRepository _beersRepository;

        public BeersController(BeersRepository beersRepository)
        {
            _beersRepository = beersRepository;
        }

        // GET: api/<BeersController>
        [HttpGet("{user}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<Beer>> Get(string user)
        {
            IEnumerable<Beer> beers = _beersRepository.Get(user);
            if (beers.Any())
                return Ok(beers);
            return NotFound();
        }

        // POST api/<BeersController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<Beer> Post([FromBody] Beer value)
        {
            Beer beer = _beersRepository.Add(value);
            return Created(
                Url.ActionContext.HttpContext.Request.Path + "/" + beer.Id,
                               beer);
        }

        // PUT api/<BeersController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Beer> Put(int id, [FromBody] Beer value)
        {
            Beer? beer = _beersRepository.Update(id, value);
            if (beer == null)
                return NotFound();
            return Ok(beer);
        }

        // DELETE api/<BeersController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Beer> Delete(int id)
        {
            Beer? beer = _beersRepository.Delete(id);
            if (beer == null)
                return NotFound();
            return Ok(beer);
        }

    }
}
