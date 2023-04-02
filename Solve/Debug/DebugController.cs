namespace Solve
{
  namespace Debug
  {
    using UnityEngine;

    public static class DebugController
    {
      public static void Log(System.Type type, string message)
      { Debug.Log(GetMessage("INFO", type, message)); }
      public static void LogWarning(System.Type type, string message)
      { Debug.LogWarning(GetMessage("WARNING", type, message)); }
      public static void Error(System.Type type, string message)
      { throw new System.Exception(GetMessage("ERROR", type, message)); }
      private static string GetMessage(string logType, System.Type type, string message)
      { return logType + " - " + type.Namespace + "." + type.Name + ": " + message; }
    }
  }
}
