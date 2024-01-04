// Adicionar Carros na minha lista
// Remover Carros na minha lista
// Listar os Carros ainda presentes na minha lista
// Cobrar um preço dos carros removidos

using Projeto_Estacionamento.Models;


Console.WriteLine("Seja Bem-Vindo ao Sistema do Estacionamento");
Console.WriteLine("--------------------------");
Console.WriteLine("Digite o preço inicial: ");
decimal valorInicial = Convert.ToDecimal(Console.ReadLine());
Console.WriteLine("Digite o preço por hora: ");
decimal valorPorHora = Convert.ToDecimal(Console.ReadLine());

Estacionamento estacionamento = new Estacionamento(valorInicial, valorPorHora);

Console.Clear();

do {
    Console.WriteLine("Digite a sua opção: ");
    Console.WriteLine("1 - Cadastrar Veículo");
    Console.WriteLine("2 - Remover Veículo");
    Console.WriteLine("3 - Listar Veículos");
    Console.WriteLine("4 - Encerrar Programa");

    int opcao = Convert.ToInt32(Console.ReadLine());
    string placa;

    switch(opcao) {
        case 1:
            Console.WriteLine("Digite a placa do veículo para cadastrar: ");
            placa = Console.ReadLine().ToString();
            try {
                estacionamento.AdicionarCarro(placa);
            }
            catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }
            break;
        case 2:
            Console.WriteLine("Digite a placa do veículo para remover: ");
            placa = Console.ReadLine().ToString();
            try {
                estacionamento.RemoverCarro(placa);
            }
            catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }
            break;
        case 3:
            estacionamento.ListarCarrosEstacionados();
            break;
        case 4:
            Console.WriteLine("\nPrograma Encerrado!");
            Environment.Exit(1);
            break;
        default:
            Console.WriteLine("Opção inválida, tente selecionar alguma das opção descritas anteriormente");
            break;
    }

    Console.WriteLine("Pressione qualquer tecla para continuar");
    Console.ReadKey(true);
    Console.Clear();

}while(true);