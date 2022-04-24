using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_de_torneos.Models
{
    public class EquipoData
    {
        public int id { get; set; }
        public int jornada { get; set; }
        public int torneo { get; set; }
        public int goles_recibidos { get; set; }
        public int porterias_imbatidas { get; set; }
        public int cantidadfaltas { get; set; }
        public int partidos_ganados { get; set; }
        public int partidos_perdidos { get; set; }
    }
}
