using System;
using System.Collections.Generic;

namespace ConsoleApp1.Helpers
{
    public static class ModuloAv2Item4
    {
        public static void ExecutarDetectorLoop()
        {
            Console.Clear();
            Console.WriteLine("=== DETECTOR INGÊNUO DE LOOP ===");
            Console.WriteLine("Simula um processo que pode entrar em loop");
            Console.WriteLine("detectando repetição de estados.");
            Console.WriteLine();

            Console.Write("Digite o limite máximo de passos (ex: 50): ");
            string? limiteStr = Console.ReadLine();
            
            if (!int.TryParse(limiteStr, out int limitePasso) || limitePasso <= 0)
            {
                Console.WriteLine("Limite inválido! Usando 50 como padrão.");
                limitePasso = 50;
            }

            Console.Write("Digite um número inicial (ex: 7): ");
            string? numeroStr = Console.ReadLine();
            
            if (!int.TryParse(numeroStr, out int numeroInicial))
            {
                Console.WriteLine("Número inválido! Usando 7 como padrão.");
                numeroInicial = 7;
            }

            Console.WriteLine();
            Console.WriteLine($"Executando processo com número inicial {numeroInicial}...");
            Console.WriteLine("Processo: se par, divide por 2; se ímpar, multiplica por 3 e soma 1");
            Console.WriteLine();

            bool loopDetectado = ExecutarProcessoComDeteccao(numeroInicial, limitePasso);
            
            Console.WriteLine();
            Console.WriteLine("=== REFLEXÃO SOBRE FALSOS POSITIVOS/NEGATIVOS ===");
            Console.WriteLine();
            Console.WriteLine("FALSOS POSITIVOS:");
            Console.WriteLine("- O detector pode sinalizar loop quando o processo");
            Console.WriteLine("  apenas demora muito para convergir.");
            Console.WriteLine("- Estados podem se repetir temporariamente sem");
            Console.WriteLine("  formar um ciclo infinito real.");
            Console.WriteLine();
            Console.WriteLine("FALSOS NEGATIVOS:");
            Console.WriteLine("- Loops muito longos podem não ser detectados");
            Console.WriteLine("  se o limite de passos for muito baixo.");
            Console.WriteLine("- Processos com ciclos maiores que o limite");
            Console.WriteLine("  podem passar despercebidos.");
            Console.WriteLine();
            Console.WriteLine("LIMITAÇÕES:");
            Console.WriteLine("- Este é um detector 'ingênuo' baseado apenas");
            Console.WriteLine("  em repetição de estados.");
            Console.WriteLine("- Não consegue distinguir entre ciclos finitos");
            Console.WriteLine("  e loops infinitos reais.");
            
            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        private static bool ExecutarProcessoComDeteccao(int numeroInicial, int limitePasso)
        {
            HashSet<int> estadosVisitados = new HashSet<int>();
            List<int> sequencia = new List<int>();
            
            int atual = numeroInicial;
            int passo = 0;
            bool loopDetectado = false;

            while (passo < limitePasso)
            {
                Console.WriteLine($"Passo {passo + 1}: Estado = {atual}");
                
                // Verificar se já visitamos este estado
                if (estadosVisitados.Contains(atual))
                {
                    Console.WriteLine($"*** LOOP DETECTADO! Estado {atual} já foi visitado. ***");
                    loopDetectado = true;
                    break;
                }

                // Adicionar estado atual aos visitados
                estadosVisitados.Add(atual);
                sequencia.Add(atual);

                // Condição de parada (Conjectura de Collatz)
                if (atual == 1)
                {
                    Console.WriteLine("Processo convergiu para 1. Terminando.");
                    break;
                }

                // Aplicar regra: par -> /2, ímpar -> 3n+1
                if (atual % 2 == 0)
                {
                    atual = atual / 2;
                    Console.WriteLine($"    {sequencia[passo]} é par -> {sequencia[passo]}/2 = {atual}");
                }
                else
                {
                    atual = atual * 3 + 1;
                    Console.WriteLine($"    {sequencia[passo]} é ímpar -> 3×{sequencia[passo]}+1 = {atual}");
                }

                passo++;
            }

            if (passo >= limitePasso && atual != 1)
            {
                Console.WriteLine($"*** LIMITE DE PASSOS ATINGIDO ({limitePasso}) ***");
                Console.WriteLine("Processo interrompido - possível loop ou convergência lenta.");
            }

            Console.WriteLine();
            Console.WriteLine($"Estados únicos visitados: {estadosVisitados.Count}");
            Console.WriteLine($"Total de passos executados: {passo}");
            
            return loopDetectado;
        }
    }
}