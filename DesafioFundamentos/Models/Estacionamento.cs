using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto___Estacionamento.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculosEstacionados = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a Placa do Veículo (Padrão: ABC-1234) para estacionar: ");
            string? placaVeiculo = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(placaVeiculo))
            {
                Console.WriteLine("Entre com um valor válido!");
                placaVeiculo = Console.ReadLine();
            }

            veiculosEstacionados.Add(placaVeiculo.ToUpper());
            Console.WriteLine($"Veiculo {placaVeiculo.ToUpper()} adicionado com sucesso!");
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculosEstacionados.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (string veiculo in veiculosEstacionados)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            string? placaVeiculo = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(placaVeiculo))
            {
                Console.WriteLine("Entre com um valor válido!");
                placaVeiculo = Console.ReadLine();
            }

            // Verifica se o veículo existe
            if (veiculosEstacionados.Any(x => x.ToUpper() == placaVeiculo.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                int horas = Convert.ToInt32(Console.ReadLine());
                decimal valorTotal = 0;

                valorTotal = horas * precoPorHora + precoInicial;

                veiculosEstacionados.Remove(placaVeiculo.ToUpper());

                Console.WriteLine($"Preço Hora: R$ {precoPorHora} \nPreço Inicial: R$ {precoInicial}");
                Console.WriteLine($"O veículo {placaVeiculo.ToUpper()} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }
    }
}