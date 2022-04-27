using System;

namespace Gestion_de_torneos.Models.Entities
{
    public class Estadisticas
    {
        private string _fechaencuentro;
        public string fechaencuentro { set { _fechaencuentro = value; } get { return _fechaencuentro; } }

        string _participantes;
        public string participantes { set { _participantes = value; } get { return _participantes; } }

        string _equipos;
        public string equipos { set { _equipos = value; } get { return _equipos; } }

        string _fechastranscurridas;
        public string fechastranscurridas { set { _fechastranscurridas = value; } get { return _fechastranscurridas; } }

        string _fechasporjugar;
        public string fechasporjugar { set { _fechasporjugar = value; } get { return _fechasporjugar; } }

        DateTime fechaactual = DateTime.Now;



    }
}
