using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using work4hours_modules_backend.Models;

namespace Gestion_de_torneos.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class LiguillasController : ControllerBase
    {
        MySqlDatabase _db = new MySqlDatabase();

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            string script = @"
                            select l.id, count(e.id) as equipos, (select e.nombreequipo from equipos e where e.liguilla = l.id and e.partidosganados = (select max(e.partidosganados)  from equipos e  where e.liguilla = l.id ) order by e.partidosperdidos asc, e.partidosganados desc limit 1 ) as equipotop 
                            from liguilla l inner join equipos e on l.id = e.liguilla 
                            where e.torneo = @id
                            group by l.id
                            order by e.partidosganados desc;
                           ";
            return Ok(_db.Get(script, new { id = id }));
        }

        [HttpGet("equipos/{id}")]
        public IActionResult GetEquipos(int id)
        {
            string script = @"
                            select e.nombreequipo, e.partidosganados, e.golesafavor, e.golesencontra, e.partidosganados 
                            from equipos e
                            where e.liguilla = @id
                           ";
            return Ok(_db.Get(script, new { id = id }));
        }
    }
}
