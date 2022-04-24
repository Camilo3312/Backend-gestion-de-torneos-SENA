using Backend_API_Torneos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gestion_de_torneos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JugadoresController : ControllerBase
    {
        // GET: api/<JugadoresController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<JugadoresController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<JugadoresController>
        [HttpPost]
        public async Task<List<Jugador>> PostAsync([FromQuery] IFormFile file)
        {
            var list = new List<Jugador>();
            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                using (var package = new ExcelPackage(stream))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    var rowcount = worksheet.Dimension.Rows;
                    for (int row = 2; row < rowcount; row++)
                    {
                        list.Add(new Jugador
                        {
                            nombre = worksheet.Cells[row, 1].Value.ToString().Trim(),
                            ficha = worksheet.Cells[row, 2].Value.ToString().Trim(),
                            jornada = worksheet.Cells[row, 3].Value.ToString().Trim(),
                            estado = worksheet.Cells[row, 4].Value.ToString().Trim(),
                        });
                    }
                }
            }
            return list;
        }

        // PUT api/<JugadoresController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<JugadoresController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
