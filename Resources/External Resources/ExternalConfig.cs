using System;

namespace Solve
{
  namespace ExternalResources
  {
    [Serializable]
    public class ExternalConfig
    {
      public int quantityToShow;
      public int spawnerInterval;
      public int port;
      public int cupcake1X;
      public int cupcake1Y;
      public int cupcake1Scale;
      public int cupcake2X;
      public int cupcake2Y;
      public int cupcake2Scale;
      public int cupcake3X;
      public int cupcake3Y;
      public int cupcake3Scale;
      public MetaData meta;
    }
    [Serializable]
    public class MetaData
    {
      public GeneralFolder general;
      public VideoFolder video;
    }
    [Serializable]
    public class GeneralFolder
    {
      public string cristalBase;
      public string syrup01;
      public string syrup02;
      public string syrup03;
      public string syrup04;
      public string pan01;
      public string pan02;
      public string pan03;
      public string pan04;
      public string fruit01;
      public string fruit02;
      public string fruit03;
      public string fruit04;
      public string sprinkles01;
      public string sprinkles02;
      public string sprinkles03;
      public string sprinkles04;
      public string cake01;
      public string cake02;
      public string cake03;
      public string cake04;
      public string filling01;
      public string filling02;
      public string filling03;
      public string filling04;
      public string icing01;
      public string icing02;
      public string icing03;
      public string icing04;
    }
    [Serializable]
    public class VideoFolder
    {
      public string video;
    }
  }
}
