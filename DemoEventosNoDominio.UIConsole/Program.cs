using DemoEventosNoDominio.Domain.Entidade;
using System;

namespace DemoEventosNoDominio.UIConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var pessoa = new Pessoa("Fabiano", 35);
            
            pessoa.ExcedeuIdadeLimite += new ControleDeIdadeEventHandler((object source, EventArgs e) => {
                Console.WriteLine("Idade não permitida");
            });


            pessoa.AlterarIdade(15);

            Console.ReadLine();

        }
    }
}
