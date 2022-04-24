using Backend_API_Torneos.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using work4hours_modules_backend.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gestion_de_torneos.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class TorneoController : ControllerBase
    {
        MySqlDatabase _db = new MySqlDatabase();
        // GET: api/<TorneoController>
        [HttpGet]
        public string Get()
        {
            string sql = "Select * from torneos;";
            string result = _db.ConvertDataTabletoString(sql);
            return result;
        }

        // GET api/<TorneoController>/5
        [HttpGet("{id}")]
        public string Get([FromQuery] int id)
        {
            string sql = $"Select * from torneos where id={id};";
            string result = _db.ConvertDataTabletoString(sql);
            return result;
        }

        [HttpGet("torneos/{idadmin}")]
        public IActionResult GetTorneos(int idadmin)
        {
            string query = $"select * from torneos where idusuarioadmin = @id";
            var result = _db.Get(query, new { id = idadmin });
            return Ok(result);
        }

        // POST api/<TorneoController>
        [HttpPost]
        public string Post([FromQuery] int idusuarioadmin, int totalparticipantes, string nombretorneo, int tipotorneo, string fechainicio, string fase)
        {
            string sql = $"Insert into torneos(idusuarioadmin,totalparticipantes,nombretorneo,tipotorneo,fechainicio,fase) value ('" + idusuarioadmin + "', '" + totalparticipantes + "', '" + nombretorneo + "','" + tipotorneo + "','" + fechainicio + "','" + fase + "');";
            string result = _db.executeSql(sql);
            return result;
        }

        // PUT api/<TorneoController>/5
        [HttpPut("{id}")]
        public string Put(int id, [FromQuery] int idusuarioadmin, int totalparticipantes, string nombretorneo, int tipotorneo, string fechainicio, string fase)
        {
            string sql = $"update torneos set idusuarioadmin = {idusuarioadmin} ,totalparticipantes = {totalparticipantes} ,nombretorneo = '{nombretorneo}',tipotorneo = {tipotorneo},fechainicio= '{fechainicio}',fase='{fase}' where id = {id};";
            string result = _db.executeSql(sql);
            return result;
        }

        // DELETE api/<TorneoController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {

            string sql = $"delete from torneos where id={id};";
            string result = _db.executeSql(sql);
            return result;
        }
    }
}
