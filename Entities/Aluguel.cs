using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeCarros.Entities
{
    internal class Aluguel
    {
        public DateTime Retirada { get; set; }
        public DateTime Devolucao { get; set; }
        public Veiculo Veiculo { get; set; } //Properiedade de composição da entidade da classe Veiculo
        public Fatura Fatura { get; set; } //Properiedade de composição da entidade da classe Fatura

        public Aluguel(DateTime retirada, DateTime devolucao, Veiculo veiculo)
        {
            Retirada = retirada;
            Devolucao = devolucao;
            Veiculo = veiculo;
        }
    }
}
