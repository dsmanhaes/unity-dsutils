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
        string path = "postal.json";
        PostalConfig defaultConfig = new PostalConfig();
        _configs = JSONController.GetObject<PostalConfig>(path, defaultConfig);
        if (string.IsNullOrEmpty(_configs.url) ||
            string.IsNullOrEmpty(_configs.abspath))
        _configs = JSONController.OverwriteObject<PostalConfig>(path, defaultConfig);
        DebugController.Log(typeof(PostalController), "Configurations loaded");
      }
    }
  }
}
