using apitrain.Model;
using Microsoft.AspNetCore.Mvc;

namespace apitrain.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private DBContext dBContext;
        public EmployeesController(DBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        [HttpGet]
        public IActionResult Get(){
            var employee = dBContext.Employees.ToList();

            return Ok(employee);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var emp = dBContext.Employees.Find(id);
            return Ok(emp);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Employee employee)
        {
            var emp = dBContext.Employees.Add(employee);

            return Ok(emp);
        }
        
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
