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

            int opcao = EscolherFormula();
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
        private static int EscolherFormula()
        {
            Console.WriteLine("Digite qual formula logica voce quer: ");
            Console.WriteLine("Opcao 1: (P ^ Q) -> R");
            Console.WriteLine("Opcao 2: (P -> Q) V R");
            int opcao = int.Parse(Console.ReadLine());

            return opcao;
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
            // A expressao "&& !" irá retornar false se ambos forem falso, o que não queremos
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
                Console.WriteLine("O resultado da formula e Verdadeiro");
            }
            else
            {
                Console.WriteLine("O resultado da formula e Falso");
            }

            Console.WriteLine();
            Console.WriteLine("Quer imprimir a tabela verdade? (s/n): ");
            Console.WriteLine();

            string escolha = Console.ReadLine();
            
            if ((escolha != "s") && (escolha != "n"))
            {
                Console.WriteLine("ESCOLHA INVALIDA!");
            }
            else if (escolha == "s")
            {
                Console.WriteLine("P Q R | ( ( P ^ Q ) -> R )");
                Console.WriteLine("--------------------------");
                Console.WriteLine("V V V |   V V = V   V = V ");
                Console.WriteLine("V V F |   V V = V   F = F ");
                Console.WriteLine("V F V |   V F = F   V = V ");
                Console.WriteLine("V F F |   V F = F   V = F ");
                Console.WriteLine("F V V |   F F = V   V = V ");
                Console.WriteLine("F V F |   F F = V   V = F ");
                Console.WriteLine("F F V |   F F = F   V = V ");
                Console.WriteLine("F F F |   F F = F   V = F ");
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
            // A expressao "&& !" irá retornar false se ambos forem falso, o que não queremos
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
                Console.WriteLine("O resultado da formula e Verdadeiro");
            }
            else
            {
                Console.WriteLine("O resultado da formula e Falso");
            }

            Console.WriteLine();
            Console.WriteLine("Quer imprimir a tabela verdade? (s/n): ");
            Console.WriteLine();

            string escolha = Console.ReadLine();

            if ((escolha != "s") && (escolha != "n"))
            {
                Console.WriteLine("ESCOLHA INVALIDA!");
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

        private static bool[] AdquirirExpressoes()
        {
            bool[] expressoesBool =  new bool[3];
            string[] expressoesString = new string[3];
            Console.WriteLine("Digite o valor da primeira expressao proposicional (verdadeiro ou falso): ");
            string? primeiraExpressao = Console.ReadLine();
            
            if (!ValidadorExpressao(primeiraExpressao))
            {
                Console.WriteLine("Expressao Invalida!");
                return null;
            }
            expressoesString.Append(primeiraExpressao.ToLower());

            Console.WriteLine("Digite o valor da segunda expressao proposicional(verdadeiro ou falso): ");
            string? segundaExpressao = Console.ReadLine();

            if (!ValidadorExpressao(segundaExpressao))
            {
                Console.WriteLine("Expressao Invalida!");
                return null;
            }
            expressoesString.Append(segundaExpressao.ToLower());

            Console.WriteLine("Digite o valor da terceira expressao proposicional(verdadeiro ou falso): ");
            string? terceiraExpressao = Console.ReadLine();

            if (!ValidadorExpressao(terceiraExpressao))
            {
                Console.WriteLine("Expressao Invalida!");
                return null;
            }
            expressoesString.Append(terceiraExpressao.ToLower());

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
            if ((expressao != "falso") || (expressao != "verdadeiro"))
            {
                returnValue = false;
            }
            return returnValue;
        }
    }
}