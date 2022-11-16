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
            dBContext.SaveChanges();
            return Ok(emp);
        }
        
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Employee emp)
        {
            var emplo= dBContext.Employees.Find(id);
            if(emplo == null)
                return NotFound("Employee with this not found");
            emplo.age= emp.age;
            emplo.name= emp.name;
            emplo.department= emp.department;
            emplo.gander= emp.gander;
            dBContext.SaveChanges();
            return Ok("updated");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var x = dBContext.Employees.Find(id);
            if (x == null)
                return NotFound("emloyee with id "+id+" is not found in database");
            dBContext.Employees.Remove(x);
            dBContext.SaveChanges();
            return Ok();
        }
    }
}
