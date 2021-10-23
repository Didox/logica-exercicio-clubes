using System;
using System.Collections.Generic;
using System.Threading;

namespace clubes_futebol
{
    class Program
    {
        static List<Clube> clubesCadastrados = new List<Clube>();
        static void Main(string[] args)
        {
            /*
            * Flavio Austo da Silva, criu ou estádio de futebol, ele precisa armezenar o resultado 
            * dos jogos no telão do campo de futebol
            * faça um programa que cadastre alguns clubes(Nome) que futebol
            * depois crie um menu para possibilidar a criação de um jogo, selecionando
            * dois times diferentes e colocando o valor do resultado do jogo, exemplo
            * Flamento (x) vs (y) Corinthians 
            * mostre um relatório com a lista de resultados das combinações entre os times
            */

            List<Jogo> jogos = new List<Jogo>();

            while(true)
            {
                Console.Clear();
                Console.WriteLine("Escollha uma opção:");
                Console.WriteLine("1 - Cadastrar clube:");
                Console.WriteLine("2 - Cadastrar Jogo:");
                Console.WriteLine("3 - Listar jogos cadastrados:");
                Console.WriteLine("0 - Sair do programa:");

                try{
                    int opcao = Convert.ToInt16("0" + Console.ReadLine());

                    switch(opcao){
                        case 1:
                            clubesCadastrados.Add(cadastrorClube());
                            break;
                        case 2:
                            jogos.Add(cadastrarJogo());
                            break;
                        case 3:
                            listarJogos(jogos);
                            break;
                        case 0:
                            return;
                        default:
                            Console.Clear();
                            Console.WriteLine("Opção inválida");
                            Thread.Sleep(5000); // 5 segundos
                            break;
                    }
                }
                catch(Exception err){ 
                    Console.Clear();
                    Console.WriteLine(err.Message);
                    Thread.Sleep(5000); // 5 segundos
                    continue; 
                }
            }


            /*
            * Josevaldo, é dono de uma cadeia de fast food' 
            * faça um programa que cadastre os ingredientes de um hamburger
            * que cadastre um hambuger selecionando os ingredientes
            * faça um pedido para um cliente
            * selecionando os hambugers
            * no final do programa, mostre um relatório com os clientes e seus pedidos
            * com o detalhe sobre tudo, mostrando os hamburgers e os detalhes do hamburger
            Ex:

            Pedido do(a) XXX
            Ele escolheu os hamburgers
                - Gold Premim
                    - Salada
                    - Molho
                    - Carne
                    - Picles
                - Prata Gerge
                    - Salada
                    - Molho
                    - Carne
                    - Gergelim
            Valor total de R$ 200 reais
            ----------------------------------
            Pedido do(a) YYY
            Ele escolheu os hamburgers
                - Gold Premim
                    - Salada
                    - Molho
                    - Carne
                    - Picles
                - Prata Gerge
                    - Salada
                    - Molho
                    - Carne
                    - Gergelim
                - Prata Gerge
                    - Salada
                    - Molho
                    - Carne
                    - Gergelim
            Valor total de R$ 200 reais
            */

        }

        private static void listarJogos(List<Jogo> jogos)
        {
            Console.Clear();
            if(jogos.Count == 0)
                Console.WriteLine("Nenhum jogo cadastrado");
            else{
                foreach(var jogo in jogos){
                    Console.WriteLine($"{jogo.Time1.Nome} ({jogo.ResultadoTime1}) vs ({jogo.ResultadoTime2}) {jogo.Time2.Nome}");
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine(jogo.Vencedor());
                }
            }

            Thread.Sleep(5000); // 5 segundos
        }
        private static Jogo cadastrarJogo()
        {
            var jogo = new Jogo();
            Console.Clear();
            Console.WriteLine("Para cadastrar o primeiro time do jogo, selecione um clube abaixo:");
            if(!mostrarClubes()) throw new Exception("Não existe clubes cadastrados");
            int idClube1 = Convert.ToInt16("0" + Console.ReadLine());
            jogo.Time1 = clubesCadastrados.Find(c => c.Id == idClube1);
            if(jogo.Time1 == null) throw new Exception("ID do Clube digitado não existe");

            Console.Clear();
            Console.WriteLine("Para cadastrar o segundo time do jogo, selecione um clube abaixo:");
            if(!mostrarClubes()) throw new Exception("Não existe clubes cadastrados");
            int idClube2 = Convert.ToInt16("0" + Console.ReadLine());
            jogo.Time2 = clubesCadastrados.Find(c => c.Id == idClube2);
            if(jogo.Time2 == null) throw new Exception("ID do Clube digitado não existe");
            
            Console.WriteLine($"Digite o resultado do {jogo.Time1.Nome}:");
            jogo.ResultadoTime1 = Convert.ToInt16("0" + Console.ReadLine());

            Console.WriteLine($"Digite o resultado do {jogo.Time2.Nome}:");
            jogo.ResultadoTime2 = Convert.ToInt16("0" + Console.ReadLine());

            Console.Clear();
            Console.WriteLine($"Jogo foi cadastrado com sucesso !");
            Thread.Sleep(1000); // 1 segundo
            return jogo;
        }

        private static bool mostrarClubes()
        {
            if(clubesCadastrados.Count == 0){
                Console.WriteLine("Nenhum clube cadastrado cadastrado");
                return false;
            }
            else{
                foreach(var clube in clubesCadastrados){
                    Console.WriteLine($" {clube.Id} - {clube.Nome}");
                }
            }

            return true;
        }

        private static Clube cadastrorClube()
        {
            Console.Clear();
            Console.WriteLine("Digite o nome do clube");
            var clube = new Clube();
            clube.Id = clubesCadastrados.Count + 1;
            clube.Nome = Console.ReadLine();

            Console.Clear();
            Console.WriteLine($"Clube {clube.Nome} foi cadastrado com sucesso !");
            Thread.Sleep(1000); // 1 segundo
            return clube;
        }
    }
}
