using implementation.Models;
using implementation.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace implementation.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class OrderController : ControllerBase
    {
        private readonly IRepository<Order> _repository;

        public OrderController(IRepository<Order> repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var order = _repository.GetById(id);

            if(order == null)
                return NotFound();

            return Ok(order);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Order item)
        {
            _repository.Create(item);
            return CreatedAtRoute("GetById", item.Id, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Order item)
        {
            _repository.Update(id, item);

            return Ok();
        }
    }
}