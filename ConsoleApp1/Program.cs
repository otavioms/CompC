using ConsoleApp1.Helpers;

Boolean continuar = true;

while (continuar)
{
    Console.Clear();
    Console.WriteLine("--------------------------------");
    Console.WriteLine("Projeto Toolkit (versao simples)");
    Console.WriteLine("--------------------------------");
    Console.WriteLine("---- AV1 ----");
    Console.WriteLine("1 - Verificar alfabeto e cadeia (Σ={a,b})");
    Console.WriteLine("2 - Classificador T/I/N por JSON");
    Console.WriteLine("3 - Decisor: termina com 'b'?");
    Console.WriteLine("4 - Avaliador proposicional (P,Q,R)");
    Console.WriteLine("5 - Reconhecedor: L_par_a e a b*");
    Console.WriteLine("---- AV2 ----");
    Console.WriteLine("6 - Problema x instancia por JSON");
    Console.WriteLine("7 - Decisores: L_fim_b e L_mult3_b");
    Console.WriteLine("8 - Reconhecedor que pode nao terminar (a^i b^i)");
    Console.WriteLine("9 - Detector ingenuo de loop");
    Console.WriteLine("10 - Simulador AFD simples (termina com 'b')");
    Console.WriteLine("0 - Sair");

    Console.Write("Informe uma opção: ");
    string opcao = Console.ReadLine(); 

    int opcaoNumerica = Convert.ToInt32(opcao);

    switch (opcaoNumerica)
            {
        case 1:
            ModuloAv1Item1.ValidarAlfabetoECadeia();
            break;
        case 2:
            ModuloAv1Item2.ExecutarClassificadorTIN();
            break;
        case 3:
            Console.WriteLine("Ferramenta em construção");
            break;
        case 4:
            Console.WriteLine("Ferramenta em construção");
            break;
        case 5:
            Console.WriteLine("Ferramenta em construção");
            break;
        case 6:
            Console.WriteLine("Ferramenta em construção");
            break;
        case 7:
            Console.WriteLine("Ferramenta em construção");
            break;
        case 8:
            Console.WriteLine("Ferramenta em construção");
            break;
        case 9:
            Console.WriteLine("Ferramenta em construção");
            break;
        case 10:
            Console.WriteLine("Ferramenta em construção");
            break;
        case 0:
            continuar = false;
            break;
        default:
            Console.WriteLine("Opcao invalida");
            break;
    }
}
