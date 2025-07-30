/*
 * ═══════════════════════════════════════════════════════════════════════════════════════════
 *                           🚗 SISTEMA DE ESTACIONAMENTO INTELIGENTE 🚗
 * ═══════════════════════════════════════════════════════════════════════════════════════════
 * 
 * 📋 RESUMO DAS MELHORIAS E CORREÇÕES IMPLEMENTADAS:
 * 
 * 🔧 CORREÇÕES DE BUGS CRÍTICOS:
 * • Corrigido erro de compilação na classe VeiculoEstacionado (faltava declaração da classe)
 * • Removidos arquivos duplicados que causavam conflitos de compilação
 * • Eliminadas declarações duplicadas de variáveis que impediam a execução
 * 
 * ✅ SISTEMA DE VALIDAÇÕES ROBUSTO:
 * • Validação inteligente para preços - não aceita mais texto ou valores negativos
 * • Validação completa do menu - apenas opções válidas são aceitas
 * • Validação de placas brasileiras - suporte aos formatos antigo (ABC1234) e Mercosul (ABC1D23)
 * • Validação de opções de cobrança - sistema à prova de erros do usuário
 * 
 * 🚀 FUNCIONALIDADES COMPLETAMENTE NOVAS:
 * • Criada classe VeiculoEstacionado para controle inteligente de tempo
 * • Sistema automático de registro de entrada com data/hora
 * • Calculadora de tempo estacionado em tempo real
 * • Duas opções de cobrança: hora cheia ou proporcional ao tempo
 * • PRIMEIRA HORA SEMPRE INCLUSA no preço inicial (como estacionamentos reais)
 * • Cobrança adicional apenas após ultrapassar a primeira hora
 * • Interface amigável com mensagens claras de erro e sucesso
 * 
 * 🎯 MELHORIAS NA EXPERIÊNCIA DO USUÁRIO:
 * • Sistema nunca mais trava com entradas inválidas
 * • Mensagens de erro claras e orientativas
 * • Validação em tempo real com loops até entrada válida
 * • Feedback imediato para todas as operações
 * 
 * 💡 IMPLEMENTAÇÕES TÉCNICAS AVANÇADAS:
 * • Uso de regex para validação de placas brasileiras
 * • Cálculo automático de tempo com TimeSpan
 * • Sistema de cobrança flexível (hora cheia vs proporcional)
 * • Lógica inteligente: primeira hora inclusa + cobrança de horas extras
 * • Exibição precisa de tempo (segundos, minutos ou horas conforme necessário)
 * • Arquitetura limpa com separação de responsabilidades
 * • Código otimizado sem duplicações ou dependências desnecessárias
 * 
 * 🏆 RESULTADO FINAL:
 * O projeto evoluiu de um esqueleto não funcional para um sistema completo,
 * robusto e pronto para uso profissional. Todas as funcionalidades foram
 * implementadas com foco na experiência do usuário e na confiabilidade do sistema.
 * 
 * ═══════════════════════════════════════════════════════════════════════════════════════════
 * Desenvolvido por: Wallace | GitHub: @CodeWllc
 * Data: Julho 2025 | Desafio DIO - Fundamentos .NET
 * ═══════════════════════════════════════════════════════════════════════════════════════════
 */

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
