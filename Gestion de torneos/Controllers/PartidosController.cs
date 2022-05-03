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
        [HttpPut("resultado/{idpartido}/{idequipogandor}/{idequipoperdedor}/{golesganador}/{golesperdedor}")]
        public ActionResult Put(int idpartido, int idequipogandor, int idequipoperdedor, int golesganador, int golesperdedor)
        {
            string sql = "";
            sql += $"update partidos set idganador = {idequipogandor} where id = {idpartido} ;";
            sql += $"update equipos set partidosganados = (partidosganados + 1), golesafavor = (golesafavor + {golesganador}), golesencontra = (golesencontra + {golesperdedor}) where id = {idequipogandor} ;";
            sql += $"update equipos set partidosperdidos = (partidosperdidos + 1), golesafavor = (golesafavor + {golesperdedor}), golesencontra = (golesencontra + {golesganador}) where id = {idequipoperdedor} ;";
            var resultGanador = _db.executeSql(sql);
            return Ok(resultGanador);
        }

        // DELETE api/<PartidosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
