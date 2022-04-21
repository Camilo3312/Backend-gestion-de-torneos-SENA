using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend_API_Torneos.Models
{
    public class Equipo
    {
        private string _nombre;
        public string nombre { set { _nombre = value; } get { return _nombre; } }

        private DateTime _fecha;
        public DateTime fecha { set { _fecha = value; } get { return _fecha; } }

        private double _puntuacion;
        public double puntuacion { set { _puntuacion = value; } get { return _puntuacion; } }

        private Equipo _contrincante;
        public Equipo contrincante { set { _contrincante = value; } get { return _contrincante; } }

        private List<Jugador> _jugadores;
        public List<Jugador> jugadores { set { _jugadores = value; } get { return _jugadores; } }

        public Equipo(string nombre, DateTime fecha, List<Jugador> jugadores)
        {
            this.nombre = nombre; 
            this.fecha = fecha;
            this.jugadores = jugadores;
        }

        public void AsignarContrincante(Equipo contrincante)
        {
            this.contrincante = contrincante;
        }
    }
}
