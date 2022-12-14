using LocadoraDeCarros.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeCarros.Services
{
    internal class AluguelDoServico
    {

        public double PrecoHora { get; private set; }
        public double PrecoDiaria { get;  private set; }

        //Instanciação de um objeto Imposto Estadual MS para podermos utilizar o método Imposto.
        //public ImpostoEstadualMS ImpostoEstadualMS { get; set; } = new ImpostoEstadualMS();
        //Propriedade de composição do serviço Imposto Estadual.
        public IImposto Imposto { get; private set; }
        public AluguelDoServico(double precoHora, double precoDiaria, IImposto imposto)
        {
            PrecoHora = precoHora;
            PrecoDiaria = precoDiaria;
            Imposto = imposto;
        }

        //public AluguelDoServico(double precoHora, double precoDiaria)
        //{
        //    PrecoHora = precoHora;
        //    PrecoDiaria = precoDiaria;
        //}

        public void gerarFatura(Aluguel aluguel)
        {
            TimeSpan duracao = aluguel.Devolucao.Subtract(aluguel.Retirada);
            double pagamentoBasico = 0.0;

            if(duracao.TotalHours <= 12)
            {
                 pagamentoBasico = PrecoHora * Math.Ceiling(duracao.TotalHours); //Math Ceiling arredonda pra mais
            }
            else
            {
                pagamentoBasico = PrecoDiaria * Math.Ceiling(duracao.TotalDays);
            }
            double imposto = Imposto.CalcularImposto(pagamentoBasico);
            aluguel.Fatura = new Fatura(pagamentoBasico, imposto);
        }
    }
}
