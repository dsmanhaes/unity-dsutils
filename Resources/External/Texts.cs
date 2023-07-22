namespace Solve
{
  namespace External
  {
    namespace Impl
    {
      public class Texts
      {
        [System.Serializable]
        public class TelaEspera 
        {
          public string button = "INICIAR";
          public string cta = "Monte o seu\ncupcake na cozinha\ninteligente da\nDreamhouse.";
        }
        public class TelaEscolhas
        {
          public string next = "AVANÇAR";
          public string finish = "CONCLUIR";
          public string txtPasso1 = "Escolha uma\nforminha e\ndepois toque\nem avançar.";
          public string txtPasso2 = "Agora escolha o\nsabor da massa\ne depois toque\nem avançar.";
          public string txtPasso3 = "Agora escolha\numa calda e\ndepois toque em\navançar.";
          public string txtPasso4 = "Escolha uma\ncoertura que\ncombine com o seu\ncupcake e depois\ntoque em avançar.";
          public string txtPasso5 = "Agora escolha um\nconfeito para deixar\nseu cupcake ainda\nmais bonito.\nDepois toque em\navançar.";
          public string txtPasso6 = "Para finalizar,\nescolha a frutinha\nque vai deixar seu\n bolinho ainda mais\nespecial. Depois\ntoque em concluir.";
        }
        public class TelaFinal
        {
          public string button = "FINALIZAR";
          public string txtQrcode = "Seu cupcake ficou incrível!\nEscaneie o código para guardá-lo.";
        }
        public TelaEspera telaEspera = new TelaEspera();
        public TelaEscolhas telaEscolhas = new TelaEscolhas();
        public TelaFinal telaFinal = new TelaFinal();
      }
    }
  }
}
