using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_de_torneos.Models.Entities
{
    public class Partidos
    {
        private int _id; 
        public int id { set { _id = value; } get { return _id; } }

        private int _equipo1;
        public int equipo1 { set { _equipo1 = value; } get { return _equipo1; } }

        private int _equipo2;
        public int equipo2 { set { _equipo2 = value; } get { return _equipo2; } }

        private DateTime _fechaencuentro;
        public DateTime fechaencuentro { set { _fechaencuentro = value; } get { return _fechaencuentro; } }

    }
}
