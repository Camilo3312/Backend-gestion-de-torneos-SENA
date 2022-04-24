using System;
using System.Collections.Generic;

namespace Backend_API_Torneos.Models
{
    public class Torneo
    {
        private DateTime _fecha;
        public DateTime fecha { set { _fecha = value; } get { return _fecha; } }

        private Equipo _ganador;
        public Equipo ganador { set { _ganador = value; } get { return _ganador; } }

        private string _tipo_torneo;
        public string tipo_torneo { set { _tipo_torneo = value; } get { return _tipo_torneo; } }

        private List<Equipo> _equipos;
        public List<Equipo> equipos { set { _equipos = value; }  get { return _equipos; } }

        public Torneo(DateTime fecha, string tipo_torneo, List<Equipo> equipos)
        {
            this.fecha = fecha;
            this.tipo_torneo = tipo_torneo;
            this.equipos = equipos;
        }
    }
}
