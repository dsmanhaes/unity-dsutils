using System;

namespace Solve
{
  namespace ExternalTexts
  {
    [Serializable]
    public class ImportedTexts
    {
      public IdleScreen idle;
      public ChooseScreen choose;
      public EndScreen end;
    }
    [Serializable]
    public class IdleScreen
    {
      public string balaoMagali;
      public string botao;
    }
    [Serializable]
    public class ChooseScreen
    {
      public string buttonBack;
      public string buttonNext;
      public string buttonFinish;
      public string balaoMagali01;
      public string balaoMagali01Choosed;
      public string balaoMagali02;
      public string balaoMagali02Choosed;
      public string balaoMagali03;
      public string balaoMagali03Choosed;
      public string balaoMagali04;
      public string balaoMagali04Choosed;
      public string balaoMagali05;
      public string balaoMagali05Choosed;
      public string balaoMagali06;
      public string balaoMagali06Choosed;
      public string balaoMagali07;
      public string balaoMagali07Choosed;
    }
    [Serializable]
    public class EndScreen
    {
      public string balaoMagali;
    }
  }
}
