using System;
using System.Collections;
using System.Collections.Generic;

namespace Solve {

  namespace ExternalResources {

    [Serializable]
    public class ResourcesConfig {
      public ExternalConfig config;
      public ResourcesFolder[] folders;
    }

    [Serializable]
    public class ResourcesFolder {
      public string name;
      public ResourcesFile[] files;
    }

    [Serializable]
    public class ResourcesFile {
      public string name;
      public string type;
      public string placeholder;
    }
  }
}
