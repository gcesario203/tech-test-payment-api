using implementation.Data;
using implementation.Data.ResponseObjects;
using implementation.Models;
using implementation.Models.Enums;
using implementation.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace implementation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IService<OrderDTO, ResultResponse> _service;

        public OrderController(IService<OrderDTO, ResultResponse> service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _service.GetById(id);

            if (result.IsOk())
                return Ok(result.Data);

            return NotFound(result.Errors);
        }

        [HttpPost]
        public IActionResult Create([FromBody] OrderDTO item)
        {
            var result = _service.Create(item);

            if (result.IsOk())
                return CreatedAtAction("", (Order)result.Data);

            return HandleResponseErrors(result.Errors, result.RequiredFields);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] OrderStatus status)
        {
            var result = _service.UpdateStatus(id, status);

            if (result.IsOk())
                return Ok("Venda alterada com sucesso");

            return HandleResponseErrors(result.Errors, result.RequiredFields);
        }

        private IActionResult HandleResponseErrors(List<string> errorsList, List<string> requiredFieldsList)
        {
            errorsList.AddRange(requiredFieldsList);

            if(errorsList.Any())
                return BadRequest(errorsList);

            return BadRequest();
        }
    }
}