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
                            select pd.id, pd.fechaencuentro, e.id as idequipo1, substring_index(GROUP_CONCAT(e.id),',', -1) as idequipo2, e.nombreequipo as equipo1, substring_index(GROUP_CONCAT(e.nombreequipo),',', -1) as equipo2, e.jornada ,t.nombretorneo , pd.idganador, l.id as idliguilla
                            from equipos_partidos ep inner join partidos pd on ep.partido = pd.id
                            right join equipos e on ep.equipo = e.id
                            inner join liguilla l on e.liguilla = l.id
                            right join torneos t on e.torneo = t.id
                            where e.torneo = @id
                            group by pd.id
                           ";
            var result = _db.Get(query, new { id = id });
            return Ok(result);
        }
    }
}
