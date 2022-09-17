using System.IO;
using System.Collections.Generic;
using UnityEngine;

namespace Solve {

  namespace ExternalResources {

    public static class ExternalResources {
      public static ExternalConfig config
      {
        get {
          LoadConfigsCache();
          return _resourcesConfig.config;
        }
      }
      public static Dictionary<string, ExternalContents> contents
      {
        get {
          LoadConfigsCache();
          return _resourcesContents;
        }
      }
      
      private static Dictionary<string, ExternalContents> _resourcesContents =
          new Dictionary<string, ExternalContents>();

      private static string _configFileName = "config.json";
      private static string _resourceFileName = "External Resources/external_resources";
      private static string _resourcePlaceholderFolder = "External Resources/Placeholders/";
      private static string _externalPath = Application.dataPath + "/../../" +
                                            Application.productName + "_res/";
      private static ResourcesConfig _resourcesConfig;

      private static void LoadConfigsCache () {
        if (_resourcesConfig == null) {
          TextAsset rawJson = Resources.Load<TextAsset>(_resourceFileName);
          _resourcesConfig = JsonUtility.FromJson<ResourcesConfig>(rawJson.text);

          Directory.CreateDirectory(_externalPath);
          if (File.Exists(_externalPath + _configFileName)) {
            LoadConfigFile();
          } else {
            CreateConfigFile();
          }

          VerifyFiles();
        }
      }

      private static void LoadConfigFile () {
        Debug.Log("ExternalResources: Loading configuration file at: " +
                  _externalPath + _configFileName);
        string json = File.ReadAllText(_externalPath + _configFileName);
        _resourcesConfig.config = JsonUtility.FromJson<ExternalConfig>(json);
      }

      private static void CreateConfigFile () {
        Debug.Log("ExternalResources: Creatig configuration file at: " +
                  _externalPath + _configFileName);
        string json = JsonUtility.ToJson(_resourcesConfig.config, true);
        File.WriteAllText(_externalPath + _configFileName, json);
      }

      private static void VerifyFiles () {
        Debug.Log("ExternalResources: Start external files verification...");
        int folderIndex = 0;

        foreach (ResourcesFolder folder in _resourcesConfig.folders) {
          ExternalFolder externalFolder = _resourcesConfig.config.meta[folderIndex];
          int fileIndex = 0;
          string path = _externalPath + folder.name + "/";
          Directory.CreateDirectory(path);
          _resourcesContents.Add(folder.name, new ExternalContents());

          foreach (ResourcesFile file in folder.files) {
            ExternalFile externalFile = externalFolder.files[fileIndex];
            Texture2D texture = new Texture2D(externalFile.width, externalFile.height);

            // TODO: Create other formats importation, using file.type
            if (File.Exists(path + externalFile.fileName)) {
              byte[] fileData = File.ReadAllBytes(path + externalFile.fileName);
              texture.LoadImage(fileData);
            } else {
              texture = Resources.Load<Texture2D>(_resourcePlaceholderFolder +
                                                  file.placeholder);
              byte[] bytes = texture.EncodeToPNG();
              File.WriteAllBytes(path + externalFile.fileName, bytes);
              Debug.Log("ExternalResources: Created placeholder at: " + path +
                        externalFile.fileName);
            }

            Rect rect = new Rect(0, 0, texture.width, texture.height);
            Sprite sprite = Sprite.Create(texture, rect, new Vector2(0.5f, 0.5f));

            _resourcesContents[folder.name].content.Add(file.name, sprite);
            fileIndex++;
          }
          folderIndex++;
        }
      }
    }
  }
}
