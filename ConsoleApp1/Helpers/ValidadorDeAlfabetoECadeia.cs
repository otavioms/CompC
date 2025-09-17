using System;

namespace ConsoleApp1.Helpers
{
    public static class ValidadorDeAlfabetoECadeia
    {
        // Alfabeto Σ = {a, b}
        private static readonly char[] AlfabetoSigma = { 'a', 'b' };

        public static void ValidarAlfabetoECadeia()
        {
            Console.Clear();
            Console.WriteLine("------------------------------");
            Console.WriteLine("VALIDADOR DE ALFABETO E CADEIA");
            Console.WriteLine("------------------------------");
            Console.WriteLine("Alfabeto Σ = {a, b}");
            Console.WriteLine();

            // Primeiro: verificar símbolo individual
            VerificarSimboloIndividual();

            Console.WriteLine();

            // Segundo: verificar cadeia completa
            VerificarCadeiaCompleta();

            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        private static void VerificarSimboloIndividual()
        {
            Console.WriteLine("=== VERIFICAÇÃO DE SÍMBOLO ===");
            Console.Write("Digite um símbolo: ");
            string entrada = Console.ReadLine();

            // Validação de entrada
            if (string.IsNullOrEmpty(entrada))
            {
                Console.WriteLine("INVÁLIDO: Entrada vazia.");
                return;
            }

            if (entrada.Length != 1)
            {
                Console.WriteLine("INVÁLIDO: Digite apenas um símbolo.");
                return;
            }

            char simbolo = entrada[0];

            // Verificar se o símbolo pertence a Σ
            bool pertenceAoAlfabeto = Array.Exists(AlfabetoSigma, elemento => elemento == simbolo);

            if (pertenceAoAlfabeto)
            {
                Console.WriteLine($"VÁLIDO: O símbolo '{simbolo}' pertence ao alfabeto Σ.");
            }
            else
            {
                Console.WriteLine($"INVÁLIDO: O símbolo '{simbolo}' NÃO pertence ao alfabeto Σ.");
            }
        }

        private static void VerificarCadeiaCompleta()
        {
            Console.WriteLine("=== VERIFICAÇÃO DE CADEIA ===");
            Console.Write("Digite uma cadeia: ");
            string cadeia = Console.ReadLine();

            // Validação de entrada - cadeia pode ser vazia (ε - épsilon)
            if (cadeia == null)
            {
                Console.WriteLine("INVÁLIDO: Entrada nula.");
                return;
            }

            // Cadeia vazia é válida em Σ* (épsilon)
            if (cadeia.Length == 0)
            {
                Console.WriteLine("VÁLIDO: Cadeia vazia (ε) pertence a Σ*.");
                return;
            }

            // Verificar cada símbolo da cadeia
            bool cadeiaValida = true;
            char primeiroSimboloInvalido = '\0';

            foreach (char simbolo in cadeia)
            {
                bool simboloPertence = Array.Exists(AlfabetoSigma, elemento => elemento == simbolo);

                if (!simboloPertence)
                {
                    cadeiaValida = false;
                    primeiroSimboloInvalido = simbolo;
                    break;
                }
            }

            if (cadeiaValida)
            {
                Console.WriteLine($"VÁLIDO: A cadeia '{cadeia}' pertence a Σ*.");
            }
            else
            {
                Console.WriteLine($"INVÁLIDO: A cadeia '{cadeia}' NÃO pertence a Σ*.");
                Console.WriteLine($"Símbolo inválido encontrado: '{primeiroSimboloInvalido}'");
            }
        }
    }
}