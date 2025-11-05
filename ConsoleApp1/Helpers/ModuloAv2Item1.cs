using System;
using System.Text.Json;

namespace ConsoleApp1.Helpers
{
    public class ItemProblemaInstancia
    {
        public string Descricao { get; set; } = string.Empty;
        public string RespostaCorreta { get; set; } = string.Empty;
    }

    public static class ModuloAv2Item1
    {
        private static readonly string JsonItens = """
        [
            {"Descricao": "Determinar se um grafo é conexo", "RespostaCorreta": "P"},
            {"Descricao": "Verificar se o grafo G1 com 5 vértices é conexo", "RespostaCorreta": "I"},
            {"Descricao": "Encontrar o caminho mais curto entre dois vértices", "RespostaCorreta": "P"},
            {"Descricao": "Qual o caminho mais curto de A para B no grafo G2?", "RespostaCorreta": "I"},
            {"Descricao": "Ordenar uma lista de números", "RespostaCorreta": "P"},
            {"Descricao": "Ordenar a lista [3,1,4,1,5,9,2,6]", "RespostaCorreta": "I"},
            {"Descricao": "Verificar se um número é primo", "RespostaCorreta": "P"},
            {"Descricao": "O número 97 é primo?", "RespostaCorreta": "I"},
            {"Descricao": "Calcular o fatorial de um número", "RespostaCorreta": "P"},
            {"Descricao": "Qual o fatorial de 5?", "RespostaCorreta": "I"}
        ]
        """;

        public static void ExecutarClassificadorProblemaInstancia()
        {
            Console.Clear();
            Console.WriteLine("=== CLASSIFICADOR PROBLEMA x INSTÂNCIA ===");
            Console.WriteLine("Classifique cada item como:");
            Console.WriteLine("P - Problema (descrição geral)");
            Console.WriteLine("I - Instância (caso específico)");
            Console.WriteLine();

            ItemProblemaInstancia[]? itens = JsonSerializer.Deserialize<ItemProblemaInstancia[]>(JsonItens);
            if (itens == null)
            {
                Console.WriteLine("Erro ao carregar dados.");
                Console.ReadKey();
                return;
            }

            int acertos = 0;
            int total = itens.Length;

            for (int i = 0; i < itens.Length; i++)
            {
                Console.WriteLine($"Item {i + 1}: {itens[i].Descricao}");
                Console.Write("Sua resposta (P/I): ");
                
                string? resposta = Console.ReadLine()?.ToUpper().Trim();
                
                if (string.IsNullOrWhiteSpace(resposta) || (resposta != "P" && resposta != "I"))
                {
                    Console.WriteLine("Resposta inválida! Use P ou I.");
                    i--; // Repetir a pergunta
                    continue;
                }

                if (resposta == itens[i].RespostaCorreta)
                {
                    Console.WriteLine("✓ Correto!");
                    acertos++;
                }
                else
                {
                    Console.WriteLine($"✗ Incorreto. Resposta: {itens[i].RespostaCorreta}");
                }
                Console.WriteLine();
            }

            Console.WriteLine("=== RESULTADO ===");
            Console.WriteLine($"Acertos: {acertos}/{total}");
            Console.WriteLine($"Percentual: {(acertos * 100.0 / total):F1}%");
            
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
}