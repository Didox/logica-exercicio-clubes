using System;

namespace clubes_futebol
{
    class Jogo
    {
        public Clube Time1 {get;set;}
        public Clube Time2 {get;set;}
        public int ResultadoTime1 {get;set;}
        public int ResultadoTime2 {get;set;}

        public string Vencedor()
        {
            if(ResultadoTime1 == ResultadoTime2) return "O resultado foi Empate";
            return $"O ganhador do jogo foi { ((ResultadoTime1 > ResultadoTime2) ? Time1.Nome : Time2.Nome )}";
        }
  }
}
