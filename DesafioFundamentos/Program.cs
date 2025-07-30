using DesafioFundamentos.Models;

// Coloca o encoding para UTF8 para exibir acentuação
Console.OutputEncoding = System.Text.Encoding.UTF8;

decimal precoInicial = 0;
decimal precoPorHora = 0;

Console.WriteLine("Seja bem vindo ao sistema de estacionamento!\n");
while (true)
{
    Console.Write("Digite o preço inicial: ");
    string entrada = Console.ReadLine();
    if (decimal.TryParse(entrada, out precoInicial) && precoInicial >= 0)
        break;
    Console.WriteLine("Valor inválido. Digite um número válido para o preço inicial.");
}

while (true)
{
    Console.Write("Agora digite o preço por hora: ");
    string entrada = Console.ReadLine();
    if (decimal.TryParse(entrada, out precoPorHora) && precoPorHora >= 0)
        break;
    Console.WriteLine("Valor inválido. Digite um número válido para o preço por hora.");
}

Estacionamento es = new Estacionamento(precoInicial, precoPorHora);

bool exibirMenu = true;
while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine("1 - Cadastrar veículo");
    Console.WriteLine("2 - Remover veículo");
    Console.WriteLine("3 - Listar veículos");
    Console.WriteLine("4 - Encerrar");

    string opcao = string.Empty;
    while (true)
    {
        opcao = Console.ReadLine();
        if (opcao == "1" || opcao == "2" || opcao == "3" || opcao == "4")
            break;
        Console.WriteLine("Opção inválida. Digite 1, 2, 3 ou 4:");
    }

    switch (opcao)
    {
        case "1":
            es.AdicionarVeiculo();
            break;
        case "2":
            es.RemoverVeiculo();
            break;
        case "3":
            es.ListarVeiculos();
            break;
        case "4":
            exibirMenu = false;
            break;
    }

    Console.WriteLine("Pressione uma tecla para continuar");
    Console.ReadLine();
}

Console.WriteLine("O programa se encerrou");
