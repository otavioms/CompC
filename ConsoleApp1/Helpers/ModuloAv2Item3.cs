using System;

namespace ConsoleApp1.Helpers
{
    public static class ModuloAv2Item3
    {
        public static void ExecutarReconhecedorNaoTermina()
        {
            Console.Clear();
            Console.WriteLine("=== RECONHECEDOR QUE PODE NÃO TERMINAR ===");
            Console.WriteLine("Linguagem: L = {a^n b^n | n ≥ 1}");
            Console.WriteLine("Exemplos: ab, aabb, aaabbb, ...");
            Console.WriteLine("Alfabeto: Σ = {a, b}");
            Console.WriteLine();
            Console.WriteLine("ATENÇÃO: Este reconhecedor pode não terminar para");
            Console.WriteLine("algumas entradas que não pertencem à linguagem!");
            Console.WriteLine();

            Console.Write("Digite o limite máximo de passos (ex: 1000): ");
            string? limiteStr = Console.ReadLine();
            
            if (!int.TryParse(limiteStr, out int limitePasso) || limitePasso <= 0)
            {
                Console.WriteLine("Limite inválido! Usando 1000 como padrão.");
                limitePasso = 1000;
            }

            Console.Write("Digite uma cadeia: ");
            string? cadeia = Console.ReadLine();

            if (string.IsNullOrEmpty(cadeia))
            {
                Console.WriteLine("Cadeia vazia não pertence à linguagem (n ≥ 1).");
                Console.WriteLine("Resultado: REJEITA");
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

            Console.WriteLine($"Executando reconhecedor com limite de {limitePasso} passos...");
            Console.WriteLine();

            bool resultado = ReconhecerAnBn(cadeia, limitePasso);
            
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        private static bool ReconhecerAnBn(string cadeia, int limitePasso)
        {
            int passos = 0;
            
            // Simulação de um reconhecedor que pode não terminar
            // Para cadeias que não são da forma a^n b^n, pode entrar em loop
            
            Console.WriteLine("Iniciando reconhecimento...");
            
            // Verificação básica: deve começar com 'a' e terminar com 'b'
            if (!cadeia.StartsWith('a') || !cadeia.EndsWith('b'))
            {
                // Simular processamento que pode não terminar
                while (passos < limitePasso)
                {
                    passos++;
                    if (passos % 100 == 0)
                    {
                        Console.WriteLine($"Passo {passos}: ainda processando...");
                    }
                    
                    // Simular trabalho computacional
                    System.Threading.Thread.Sleep(1);
                }
                
                Console.WriteLine($"EXECUÇÃO INTERROMPIDA após {limitePasso} passos!");
                Console.WriteLine("O reconhecedor não conseguiu decidir (possível loop).");
                return false;
            }

            // Contar a's no início
            int contadorA = 0;
            int i = 0;
            
            while (i < cadeia.Length && cadeia[i] == 'a')
            {
                contadorA++;
                i++;
                passos++;
                
                if (passos >= limitePasso)
                {
                    Console.WriteLine($"EXECUÇÃO INTERROMPIDA após {limitePasso} passos!");
                    return false;
                }
            }

            // Contar b's no final
            int contadorB = 0;
            while (i < cadeia.Length && cadeia[i] == 'b')
            {
                contadorB++;
                i++;
                passos++;
                
                if (passos >= limitePasso)
                {
                    Console.WriteLine($"EXECUÇÃO INTERROMPIDA após {limitePasso} passos!");
                    return false;
                }
            }

            // Verificar se consumiu toda a cadeia e se n_a = n_b > 0
            bool aceita = (i == cadeia.Length) && (contadorA == contadorB) && (contadorA > 0);
            
            Console.WriteLine($"Passos executados: {passos}");
            Console.WriteLine($"a's encontrados: {contadorA}");
            Console.WriteLine($"b's encontrados: {contadorB}");
            Console.WriteLine($"Resultado: {(aceita ? "ACEITA" : "REJEITA")}");
            
            return aceita;
        }
    }
}