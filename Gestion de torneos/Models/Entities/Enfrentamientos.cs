using Backend_API_Torneos.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_de_torneos.Models
{
    public class Enfrentamientos
    {
        private List<Equipo> _grupo_a;
        public List<Equipo> grupo_a { set { _grupo_a = value; } get { return _grupo_a; } }
        private List<Equipo> _grupo_b;
        public List<Equipo> grupo_b { set { _grupo_b = value; } get { return _grupo_b; } }
        public Enfrentamientos(List<Equipo> equiposTorneo)
        {
            DistribucionEquipos(equiposTorneo);
        }

        private void DistribucionEquipos(List<Equipo> equiposTorneo)
        {
            var grupo_a = new List<Equipo>();
            var grupo_b = new List<Equipo>();
            var distribucion = NumeroAleatorio(equiposTorneo.Count);
            foreach (var i in distribucion)
            {
                if (grupo_a.Count + 1 <= (equiposTorneo.Count / 2))
                    grupo_a.Add(equiposTorneo[i]);
                else              
                    grupo_b.Add(equiposTorneo[i]);
                
            };
            this.grupo_a = grupo_a;
            this.grupo_b = grupo_b;
        }

        private List<int> NumeroAleatorio(int cantidadNumeros)
        {
            var random = new Random();
            var randomList = new List<int>();
            
            while(randomList.Count < cantidadNumeros)
            {
                var numero = random.Next(0, cantidadNumeros);
                if (!randomList.Contains(numero))
                    randomList.Add(numero);
            }

            return randomList;
        }

    }
}
