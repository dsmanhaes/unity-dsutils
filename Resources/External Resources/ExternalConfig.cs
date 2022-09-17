using System;
using System.Collections;
using System.Collections.Generic;

namespace Solve {

  namespace ExternalResources {

    [Serializable]
    public class ExternalConfig {
      public int gameTime;
      public float boat5LossDistance;
      public ExternalFolder[] meta;
    }

    [Serializable]
    public class ExternalFolder {
      public string name;
      public ExternalFile[] files;
    }

    [Serializable]
    public class ExternalFile {
      public string name;
      public string fileName;
      public int width;
      public int height;
    }
  }
}
