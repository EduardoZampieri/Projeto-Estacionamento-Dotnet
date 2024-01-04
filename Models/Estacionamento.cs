using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;

namespace Projeto_Estacionamento.Models
{
    public class Estacionamento
    {
        public List<string> CarrosEstacionados = new List<string>();
        private decimal ValorInicial {get; set;}
        private decimal ValorPorHora {get; set;}

        public Estacionamento(decimal ValorInicial, decimal ValorPorHora) {
            this.ValorInicial = ValorInicial;
            this.ValorPorHora = ValorPorHora;
        }

        public void AdicionarCarro(string PlacaDoVeiculo) {
            bool PlacaJaExistente = CarrosEstacionados.Contains(PlacaDoVeiculo.ToUpper());
            if (!PlacaJaExistente) {
                CarrosEstacionados.Add(PlacaDoVeiculo.ToUpper());
            }
            else {
                throw new Exception("Placa do Carro já existente");
            }
        }

        public void RemoverCarro(string PlacaDoVeiculo) {
            bool PlacaJaExistente = CarrosEstacionados.Contains(PlacaDoVeiculo.ToUpper());

            if (PlacaJaExistente) {
                CarrosEstacionados.Remove(PlacaDoVeiculo);
                decimal TotalAPagar = Cobrar();
                Console.WriteLine($"O veículo {PlacaDoVeiculo.ToUpper()} foi removido e o preço total a pagar foi de: {TotalAPagar:C}");
            }
            else {
                throw new Exception("Placa não encontrada no estacionamento");
            }
        }

        public decimal Cobrar() {    
            Console.WriteLine("Digite quantas horas o veículo passou estacionado: ");
            int HorasEstacionado = Convert.ToInt32(Console.ReadLine());
            return ValorInicial + (ValorPorHora * HorasEstacionado);
        }

        public void ListarCarrosEstacionados() {
            if (CarrosEstacionados.Count > 0) {
                Console.WriteLine("Carros estacionados: ");
                foreach(string Placa in CarrosEstacionados) {
                    Console.WriteLine($"| {Placa} |");
                }
            }
            else {
                Console.WriteLine("Não há carros estacionados");
            }
        }
    }
}