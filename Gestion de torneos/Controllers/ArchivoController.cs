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
            var sql = "";
            var selectSql = "";
            var equipoNuevo = "";
            var equipoAnterior = "";
            var cantidadEquipos = 0;
            var contador = 0;

            try
            {
                var path = Environment.CurrentDirectory + @"\ArchivosCSV\" + files.FileName;
                using (var stream = System.IO.File.Create(path))
                {
                    files.CopyToAsync(stream);
                }
                string filepath = Environment.CurrentDirectory + @"\ArchivosCSV\" + files.FileName;
                System.IO.StreamReader archivo = new System.IO.StreamReader(filepath);
                string separado = ",";
                string linea;
                archivo.ReadLine();
                sql += $"insert into torneos (idusuarioadmin, totalparticipantes, nombretorneo, tipotorneo, fechainicio) values (2,33,'Prueba',1,'2022-04-25');";
                sql += "insert into liguilla (jornada) values (4);";
                while ((linea = archivo.ReadLine()) != null)
                {
                    string[] fila = linea.Split(separado);
                    string nombre = fila[0];
                    string ficha = fila[1];
                    string jornada = fila[2];
                    string estado = fila[3];
                    string nombreequipo = fila[4];
                    equipoNuevo = nombreequipo;
                    

                    if (equipoNuevo != equipoAnterior)
                    {
                        if (contador == 4)
                        {
                            contador = 0;
                            sql += $"insert into liguilla (jornada) values ({Convert.ToInt32(jornada)});";
                        }
                        contador++;

                        equipoAnterior = nombreequipo;
                        cantidadEquipos++;

                        sql += $"insert into equipos (imagen, jornada, torneo, cantidadfaltas, nombreequipo, golesafavor, golesencontra, cantidadexpulciones, partidosganados,  partidosperdidos, liguilla) values (null, {jornada},  (select max(t.id) from torneos t), 0, '{nombreequipo}', 0,0,0,0,0,(select max(l.id) from liguilla l) );";
                    }
                    sql += $"insert into participantes (nombre, ficha, jornada, estado, equipo) values ('{nombre}', '{ficha}', {jornada}, {estado}, (select max(e.id) from equipos e) );";
                
                }


                //var result = _db.ConvertDataTabletoList("select count(id) as cantidad from equipos where torneo = (select max(t.id) from torneos t );")[0];
                //var cantidad = result.GetValueOrDefault("cantidad");
                //_db.ConvertDataTabletoList("insert into liguilla (jornada) values (4);");
                //var contador = 0;
                //for (int i = 1; i <= Convert.ToInt32(cantidad); i++)
                //{
                //    if (contador == 4)
                //    {
                //        contador = 0;
                //        _db.ConvertDataTabletoList("insert into liguilla (jornada) values (4);");
                //    }
                //    contador++;
                //    sql += $"update equipos set liguilla = (select max(l.id) from liguilla) where id in(select id from equipos where torneo = (select max(t.id) from torneo t) limit 0,4);";
                //}
                sql += "call myproc();";
                _db.executeSql(sql);
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
