using Microsoft.AspNetCore.Http;
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
    public class ArchivoController : ControllerBase
    {
        MySqlDatabase _db = new MySqlDatabase();
        // GET: api/<ArchivoController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST api/<ArchivoController>
        [HttpPost]
        public ActionResult PostArchivos([FromForm]IFormFile files)
        {
            try
            {
                var path = Environment.CurrentDirectory + @"\ArchivosCSV\" + files.Name;
                using (var stream = System.IO.File.Create(path))
                {
                    files.CopyToAsync(stream);
                }
                string filepath = Environment.CurrentDirectory + @"\ArchivosCSV\" + files.Name;
                System.IO.StreamReader archivo = new System.IO.StreamReader(filepath);
                string separado = ",";
                string linea;
                archivo.ReadLine();
                while ((linea = archivo.ReadLine()) != null)
                {
                    string[] fila = linea.Split(separado);
                    string nombre = fila[0];
                    string ficha = fila[1];
                    string jornada = fila[2];
                    string estado = fila[3];
                    string sql = $"Insert into participantes (nombre, ficha, jornada, estado) values ('" + nombre + "','" + ficha + "','" + jornada + "','" + estado + "');";
                    string result = _db.executeSql(sql);
                }
                return Content("Correct");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return BadRequest("");
        }

    }
}
