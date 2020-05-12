using System;

namespace AutomatasFinitos
{
    class Program
    {
        static void Main(string[] args)
        {
           
           
            Console.WriteLine("Programa de Autómatas");
            Console.WriteLine("Yael Chavoya\n");

            while(true)
            {
                EvaluarAutomata("(ab + aba)*", EjemplosAutomatas.AB_ABA);
                
                // Otros ejemplos
                //EvaluarAutomata("Múltiplos de 2", EjemplosAutomatas.Multiplos2);
                //EvaluarAutomata("Número par de 1s y número par de 0s", EjemplosAutomatas.Par1y0);
            }
        }

        static void EvaluarAutomata(string nombre, Func<string, bool> funcAutomata)
        {
            string entrada;
            bool resultado;

            Console.WriteLine($"Evaluando Autómata: {nombre}");
            Console.Write("Escriba la cadena a evaluar: ");
            entrada = Console.ReadLine();
            resultado = funcAutomata(entrada);
            Console.WriteLine($"¿Aceptada? {resultado}\n");

        }
    }
}
