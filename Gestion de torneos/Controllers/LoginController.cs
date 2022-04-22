using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API;
using work4hours_modules_backend.Models;

namespace Gestion_de_torneos.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        MySqlDatabase _db = new MySqlDatabase();

        [HttpPost]
        public string Post([FromBody] LoginData login_data)
        {
            var query = $"select id, nombre, correo from usuarioadmin where correo = '{login_data.correo}' and contrasenna = '{login_data.contrasenna}' ;";
            string result = _db.ConvertDataTabletoString(query);
            if (result == "[]")
                return " { isAuth : false } ";
            else
                return "{isAuth: true, data: "+ result +" }";
            
        }
    }
}