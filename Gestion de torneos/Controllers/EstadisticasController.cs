using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using work4hours_modules_backend.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gestion_de_torneos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadisticasController : ControllerBase
    {
        MySqlDatabase _db = new MySqlDatabase();
        // GET: api/<EstadisticasController>
        [HttpGet]
        public string Get()
        {
            string sqlEstadisticas = "select count(*) as participantes, (select count(e.id)  from equipos e) as equipos, (select count(fechainicio)  from torneos where fechainicio<current_date()) as fechasJugadas, (select count(fechainicio)  from torneos where fechainicio>current_date()) as fechasPorJugar from participantes;";
            string result1 = _db.ConvertDataTabletoString(sqlEstadisticas);
            return result1;
        }

        // GET api/<EstadisticasController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EstadisticasController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EstadisticasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EstadisticasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
