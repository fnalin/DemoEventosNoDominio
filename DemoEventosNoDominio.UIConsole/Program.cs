using DemoEventosNoDominio.Domain;
using DemoEventosNoDominio.Domain.Entidade;
using System;

namespace DemoEventosNoDominio.UIConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var pessoa = new Pessoa("Fabiano", 35);


            //Passando um método via função anônima ao Delegate
            pessoa.ExcedeuIdadeLimite += new ControleDeIdadeEventHandler((object source, ControleDeIdadeEventArgs e) =>
            {
                Console.WriteLine("Idade não permitida\nVocê tentou alterar de {0} para {1}", e.IdadeAntiga, e.IdadeNova);
            });

            //Disparando o evento
            pessoa.AlterarIdade(15);

            Console.ReadLine();

        }
    }
}
