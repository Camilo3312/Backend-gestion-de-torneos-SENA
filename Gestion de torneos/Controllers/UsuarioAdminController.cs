using Gestion_de_torneos.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using work4hours_modules_backend.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gestion_de_torneos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioAdminController : ControllerBase
    {
        MySqlDatabase _db = new MySqlDatabase();
        UsuarioAdmin _usuarioadmin = new UsuarioAdmin();
        // GET: api/<UsuarioAdminController>
        [HttpGet]
        public string Get([FromQuery] string correo, string contrasenna)
        {
            string sql = $"select * from usuarioadmin where correo ='{correo}' and contrasenna = '{contrasenna}';";
            string result = _db.ConvertDataTabletoString(sql) ;
            if (result=="[]")
            {
                return "{exist:false}";
            }
            else
            {
                return result;
            }

        }

        // GET api/<UsuarioAdminController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UsuarioAdminController>
        [HttpPost]
        public bool Post([FromBody] UsuarioAdmin usuarioAdmin)
        {
            string sql = $"insert into usuarioadmin (nombre, correo, contrasenna) values ('"+usuarioAdmin.nombre+"','"+usuarioAdmin.correo+"','"+usuarioAdmin.contrasenna+"');";
            string result = _db.executeSql(sql);
            if (result == "Correct")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // PUT api/<UsuarioAdminController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsuarioAdminController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
