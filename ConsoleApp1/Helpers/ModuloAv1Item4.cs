using System;
using System.Globalization;

namespace ConsoleApp1.Helpers
{
    public static class ModuloAv1Item4
    {
        public static void AvaliadorProposicional()
        {
            Console.Clear();
            Console.WriteLine("-------------------------");
            Console.WriteLine(" AVALIADOR PROPOSICIONAL ");
            Console.WriteLine("-------------------------");
            Console.WriteLine();

            int? opcao = EscolherFormula();
            if (opcao == 1)
            {
                FormulaUm();
            }
            else if (opcao == 2)
            {
                FormulaDois();
            }
            else
            {
                Console.WriteLine("Opcao Invalida!");
            }
            
            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
        private static int? EscolherFormula()
        {
            Console.WriteLine("Digite qual formula logica você quer: ");
            Console.WriteLine("1 - (P ^ Q) -> R");
            Console.WriteLine("2 - (P -> Q) V R");
            string? opcao = Console.ReadLine();
            int opcaoNumerica;
            if (string.IsNullOrWhiteSpace(opcao) || !int.TryParse(opcao, out  opcaoNumerica)) 
            {
                // sim, isso e porque nao da para retornar null direto
                return null;
            }

            return opcaoNumerica;
        }

        private static void FormulaUm()
        {
            bool resultado;
            bool[] respostas = AdquirirExpressoes();
            if (respostas == null)
            {
                return;
            }
            bool primeiraExpressao = respostas[0];
            bool segundaExpressao = respostas[1];
            bool terceiraExpressao = respostas[2];

            bool primeiraParte = primeiraExpressao && segundaExpressao;

            // Sim, isso parece redundadnte, mas para expressoes -> é necessario esse bloco pois
            // A expressao "&& !" somente irá retornar false se ambos forem falso, o que não queremos
            if (primeiraParte && !terceiraExpressao)
            {
                resultado = false;
            }
            else
            {
                resultado = true;
            }

            if (resultado)
            {
                Console.WriteLine("O resultado da formula é Verdadeiro");
            }
            else
            {
                Console.WriteLine("O resultado da formula é Falso");
            }

            Console.WriteLine();
            Console.WriteLine("Quer imprimir a tabela verdade? (s/n): ");
            Console.WriteLine();

            string? escolha = Console.ReadLine();
            escolha = escolha.Trim().ToLower();
            
            if ((escolha != "s") && (escolha != "n"))
            {
                Console.WriteLine("Escolha Inválida!");
            }
            else if (escolha == "s")
            {
                Console.WriteLine("P Q R | ( ( P ^ Q ) -> R )");
                Console.WriteLine("--------------------------");
                Console.WriteLine("V V V |   V V = V   V = V ");
                Console.WriteLine("V V F |   V V = V   F = F ");
                Console.WriteLine("V F V |   V F = F   V = V ");
                Console.WriteLine("V F F |   V F = F   F = V ");
                Console.WriteLine("F V V |   F V = F   V = V ");
                Console.WriteLine("F V F |   F V = F   F = V ");
                Console.WriteLine("F F V |   F F = F   V = V ");
                Console.WriteLine("F F F |   F F = F   F = V ");
            }
            return;
        }

        private static void FormulaDois()
        {
            bool resultado;
            bool[] respostas = AdquirirExpressoes();
            if (respostas == null)
            {
                return;
            }
            bool primeiraExpressao = respostas[0];
            bool segundaExpressao = respostas[1];
            bool terceiraExpressao = respostas[2];

            bool primeiraParte;

            // Sim, isso parece redundadnte, mas para expressoes -> é necessario esse bloco pois
            // A expressao "&& !" somente irá retornar false se ambos forem falso, o que não queremos
            if (primeiraExpressao && !segundaExpressao)
            {
                primeiraParte = false;
            }
            else
            {
                primeiraParte = true;
            }

            resultado = primeiraParte || terceiraExpressao;

            if (resultado)
            {
                Console.WriteLine("O resultado da formula é Verdadeiro");
            }
            else
            {
                Console.WriteLine("O resultado da formula é Falso");
            }

            Console.WriteLine();
            Console.WriteLine("Quer imprimir a tabela verdade? (s/n): ");
            Console.WriteLine();

            string? escolha = Console.ReadLine();
            escolha = escolha.Trim().ToLower();

            Console.WriteLine();

            if ((escolha != "s") && (escolha != "n"))
            {
                Console.WriteLine("Escolha Inválida!");
            }
            else if (escolha == "s")
            {
                Console.WriteLine("P Q R | ( ( P -> Q ) V R )");
                Console.WriteLine("--------------------------");
                Console.WriteLine("V V V |   V V = V   V = V ");
                Console.WriteLine("V V F |   V V = V   F = V ");
                Console.WriteLine("V F V |   V F = F   V = V ");
                Console.WriteLine("V F F |   V F = F   F = F ");
                Console.WriteLine("F V V |   F F = V   V = V ");
                Console.WriteLine("F V F |   F F = V   F = V ");
                Console.WriteLine("F F V |   F F = V   V = V ");
                Console.WriteLine("F F F |   F F = V   F = V ");
            }
            return;
        }

        private static bool[]? AdquirirExpressoes()
        {
            bool[] expressoesBool =  new bool[3];
            string[] expressoesString = new string[3];
            Console.WriteLine("Digite o valor da primeira expressao proposicional 'P' (verdadeiro ou falso): ");
            string? primeiraExpressao = Console.ReadLine();
            
            if (!ValidadorExpressao(primeiraExpressao))
            {
                Console.WriteLine("Expressao Invalida!");
                return null;
            }
            expressoesString[0] = primeiraExpressao.Trim().ToLower();

            Console.WriteLine("Digite o valor da segunda expressao proposicional 'Q' (verdadeiro ou falso): ");
            string? segundaExpressao = Console.ReadLine();

            if (!ValidadorExpressao(segundaExpressao))
            {
                Console.WriteLine("Expressao Invalida!");
                return null;
            }
            expressoesString[1] =segundaExpressao.Trim().ToLower();

            Console.WriteLine("Digite o valor da terceira expressao proposicional 'R' (verdadeiro ou falso): ");
            string? terceiraExpressao = Console.ReadLine();

            if (!ValidadorExpressao(terceiraExpressao))
            {
                Console.WriteLine("Expressao Invalida!");
                return null;
            }
            expressoesString[2]=terceiraExpressao.Trim().ToLower();

            for (int i = 0; i < expressoesString.Length; i++)
            {
                if (expressoesString[i] == "falso")
                {
                    expressoesBool[i] = false;
                }
                else if (expressoesString[i] == "verdadeiro")
                {
                    expressoesBool[i] = true;
                }
            }

            return expressoesBool;
        }

        private static bool ValidadorExpressao(string expressao)
        {
            bool returnValue = true;
            expressao = expressao.Trim().ToLower();
            if ((string.IsNullOrEmpty(expressao)) || (string.IsNullOrWhiteSpace(expressao)))
            {
                returnValue = false;
            }
            if ((expressao != "falso") && (expressao != "verdadeiro"))
            {
                returnValue = false;
            }
            return returnValue;
        }
    }
}