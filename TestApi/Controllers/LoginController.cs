using Microsoft.AspNetCore.Mvc;
using TestApi.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestApi.Controllers
{
    [Route("api/Test2")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        // GET: api/<LoginController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LoginController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LoginController>
        [HttpPost("Login")]
        public IActionResult Post([FromBody] Student student)
        {
            var Name = student.Name;
            var staticUsername = "toron";
            var staticPassword = "makaduwa";
            var WrongToron = "korang sa isa so toron";
            if (student.UserName == staticUsername && student.Password == staticPassword)
                {
                return Ok(new {Token = "ayos so 201  toron", Name});
            }
            else
                {
                return NotFound(WrongToron);
            }
            
        }

        // PUT api/<LoginController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LoginController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
