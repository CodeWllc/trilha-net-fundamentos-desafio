using System;

namespace DesafioFundamentos.Models
{
    public class VeiculoEstacionado
    {
        public string Placa { get; set; }
        public DateTime Entrada { get; set; }

        public VeiculoEstacionado(string placa)
        {
            Placa = placa.ToUpper();
            Entrada = DateTime.Now;
        }
    }
}