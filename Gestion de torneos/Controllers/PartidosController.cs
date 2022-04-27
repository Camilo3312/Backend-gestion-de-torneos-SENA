using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using work4hours_modules_backend.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gestion_de_torneos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartidosController : ControllerBase
    {
        MySqlDatabase _db = new MySqlDatabase();
        // GET: api/<PartidosController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }



        // GET api/<PartidosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PartidosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PartidosController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromQuery] string idganador)
        {
            string sql = $"update partidos set idganador = {idganador} where id = {id} ;";
            string result = _db.executeSql(sql);
            string sqlganador = $"update equipos set partidosganados = partidosganados + 1 where id = {idganador};";
            string resultGanador = _db.executeSql(sqlganador);
            if (result == resultGanador)
            {
                return Ok("Correct");
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<PartidosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
