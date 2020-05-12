using System;
using System.Collections.Generic;
using System.Text;
using AutomatasFinitos.Modelos;

namespace AutomatasFinitos
{
    static class EjemplosAutomatas
    {
        public static bool Multiplos2(string cadena)
        {
            var automata = new Automata();

            var Q = new Estado(false);
            var _1 = new Estado(false);
            var _0 = new Estado(true);

            Q.AgregarTransicion('1', _1);
            Q.AgregarTransicion('0', _0);
            _1.AgregarTransicion('0', _0);
            _0.AgregarTransicion('1', _1);

            automata.AgregarEstados(Q, _1, _0);
            automata.SetInicial(Q);

            return automata.Evaluar(cadena);
        }

        public static bool AB_ABA(string cadena)
        {
            var automata = new Automata();

            var Q = new Estado(true);
            var Z = new Estado(false);
            var A = new Estado(false);
            var B = new Estado(true);
            var A2 = new Estado(true);

            Q.AgregarTransicion('a', A);
            Q.AgregarTransicion('b', Z);
            A.AgregarTransicion('a', Z);
            A.AgregarTransicion('b', B);
            B.AgregarTransicion('a', A2);
            B.AgregarTransicion('b', Z);
            A2.AgregarTransicion('a', A);
            A2.AgregarTransicion('b', B);

            automata.AgregarEstados(Q, Z, A, B, A2);
            automata.SetInicial(Q);

            return automata.Evaluar(cadena);
        }

        public static bool Par1y0(string cadena)
        {
            var automata = new Automata();

            var Q = new Estado(true);
            var _1 = new Estado(false);
            var _0 = new Estado(false);
            var D = new Estado(false);

            Q.AgregarTransicion('1', _1);
            Q.AgregarTransicion('0', _0);
            _1.AgregarTransicion('1', Q);
            _1.AgregarTransicion('0', D);
            _0.AgregarTransicion('1', D);
            _0.AgregarTransicion('0', Q);
            D.AgregarTransicion('0', _1);
            D.AgregarTransicion('1', _0);

            automata.AgregarEstados(Q, _1, _0, D);
            automata.SetInicial(Q);

            return automata.Evaluar(cadena);
        }
    }
}
