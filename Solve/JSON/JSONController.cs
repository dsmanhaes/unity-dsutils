using System.IO;
using UnityEngine;

namespace Solve
{
  namespace JSON
  {
    using Debug;

    public static class JSONController
    {
      public static string JSONPath
      {
        get
        {
          if (Application.platform == RuntimePlatform.Android)
            return Application.persistentDataPath + "/_res/";
          else
            return Application.dataPath + "/../_res/";
        }
      }
      public static T GetObject<T>(string filename, T defaultValues)
      {
        string path = JSONPath + filename;
        Directory.CreateDirectory(JSONPath);
        if (File.Exists(path)) return LoadJSON<T>(filename, defaultValues);
        else
        {
          CreateJSON(path, defaultValues);
          return defaultValues;
        }
      }
      public static T OverwriteObject<T>(string filename, T values)
      {
        string path = JSONPath + filename;
        Directory.CreateDirectory(JSONPath);
        string json = CreateJSON(path, values);
        return JsonUtility.FromJson<T>(json);
      }
      private static T LoadJSON<T>(string filename, T defaultValues)
      {
        // TODO: Create an object validation, if fails, overwrite and return the default
        string path = JSONPath + filename;
        try {
          return JsonUtility.FromJson<T>(LoadRawJSON(path));
        } catch {
          DebugController.LogWarning(typeof(JSONController), "Overwritting incorrect file at " + path);
          return OverwriteObject<T>(filename, defaultValues);
        }
      }
      private static string LoadRawJSON(string path)
      {
        DebugController.Log(typeof(JSONController), "Loading JSON file at " + path);
        return File.ReadAllText(path);
      }
      private static string CreateJSON<T>(string path, T defaultValues)
      {
        DebugController.Log(typeof(JSONController), "Creating JSON file at " + path);
        string json = JsonUtility.ToJson(defaultValues);
        File.WriteAllText(path, json);
        return json;
      }
    }
  }
}
