using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Post2.Modules;
using Post2.Services;

namespace Post2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {


        private readonly IGenericCRUDService<AddressModel> _addressSvc;
        public AddressController(IGenericCRUDService<AddressModel> addressSvc)
        {
            _addressSvc = addressSvc;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            return Ok(await _addressSvc.Get());
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id == 0)
                return NotFound($"Address with the given id: {id} is not found!");
            else if (id < 1)
                return BadRequest("Wrong data!");
            return Ok(await _addressSvc.GetById(id));
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddressModel address)
        {
            var createEmployee = await _addressSvc.Create(address);
            var routeValues = new { id = createEmployee.Id };
            return CreatedAtRoute(routeValues, createEmployee);
            //return Created(uri, routeValues);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] AddressModel address)
        {
            var updatedEployee = await _addressSvc.Update(id, address);
            return Ok(updatedEployee);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool deletedEmployee = await _addressSvc.Delete(id);

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
