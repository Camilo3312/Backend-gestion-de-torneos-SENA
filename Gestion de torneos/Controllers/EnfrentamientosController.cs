using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using work4hours_modules_backend.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gestion_de_torneos.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EnfrentamientosController : ControllerBase
    {
        MySqlDatabase _db = new MySqlDatabase();

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            string query = @"
                            select pd.fechaencuentro, e.id, e.imagen, e.nombreequipo, e.jornada ,t.nombretorneo , pd.idganador, 
                            (select nombreequipo from equipos where id = pd.idganador) as nombreganador, l.id 
                            from partidos pd 
                            inner join equipos_partidos ep on pd.id = ep.partido
                            inner join equipos e on ep.equipo = e.id
                            inner join torneos t on e.torneo = t.id
                            right join liguilla l on e.id = l.id
                            where  e.torneo = @id
                           ";
            var result = _db.Get(query, new { id = id });
            return Ok(result);
        }
    }
}
