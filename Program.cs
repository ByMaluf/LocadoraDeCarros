using LocadoraDeCarros.Entities;
using LocadoraDeCarros.Services;
using System.Globalization;

namespace LocadoraDeCarros
{
    internal class Program
    {
        static void Main(string[] args)
        {
          
            Console.WriteLine();
            Console.Write("Modelo do carro: ");
            string nomeModelo = Console.ReadLine();

            //Veiculo veiculo = new Veiculo(nomeModelo);
    
            Console.Write("Data de Retirada : ");
            DateTime retirada = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            Console.Write("Data de Devolução : ");
            DateTime devolucao = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

            Aluguel aluguel = new Aluguel(retirada, devolucao, new Veiculo(nomeModelo));

            Console.Write("Preço por hora : ");
            double precoHora = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Preço por dia : ");
            double precoDia = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.WriteLine();

            AluguelDoServico aluguelDoServico = new AluguelDoServico(precoHora, precoDia, new ImpostoEstadualMS());

            aluguelDoServico.gerarFatura(aluguel);

            Console.WriteLine(aluguel.Fatura);

        }
    }
}