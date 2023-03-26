using System;

namespace Solve
{
  namespace ExternalResources
  {
    [Serializable]
    public class ResourcesConfig
    {
      public ExternalConfig config;
      public ResourcesFolder[] folders;
    }
    [Serializable]
    public class ResourcesFolder
    {
      public string name;
      public string fileType;
      public ResourcesFile[] files;
    }
    [Serializable]
    public class ResourcesFile
    {
      public string name;
      public string placeholder;
    }
  }
}
