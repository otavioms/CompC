using System;

namespace ConsoleApp1.Helpers
{
    public static class ModuloAv1Item5
    {
        private static readonly char[] AlfabetoSigma = { 'a', 'b' };

        public static void ExecutarReconhecedor()
        {
            Console.Clear();
            Console.WriteLine("------------------------------");
            Console.WriteLine("RECONHECEDOR DE LINGUAGENS");
            Console.WriteLine("------------------------------");
            Console.WriteLine("Alfabeto Σ = {a, b}");
            Console.WriteLine();
            Console.WriteLine("Escolha a linguagem:");
            Console.WriteLine("1 - L_par_a (número par de 'a')");
            Console.WriteLine("2 - L = { w | w = a b* }");
            Console.Write("Opção: ");
            string? opcao = Console.ReadLine();

            if (opcao == "1")
            {
                ReconhecerLParA();
            }
            else if (opcao == "2")
            {
                ReconhecerABEstrela();
            }
            else
            {
                Console.WriteLine("Opção inválida.");
            }

            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        private static void ReconhecerLParA()
        {
            Console.WriteLine("=== L_par_a ===");
            Console.Write("Digite uma cadeia: ");
            string? cadeia = Console.ReadLine();
            if (cadeia == null)
            {
                Console.WriteLine("REJEITA: Entrada nula.");
                return;
            }
            if (!CadeiaValida(cadeia))
            {
                Console.WriteLine("REJEITA: Símbolos fora do alfabeto Σ.");
                return;
            }
            int qtdA = 0;
            foreach (char simbolo in cadeia)
            {
                if (simbolo == 'a') qtdA++;
            }
            if (qtdA % 2 == 0)
            {
                Console.WriteLine("ACEITA: Número par de 'a'.");
            }
            else
            {
                Console.WriteLine("REJEITA: Número ímpar de 'a'.");
            }
        }

        private static void ReconhecerABEstrela()
        {
            Console.WriteLine("=== L = { w | w = a b* } ===");
            Console.Write("Digite uma cadeia: ");
            string? cadeia = Console.ReadLine();
            if (cadeia == null)
            {
                Console.WriteLine("REJEITA: Entrada nula.");
                return;
            }
            if (!CadeiaValida(cadeia))
            {
                Console.WriteLine("REJEITA: Símbolos fora do alfabeto Σ.");
                return;
            }
            if (string.IsNullOrEmpty(cadeia))
            {
                Console.WriteLine("REJEITA: Cadeia vazia.");
                return;
            }
            if (cadeia[0] != 'a')
            {
                Console.WriteLine("REJEITA: Não começa com 'a'.");
                return;
            }
            for (int i = 1; i < cadeia.Length; i++)
            {
                if (cadeia[i] != 'b')
                {
                    Console.WriteLine("REJEITA: Após o primeiro símbolo, só pode haver 'b'.");
                    return;
                }
            }
            Console.WriteLine("ACEITA: Cadeia válida em a b*.");
        }

        private static bool CadeiaValida(string cadeia)
        {
            if (cadeia == null) return false;
            foreach (char simbolo in cadeia)
            {
                if (Array.IndexOf(AlfabetoSigma, simbolo) == -1)
                    return false;
            }
            return true;
        }
    }
}