using System.IO;
using UnityEngine;

namespace Solve
{
  namespace JSON
  {
    using Debug;

    public static class JSONController<T>
    {
      public static T GetObject(string path, T defaultValues)
      {
        if (File.Exists(path)) return JsonUtility.FromJson<T>(LoadJSON(path));
        else
        {
          CreateJSON(path, defaultValues);
          return defaultValues;
        }
      }
      public static T OverwriteObject(string path, T values)
      {
        string json = CreateJSON(path, values);
        return JsonUtility.FromJson<T>(json);
      }
      private static string LoadJSON(string path)
      {
        DebugController.Log(typeof(JSONController<T>), "Loading JSON file at " + path);
        return File.ReadAllText(path);
      }
      private static string CreateJSON(string path, T defaultValues)
      {
        DebugController.Log(typeof(JSONController<T>), "Creating JSON file at " + path);
        string json = JsonUtility.ToJson(defaultValues);
        File.WriteAllText(path, json);
        return json;
      }
    }
  }
}
