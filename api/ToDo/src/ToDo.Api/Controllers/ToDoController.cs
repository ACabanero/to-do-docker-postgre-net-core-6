using Microsoft.AspNetCore.Mvc;
using ToDo.Api.DTOs;
using ToDo.Api.Mappers;
using ToDo.Domain.Interfaces.Repositories;
using ToDo.Domain.Interfaces.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoService _service;
        public ToDoController(IToDoService service) { 
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }
        // GET: api/<ToDoController>?title=coco
        [HttpGet()]
        public async Task<IEnumerable<ToDoDto?>> Search([FromQuery]string title)
        {
            return ToDoEntityToDto.ToDoDtoCollection(await _service.GetToDoSearchAsync(title));
        }

        // GET api/<ToDoController>/5
        [HttpGet("{id}")]
        public async Task<ToDoDto?> GetByIdAsync(int id)
        {
            return ToDoEntityToDto.ToDoDto(await _service.GetToDoByIdAsync(id));
        }

        // POST api/<ToDoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ToDoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ToDoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
