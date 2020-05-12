using AutomatasFinitos.Excepciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomatasFinitos.Modelos
{
    class Estado
    {
        public Dictionary<char, Estado> Transiciones { get; protected set; }
        public Automata AutomataPadre { get; set; }
        public bool Aceptacion { get; protected set; }

        public Estado(bool aceptacion)
        {
            Transiciones = new Dictionary<char, Estado>();
            Aceptacion = aceptacion;
        }

        public void AgregarTransicion(char transicion, Estado destino)
        {
            Transiciones.Add(transicion, destino);
        }

        public Estado Navegar(char entrada)
        {
            if (Transiciones.TryGetValue(entrada, out Estado siguiente))
            {
                return siguiente;
            }
            // No encontró la transición
            // Buscar si entrada aparece en el alfabeto
            if (AutomataPadre.Alfabeto.Contains(entrada))
            {
                return this;
            }
            throw new TransitionNotInAlphabetException();
        }
    }
}
