using System;
using System.Runtime.InteropServices;

namespace ConsoleApp1.Helpers
{
    public static class ModuloAv1Item3
    {
        public static void TerminaComB()
        {
            Console.WriteLine("-------------------");
            Console.WriteLine("   TERMINA COM B   ");
            Console.WriteLine("-------------------");
            Console.WriteLine();

            VerificaSeTerminaComB();

            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();

        }

        private static void VerificaSeTerminaComB() 
        {
            Console.WriteLine("Digite uma cadeia");
            string cadeia = Console.ReadLine();

            if (cadeia.ToLower().EndsWith("b"))
            {
                Console.WriteLine("SIM");
            }
            else 
            {
                Console.WriteLine("NAO");
            }
        }
    }
}