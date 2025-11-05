using System;
using System.Collections.Generic;

namespace ConsoleApp1.Helpers
{
    public class EstadoAFD
    {
        public string Nome { get; set; } = string.Empty;
        public bool EhFinal { get; set; }
        public Dictionary<char, string> Transicoes { get; set; } = new Dictionary<char, string>();
    }

    public static class ModuloAv2Item5
    {
        private static readonly Dictionary<string, EstadoAFD> afd = new Dictionary<string, EstadoAFD>
        {
            ["q0"] = new EstadoAFD 
            { 
                Nome = "q0", 
                EhFinal = false,
                Transicoes = new Dictionary<char, string> { {'a', "q0"}, {'b', "q1"} }
            },
            ["q1"] = new EstadoAFD 
            { 
                Nome = "q1", 
                EhFinal = true,
                Transicoes = new Dictionary<char, string> { {'a', "q0"}, {'b', "q1"} }
            }
        };

        public static void ExecutarSimuladorAFD()
        {
            Console.Clear();
            Console.WriteLine("=== SIMULADOR DE AFD ===");
            Console.WriteLine("AFD que reconhece: palavras que terminam com 'b'");
            Console.WriteLine("Alfabeto: Σ = {a, b}");
            Console.WriteLine();
            
            MostrarAFD();
            
            Console.Write("Digite uma cadeia para processar: ");
            string? cadeia = Console.ReadLine();

            if (string.IsNullOrEmpty(cadeia))
            {
                Console.WriteLine("Cadeia vazia será processada.");
                cadeia = "";
            }

            // Validar alfabeto
            foreach (char c in cadeia)
            {
                if (c != 'a' && c != 'b')
                {
                    Console.WriteLine($"Erro: Símbolo '{c}' não pertence ao alfabeto Σ = {{a, b}}");
                    Console.ReadKey();
                    return;
                }
            }

            ProcessarCadeia(cadeia);
            
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        private static void MostrarAFD()
        {
            Console.WriteLine("Estrutura do AFD:");
            Console.WriteLine("Estados: {q0, q1}");
            Console.WriteLine("Estado inicial: q0");
            Console.WriteLine("Estados finais: {q1}");
            Console.WriteLine("Transições:");
            Console.WriteLine("  δ(q0, a) = q0");
            Console.WriteLine("  δ(q0, b) = q1");
            Console.WriteLine("  δ(q1, a) = q0");
            Console.WriteLine("  δ(q1, b) = q1");
            Console.WriteLine();
        }

        private static void ProcessarCadeia(string cadeia)
        {
            string estadoAtual = "q0"; // Estado inicial
            
            Console.WriteLine("=== EXECUÇÃO PASSO A PASSO ===");
            Console.WriteLine($"Estado inicial: {estadoAtual} {(afd[estadoAtual].EhFinal ? "(final)" : "(não-final)")}");
            
            if (string.IsNullOrEmpty(cadeia))
            {
                Console.WriteLine("Cadeia vazia - nenhum símbolo para processar.");
            }
            else
            {
                for (int i = 0; i < cadeia.Length; i++)
                {
                    char simbolo = cadeia[i];
                    
                    Console.WriteLine($"Lendo símbolo '{simbolo}'...");
                    
                    if (afd[estadoAtual].Transicoes.ContainsKey(simbolo))
                    {
                        string proximoEstado = afd[estadoAtual].Transicoes[simbolo];
                        Console.WriteLine($"  δ({estadoAtual}, {simbolo}) = {proximoEstado}");
                        estadoAtual = proximoEstado;
                        Console.WriteLine($"  Estado atual: {estadoAtual} {(afd[estadoAtual].EhFinal ? "(final)" : "(não-final)")}");
                    }
                    else
                    {
                        Console.WriteLine($"  Erro: Não há transição definida para δ({estadoAtual}, {simbolo})");
                        Console.WriteLine("  REJEITA - transição indefinida");
                        return;
                    }
                    
                    Console.WriteLine();
                }
            }

            // Verificar aceitação
            bool aceita = afd[estadoAtual].EhFinal;
            
            Console.WriteLine("=== RESULTADO ===");
            Console.WriteLine($"Estado final: {estadoAtual}");
            Console.WriteLine($"Estado é final? {(aceita ? "SIM" : "NÃO")}");
            Console.WriteLine($"Resultado: {(aceita ? "ACEITA" : "REJEITA")}");
            
            if (aceita)
            {
                Console.WriteLine($"A cadeia '{cadeia}' pertence à linguagem.");
            }
            else
            {
                Console.WriteLine($"A cadeia '{cadeia}' NÃO pertence à linguagem.");
            }
        }
    }
}