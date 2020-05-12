using AutomatasFinitos.Excepciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomatasFinitos.Modelos
{
    class Automata
    {
        public List<Estado> Estados { get; protected set; }

        public Estado EstadoInicial { get; protected set; }

        public Estado EstadoActual { get; protected set; }
        public HashSet<char> Alfabeto { get; protected set; }
        public bool AlfabetoAutomatico { get; set; } = true;

        public Automata()
        {
            Estados = new List<Estado>();
            Alfabeto = new HashSet<char>();
        }

        public void AgregarEstado(Estado estado)
        {
            Estados.Add(estado);
            estado.AutomataPadre = this;
            foreach(var transicion in estado.Transiciones)
            {
                if(!AlfabetoAutomatico && !Alfabeto.Contains(transicion.Key))
                {
                    throw new TransitionNotInAlphabetException();
                }
                Alfabeto.Add(transicion.Key);
            }
        }

        public void AgregarAlfabeto(params char[] alfabeto)
        {
            foreach(var item in alfabeto)
            {
                Alfabeto.Add(item);
            }
        }

        public void AgregarAlfabeto(string alfabeto)
        {
            AgregarAlfabeto(alfabeto.ToCharArray());
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
                try
                {
                    EstadoActual = EstadoActual.Navegar(cadena[0]);
                }
                catch (TransitionNotInAlphabetException)
                {
                    return false;
                }
                cadena = cadena.Substring(1);
            }
            return EstadoActual.Aceptacion;
        }

    }
}
