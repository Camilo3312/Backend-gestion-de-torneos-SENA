namespace Backend_API_Torneos.Models
{
    public class Jugador
    {
        private string _nombre;
        public string nombre { set { _nombre = value; } get { return _nombre; } }

        private string _ficha;
        public string ficha { set { _ficha = value; } get { return _ficha; } }

        private string _jornada;
        public string jornada { set { _jornada = value; } get { return _jornada; } }

        private bool _estado; 
        public bool estado { set { _estado = value; } get { return _estado; }  }
        
        public Jugador(string nombre, string ficha, string jornada, bool estado)
        {
            this.nombre = nombre;
            this.ficha = ficha;
            this.jornada = jornada;
            this.estado = estado;
        }
    }
}
