namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<VeiculoEstacionado> veiculos = new List<VeiculoEstacionado>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();
            if (PlacaValida(placa))
            {
                veiculos.Add(new VeiculoEstacionado(placa));
                Console.WriteLine($"Veículo {placa.ToUpper()} cadastrado com sucesso!");
            }
            else
            {
                Console.WriteLine("Placa inválida. Tente novamente.");
            }
        }

        private bool PlacaValida(string placa)
        {
            if (string.IsNullOrWhiteSpace(placa)) return false;
            placa = placa.ToUpper().Replace("-", "");
            // Padrão antigo: 3 letras + 4 números (AAA0000)
            if (System.Text.RegularExpressions.Regex.IsMatch(placa, @"^[A-Z]{3}[0-9]{4}$"))
                return true;
            // Padrão Mercosul: 3 letras + 1 número + 1 letra + 2 números (AAA0A00)
            if (System.Text.RegularExpressions.Regex.IsMatch(placa, @"^[A-Z]{3}[0-9][A-Z][0-9]{2}$"))
                return true;
            return false;
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine();

            var veiculo = veiculos.FirstOrDefault(x => x.Placa == placa.ToUpper());
            if (veiculo != null)
            {
                DateTime saida = DateTime.Now;
                TimeSpan tempo = saida - veiculo.Entrada;
                double totalHoras = tempo.TotalHours;
                int horasCheias = (int)Math.Ceiling(totalHoras);
                if (horasCheias == 0) horasCheias = 1; // Cobra pelo menos 1 hora

                Console.WriteLine("Escolha o tipo de cobrança:");
                Console.WriteLine("1 - Cobrar por hora cheia (padrão)");
                Console.WriteLine("2 - Cobrar proporcional ao tempo (fração de hora)");
                
                string tipoCobranca = string.Empty;
                while (true)
                {
                    tipoCobranca = Console.ReadLine();
                    if (tipoCobranca == "1" || tipoCobranca == "2")
                        break;
                    Console.WriteLine("Opção inválida. Digite 1 ou 2:");
                }

                decimal valorTotal = 0;
                string detalheTempo = "";
                if (tipoCobranca == "2")
                {
                    valorTotal = precoInicial + precoPorHora * (decimal)totalHoras;
                    detalheTempo = $"{tempo.TotalMinutes:F0} minutos ({totalHoras:F2} horas)";
                }
                else
                {
                    valorTotal = precoInicial + precoPorHora * horasCheias;
                    detalheTempo = $"{horasCheias} hora(s) (arredondado)";
                }

                veiculos.Remove(veiculo);
                Console.WriteLine($"O veículo {placa.ToUpper()} foi removido após {detalheTempo} e o preço total foi de: R$ {valorTotal:F2}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var v in veiculos)
                {
                    Console.WriteLine($"{v.Placa} - Entrada: {v.Entrada}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

    }
}