using Web_API;

namespace Gestion_de_torneos.Models.Entities
{
    public class UsuarioAdmin
    {
        private string _nombre; 
        public string nombre { set { _nombre = value; }  get { return _nombre; } }

        private string _correo; 
        public string correo { set { _correo = value; } get { return _correo;} }

        private string _contrasenna;
        public string contrasenna { set { _contrasenna = Encrypt.GetSHA256(value); } get { return _contrasenna;} }

        private string _nombretorneo;
        public string nombretorneo { set { _nombretorneo = value; } get { return _nombretorneo; } }


        private string _tipotorneo;
        public string tipotorneo { set { _tipotorneo = value; } get { return _tipotorneo; } }
    }   
}
