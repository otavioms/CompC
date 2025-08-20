using ConsoleApp1.Helpers;

Boolean continuar = true;

while (continuar)
{
    Console.Clear();
    Console.WriteLine("---------------");
    Console.WriteLine("MENU DE OPÇÕES");
    Console.WriteLine("---------------");

    Console.WriteLine("1   - Validador de Alfabeto");
    Console.WriteLine("2   - Em construção");
    Console.WriteLine("3   - Em construção");
    Console.WriteLine("4   - Em construção");
    Console.WriteLine("5   - Em construção");
    Console.WriteLine("6   - Em construção");
    Console.WriteLine("7   - Em construção");
    Console.WriteLine("8   - Em construção");
    Console.WriteLine("9   - Em construção");
    Console.WriteLine("10  - Em construção");
    Console.WriteLine("0   - Sair");

    Console.Write("Informe uma opção: ");
    string opcao = Console.ReadLine(); 

    int opcaoNumerica = Convert.ToInt32(opcao);

    switch (opcaoNumerica)
            {
        case 1:
            ValidadorDeAlfabeto.ValidarAlfabeto();
            break;
        case 2:
            Console.WriteLine("Opcao 2 selecionada");
            break;
        case 3:
            Console.WriteLine("Opcao 3 selecionada");
            break;
        case 4:
            Console.WriteLine("Opcao 4 selecionada");
            break;
        case 5:
            Console.WriteLine("Opcao 5 selecionada");
            break;
        case 6:
            Console.WriteLine("Opcao 6 selecionada");
            break;
        case 7:
            Console.WriteLine("Opcao 7 selecionada");
            break;
        case 8:
            Console.WriteLine("Opcao 8 selecionada");
            break;
        case 9:
            Console.WriteLine("Opcao 9 selecionada");
            break;
        case 10:
            Console.WriteLine("Opcao 10 selecionada");
            break;
        case 0:
            continuar = false;
            break;
        default:
            Console.WriteLine("Opcao invalida");
            break;
    }
}
