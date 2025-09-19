using System;

namespace ConsoleApp1.Helpers
{
    public static class ModuloAv1Item3
    {
        public static void TerminaComB()
        {
            Console.Clear();
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
            string? cadeia = Console.ReadLine();

            if (string.IsNullOrEmpty(cadeia)|| string.IsNullOrWhiteSpace(cadeia))
            {
                Console.WriteLine("Opção Invalida!");
            }
            else if (cadeia.Trim().ToLower().EndsWith("b"))
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