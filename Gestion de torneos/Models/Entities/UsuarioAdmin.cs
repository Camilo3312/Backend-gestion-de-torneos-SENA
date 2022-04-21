namespace Gestion_de_torneos.Models.Entities
{
    public class UsuarioAdmin
    {
        private string _nombre; 
        public string nombre { set { _nombre = value; }  get { return _nombre; } }

        private string _correo; 
        public string correo { set { _correo = value; } get { return _correo;} }

        private string _contrasenna;
        public string contrasenna { set { _contrasenna = value; } get { return _contrasenna;} } 
    }
}
