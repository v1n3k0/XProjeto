using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XProjeto.Domain.Arguments.Jogador;
using XProjeto.Domain.Services;

namespace XProjeto.AppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando.....");

            var service = new ServiceJogador();
            Console.WriteLine("Criei instancia do serviço");

            //AutenticarJogadorRequest AutenticarRequest = new AutenticarJogadorRequest();
            //Console.WriteLine("Criei instacia do meu objeto request");
            //AutenticarRequest.Email = "vinicius@teste.com";
            //AutenticarRequest.Senha = "123456";

            //var response2 = service.AutenticarJogador(AutenticarRequest);

            //var AdicionarRequest = new AdicionarJogadorRequest()
            //{
            //    Email = "vinicius@email.com",
            //    PrimeiroNome = "Vinicius",
            //    UltimoNome = "Horiguchi",
            //    Senha = "123456"
            //};

            //var response = service.AdicionarJogador(AdicionarRequest);

            var result = service.ListarJogador();


            Console.WriteLine("Serviço é valido " + service.IsValid());

            service.Notifications.ToList().ForEach(x =>
            {
                Console.WriteLine(x.Message);
            });

            Console.ReadKey();

        }
    }
}
