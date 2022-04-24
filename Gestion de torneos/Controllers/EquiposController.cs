using Backend_API_Torneos.Models;
using Gestion_de_torneos.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using work4hours_modules_backend.Models;

namespace Gestion_de_torneos.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EquiposController : ControllerBase
    {
        MySqlDatabase _db = new MySqlDatabase();

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var query = @"select * from equipos
                          where torneo = @id
                        ";
            var response = _db.Get(query, new { id = id });
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EquipoData equipo)
        {
            var query = @"insert into equipos
                          (jornada, torneo, goles_recibidos, porterias_imbatidas, cantidadfaltas, partidos_ganados, partidos_perdidos)
                          values (@jornada, @torneo, @goles_recibidos, @porterias_imbatidas, @cantidadfaltas, @partidos_ganados, @partidos_perdidos)
                        ";
            var response = _db.Post(query, equipo);
            return Ok(await response);
        }
    }
}
