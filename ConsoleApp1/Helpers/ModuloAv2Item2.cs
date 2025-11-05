using System;

namespace ConsoleApp1.Helpers
{
    public static class ModuloAv2Item2
    {
        public static void ExecutarDecisores()
        {
            bool continuar = true;
            
            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("=== DECISORES L_fim_b e L_mult3_b ===");
                Console.WriteLine("Alfabeto: Σ = {a, b}");
                Console.WriteLine();
                Console.WriteLine("1 - L_fim_b: palavras que terminam com 'b'");
                Console.WriteLine("2 - L_mult3_b: palavras com número de 'b's múltiplo de 3");
                Console.WriteLine("0 - Voltar");
                Console.Write("Escolha uma opção: ");

                string? opcao = Console.ReadLine();
                
                switch (opcao)
                {
                    case "1":
                        ExecutarLFimB();
                        break;
                    case "2":
                        ExecutarLMult3B();
                        break;
                    case "0":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void ExecutarLFimB()
        {
            Console.Clear();
            Console.WriteLine("=== DECISOR L_fim_b ===");
            Console.WriteLine("Linguagem: palavras que terminam com 'b'");
            Console.WriteLine("Alfabeto: Σ = {a, b}");
            Console.WriteLine();

            Console.Write("Digite uma cadeia: ");
            string? cadeia = Console.ReadLine();

            if (string.IsNullOrEmpty(cadeia))
            {
                Console.WriteLine("Cadeia vazia não é válida.");
                Console.ReadKey();
                return;
            }

            // Validar alfabeto
            foreach (char c in cadeia)
            {
                if (c != 'a' && c != 'b')
                {
                    Console.WriteLine($"Símbolo '{c}' não pertence ao alfabeto Σ = {{a, b}}");
                    Console.ReadKey();
                    return;
                }
            }

            // Decisor: termina com 'b'?
            bool aceita = cadeia.EndsWith('b');
            
            Console.WriteLine($"Resultado: {(aceita ? "SIM" : "NAO")}");
            Console.WriteLine($"A cadeia '{cadeia}' {(aceita ? "pertence" : "não pertence")} à linguagem L_fim_b");
            
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        private static void ExecutarLMult3B()
        {
            Console.Clear();
            Console.WriteLine("=== DECISOR L_mult3_b ===");
            Console.WriteLine("Linguagem: palavras com número de 'b's múltiplo de 3");
            Console.WriteLine("Alfabeto: Σ = {a, b}");
            Console.WriteLine();

            Console.Write("Digite uma cadeia: ");
            string? cadeia = Console.ReadLine();

            if (string.IsNullOrEmpty(cadeia))
            {
                Console.WriteLine("Cadeia vazia é aceita (0 é múltiplo de 3).");
                Console.WriteLine("Resultado: SIM");
                Console.ReadKey();
                return;
            }

            // Validar alfabeto
            foreach (char c in cadeia)
            {
                if (c != 'a' && c != 'b')
                {
                    Console.WriteLine($"Símbolo '{c}' não pertence ao alfabeto Σ = {{a, b}}");
                    Console.ReadKey();
                    return;
                }
            }

            // Contar número de 'b's
            int contadorB = 0;
            foreach (char c in cadeia)
            {
                if (c == 'b')
                    contadorB++;
            }

            // Decisor: número de 'b's é múltiplo de 3?
            bool aceita = contadorB % 3 == 0;
            
            Console.WriteLine($"Número de 'b's: {contadorB}");
            Console.WriteLine($"Resultado: {(aceita ? "SIM" : "NAO")}");
            Console.WriteLine($"A cadeia '{cadeia}' {(aceita ? "pertence" : "não pertence")} à linguagem L_mult3_b");
            
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
}