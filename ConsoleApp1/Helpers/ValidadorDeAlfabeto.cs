using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Helpers
{
    public static class ValidadorDeAlfabeto
    {


        public static void ValidarAlfabeto()
        {
            Console.Clear();
            Console.WriteLine("---------------------");
            Console.WriteLine("VALIDADOR DE ALFABETO");
            Console.WriteLine("---------------------");
            
            Console.WriteLine("Opção 1 - Verificar se palavra contém letra");
            Console.WriteLine("Opção 2 - Verificar se todas as letras de uma cadeia pertencem a um alfabeto");
            Console.Write("Digite uma opção: ");
            string opcao = Console.ReadLine();

            int opcaoNumerica = Convert.ToInt32(opcao);

            switch (opcaoNumerica)
            {
                case 1:
                    VerificarLetraPalavra();
                    break;
                case 2:
                    VerificarTodasLetrasCadeia();
                    break;
                default:
                    Console.WriteLine("Opção invalida");
                    break;
            }
            Console.WriteLine("Pressione qualquer tecla");
            Console.ReadKey();
        }

        public static void VerificarLetraPalavra()
        {
            Console.WriteLine("Digite uma letra:");

            string letra = Console.ReadLine();

            Console.WriteLine("Digite uma palavra: ");

            string palavra = Console.ReadLine();

            // Verifica se a palavra contém a letra
            if (palavra.Contains(letra, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"A letra '{letra}' existe na palavra '{palavra}'.");
            }
            else
            {
                Console.WriteLine($"A letra '{letra}' NÃO existe na palavra '{palavra}'.");
            }
        }

        public static void VerificarTodasLetrasCadeia()
        {
            Console.WriteLine("Digite um alfabeto:");
            string alfabeto = Console.ReadLine();
            Console.WriteLine("Digite uma cadeia: ");
            string cadeia = Console.ReadLine();
            bool todasPertencem = true;
            // Percorre cada letra da cadeia
            foreach (char letra in cadeia)
            {
                // Verifica se a letra está no alfabeto (ignorando maiúsculas/minúsculas)
                if (!alfabeto.ToLower().Contains(letra.ToString().ToLower()))
                {
                    todasPertencem = false;
                    Console.WriteLine($"A letra '{letra}' NÃO pertence ao alfabeto.");
                    break;
                }
            }
            if (todasPertencem)
            {
                Console.WriteLine("Todas as letras da cadeia pertencem ao alfabeto.");
            }
        }
    }
}
