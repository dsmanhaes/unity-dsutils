using System.Collections.Generic;
using UnityEngine;

namespace Solve
{
  namespace ExternalResources
  {
    using JSON;
    using Debug;

    public static class ExternalResources
    {
      public static ExternalConfig config
      {
        get
        {
          if (_resourcesConfig == null) LoadConfigsCache();
          return _resourcesConfig.config;
        }
      }
      public static Dictionary<string, Dictionary<string, object>> contents
      {
        get
        {
          if (_resourcesConfig == null) LoadConfigsCache();
          return _resourcesContent;
        }
      }
      private static Dictionary<string, Dictionary<string, object>> _resourcesContent;
      private static string _externalPath = JSONController.JSONPath;
      private static ResourcesConfig _resourcesConfig;
      private static void LoadConfigsCache()
      {
        TextAsset rawJson = Resources.Load<TextAsset>("External Resources/external_resources");
        _resourcesConfig = JsonUtility.FromJson<ResourcesConfig>(rawJson.text);
        ExternalConfig defaultConfig = _resourcesConfig.config;
        _resourcesConfig.config = JSONController.GetObject<ExternalConfig>("config.json", defaultConfig);
        DebugController.Log(typeof(ExternalResources), "Loading external files...");
        _resourcesContent = FilesLoader.LoadAllFolders(_resourcesConfig.folders, _externalPath, _resourcesConfig.config.meta);
        DebugController.Log(typeof(ExternalResources), "All configurations was loaded");
      }
    }
  }
}
