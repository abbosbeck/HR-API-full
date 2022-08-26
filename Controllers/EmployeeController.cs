using Microsoft.AspNetCore.Mvc;
using Post2.Modules;
using Post2.Services;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Post2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IGenericCRUDService<EmployeeModel> _employeeSvc;  
        public EmployeeController(IGenericCRUDService<EmployeeModel> employeeSvc)
        {
            _employeeSvc = employeeSvc;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _employeeSvc.Get());
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id == 0)
                return NotFound($"Employee with the given id: {id} is not found!");
            else if (id < 1) 
                return BadRequest("Wrong data!");
            return Ok(await _employeeSvc.GetById(id));
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmployeeModel employee)
        {
            var createEmployee = await _employeeSvc.Create(employee);
            var routeValues = new { id = createEmployee.Id };
            return CreatedAtRoute(routeValues, createEmployee);
            //return Created(uri, routeValues);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EmployeeModel employee)
        {
            var updatedEployee = await _employeeSvc.Update(id, employee);
            return Ok(updatedEployee);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool deletedEmployee = await _employeeSvc.Delete(id);

            if (deletedEmployee)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
