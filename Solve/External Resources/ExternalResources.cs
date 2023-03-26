using System.IO;
using System.Collections.Generic;
using UnityEngine;

namespace Solve
{
  namespace ExternalResources
  {
    public static class ExternalResources
    {
      public static ExternalConfig config
      {
        get
        {
          LoadConfigsCache();
          return _resourcesConfig.config;
        }
      }
      public static Dictionary<string, Dictionary<string, object>> contents
      {
        get
        {
          LoadConfigsCache();
          return _resourcesContent;
        }
      }
      private static Dictionary<string, Dictionary<string, object>> _resourcesContent =
          new Dictionary<string, Dictionary<string, object>>();
      private static string _configFileName = "config.json";
      private static string _resourceFileName = "External Resources/external_resources";
      private static string _resourcePlaceholderFolder = "External Resources/Placeholders/";
      private static string _externalPath = Application.dataPath + "/../_res/";
      private static ResourcesConfig _resourcesConfig;
      private static void LoadConfigsCache()
      {
        if (_resourcesConfig == null)
        {
          TextAsset rawJson = Resources.Load<TextAsset>(_resourceFileName);
          _resourcesConfig = JsonUtility.FromJson<ResourcesConfig>(rawJson.text);
          Directory.CreateDirectory(_externalPath);
          if (File.Exists(_externalPath + _configFileName))
          {
            LoadConfigFile();
          }
          else
          {
            CreateConfigFile();
          }
          VerifyFiles();
          Debug.Log("ExternalResources: All configurations was loaded!");
        }
      }
      private static void LoadConfigFile()
      {
        Debug.Log("ExternalResources: Loading configuration file at: " +
                  _externalPath + _configFileName);
        string json = File.ReadAllText(_externalPath + _configFileName);
        _resourcesConfig.config = JsonUtility.FromJson<ExternalConfig>(json);
      }
      private static void CreateConfigFile()
      {
        Debug.Log("ExternalResources: Creating configuration file at: " +
                  _externalPath + _configFileName);
        string json = JsonUtility.ToJson(_resourcesConfig.config, true);
        File.WriteAllText(_externalPath + _configFileName, json);
      }
      private static void VerifyFiles()
      {
        Debug.Log("ExternalResources: Start external files verification...");
        int folderIndex = 0;
        foreach (ResourcesFolder folder in _resourcesConfig.folders)
        {
          int fileIndex = 0;
          string path = _externalPath + folder.name + "/";
          Directory.CreateDirectory(path);
          _resourcesContent.Add(folder.name, new Dictionary<string, object>());
          object folderProp = typeof(MetaData).GetField(folder.name).GetValue(_resourcesConfig.config.meta);
          foreach (ResourcesFile file in folder.files)
          {
            object fileProp = folderProp.GetType().GetField(file.name).GetValue(folderProp);
            ExternalFile externalFile = (ExternalFile)fileProp;
            string filePath = path + externalFile.fileName;
            string placeholderPath = _resourcePlaceholderFolder + file.placeholder;
            // TODO: Create other formats to importation
            if (folder.fileType == "Sprite") {
              Sprite sprite = ImageLoader.LoadSprite(filePath, placeholderPath,
                  externalFile.width, externalFile.height);
              _resourcesContent[folder.name].Add(file.name, sprite);
            } else if (folder.fileType == "Texture2D") {
              Texture2D texture = ImageLoader.LoadTexture2D(filePath, placeholderPath,
                  externalFile.width, externalFile.height);
              _resourcesContent[folder.name].Add(file.name, texture);
            }
            fileIndex++;
          }
          folderIndex++;
        }
      }
    }
  }
}
