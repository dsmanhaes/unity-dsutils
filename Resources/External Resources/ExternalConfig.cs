using System;

namespace Solve
{
  namespace ExternalResources
  {
    [Serializable]
    public class ExternalConfig
    {
      public int gameTime;
      public MetaData meta;
    }
    [Serializable]
    public class MetaData
    {
      public ScreensFolder screens;
      public RacersFolder racers;
    }
    [Serializable]
    public class ScreensFolder
    {
      public ExternalFile idleScreen;
      public ExternalFile gameBackground;
      public ExternalFile gameoverScreen;
    }
    [Serializable]
    public class RacersFolder
    {
      public ExternalFile racer1;
      public ExternalFile racer2;
      public ExternalFile racer3;
      public ExternalFile racer4;
      public ExternalFile racer5;
    }
    [Serializable]
    public class ExternalFile
    {
      public string fileName;
      public int width;
      public int height;
    }
  }
}
