using AutoMapper;
using implementation.DataTransferObjects;
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

        private readonly IMapper _mapper;

        public OrderController(IRepository<Order> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
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
        public IActionResult Create([FromBody] OrderDTO item)
        {
            var mappedItem = _mapper.Map<Order>(item);
            _repository.Create(_mapper.Map<Order>(mappedItem));
            return CreatedAtRoute("GetById", mappedItem.Id, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] OrderDTO item)
        {
            _repository.Update(id, _mapper.Map<Order>(item));

            return Ok();
        }
    }
}