using UnityEngine;

namespace Solve
{
  namespace ExternalTexts
  {
    using JSON;
    using Debug;

    public static class ExternalTexts
    {
      public static ImportedTexts texts
      {
        get
        {
          if (_texts == null) LoadTexts();
          return _texts;
        }
      }
      private static ImportedTexts _texts;
      private static void LoadTexts()
      {
        DebugController.Log(typeof(ExternalTexts), "Starting to load texts...");
        TextAsset rawJson = Resources.Load<TextAsset>("External Texts/external_texts");
        ImportedTexts defaultTexts = JsonUtility.FromJson<ImportedTexts>(rawJson.text);
        _texts = JSONController.GetObject<ImportedTexts>("texts.json", defaultTexts);
        DebugController.Log(typeof(ExternalTexts), "Loaded all texts");
      }
    }
  }
}
