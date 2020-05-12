using System;
using System.Collections.Generic;
using System.Text;

namespace AutomatasFinitos
{
    class Automata
    {
        public List<Estado> Estados { get; protected set; }

        public Estado EstadoInicial { get; protected set; }

        protected Estado EstadoActual { get; set; }

        public Automata()
        {
            Estados = new List<Estado>();
        }

        public void AgregarEstado(Estado estado)
        {
            Estados.Add(estado);
        }

        public void AgregarEstados(params Estado[] estados)
        {
            foreach(Estado estado in estados)
            {
               AgregarEstado(estado);
            }
        }

        public bool SetInicial(Estado estado)
        {
            bool isInEstados = Estados.IndexOf( estado) != -1;
            if(isInEstados)
            {
                EstadoInicial = estado;
                return true;
            }
            return false;
        }

        public bool Evaluar(string cadena)
        {
            EstadoActual = EstadoInicial;
            while(cadena.Length > 0)
            {
                EstadoActual = EstadoActual.Navegar(cadena[0]);
                cadena = cadena.Substring(1);
            }
            return EstadoActual.Aceptacion;
        }

    }
}
