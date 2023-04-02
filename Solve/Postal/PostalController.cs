using UnityEngine;

namespace Solve
{
  namespace Postal
  {
    using JSON;
    using Debug;

    public class PostalController
    {
      public static string PostalPath
      { get { return _configsCache.abspath; } }
      public static string PostalURL
      { get { return _configsCache.url; } }
      private static PostalConfig _configs;
      private static PostalConfig _configsCache
      {
        get
        {
          if (_configs == null) LoadConfig();
          return _configs;
        }
      }
      private static void LoadConfig()
      {
        string path = Application.dataPath + "/../../postal.json";
        PostalConfig defaultConfig = new PostalConfig();
        defaultConfig.url = "https://postal.social/projeto/?";
        defaultConfig.abspath = "C:/Teste/";
        _configs = JSONController<PostalConfig>.GetObject(path, defaultConfig);
        if (string.IsNullOrEmpty(_configs.url) ||
            string.IsNullOrEmpty(_configs.abspath))
        _configs = JSONController<PostalConfig>.OverwriteObject(path, defaultConfig);
        DebugController.Log(typeof(PostalController), "Configurations loaded");
      }
    }
  }
}
