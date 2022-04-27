using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API;

namespace Gestion_de_torneos.Controllers
{
  
    public class LoginData
    {

        private int _id;
        public int id { set { _id = value; } get { return _id; } }

        private string _nombre;
        public string nombre { set { _nombre = value; } get { return _nombre; } }

        private string _correo;
        public string correo { set { _correo = value; } get { return _correo; } }

        private string _contrasenna { get; set; }
        public string contrasenna { set { _contrasenna = Encrypt.GetSHA256(value); } get { return _contrasenna; } }
    }
    
}
