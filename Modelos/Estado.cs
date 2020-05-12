using System;
using System.Collections.Generic;
using System.Text;

namespace AutomatasFinitos
{
    class Estado
    {
        protected Dictionary<char, Estado> Transiciones { set; get; }
        
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
            return this;
            
        }
    }
}
