using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeCarros.Entities
{
    internal class Fatura
    {
        public double Pagamento { get; set; }
        public double Imposto { get; set; }

        //public double ValorTotal { get { return Pagament * Imposto; } }

        public Fatura(double pagamento, double imposto)
        {
            Pagamento = pagamento;
            Imposto = imposto;
        }

        public double ValorTotal()
        {
            return Pagamento + Imposto;
        }
        public override string ToString()
        {
            return
                "\nFATURA:\nPagamento Básico: " +
                Pagamento.ToString("f2", CultureInfo.InvariantCulture) +
                "\nImposto: "
                + Imposto.ToString("f2", CultureInfo.InvariantCulture) +
                "\nValor Total: " +
                ValorTotal().ToString("f2", CultureInfo.InvariantCulture);

        }
    }
}
