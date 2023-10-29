namespace Solve
{
  namespace External
  {
    using System;
    using System.IO;
    using System.Reflection;
    using System.Collections.Generic;
    using Impl;
    using JSON;
    using Debug;
    public static class External
    {
      private const string CONFIG_FILENAME = "configs.json";
      private const string LEVELS_FILENAME = "levels.json";
      private const string TEXTS_FILENAME = "texts.json";
      private const string RES_FOLDER = "_res/";
      private const string CONTENTS_FIELD = "contents";
      private const string SPRITE_EXTENSION = ".png";
      private const string TEXTURE_EXTENSION = ".jpg";
      private const string AUDIO_EXTENSION = ".mp3";
      private const string VIDEO_EXTENSION = ".mp4";
      private static Configs _configs;
      private static Levels _levels;
      private static Texts _texts;
      private static Ars _ars;
      public static Configs configs
      { get { return (_configs == null) ? Load<Configs>(out _configs, CONFIG_FILENAME) : _configs; } }
      public static Levels levels
      { get { return (_levels == null) ? Load<Levels>(out _levels, LEVELS_FILENAME) : _levels; } }
      public static Texts texts
      { get { return (_texts == null) ? Load<Texts>(out _texts, TEXTS_FILENAME) : _texts; } }
      public static Ars ars
      { get { return (_ars == null) ? LoadArs() : _ars; } }
      private static T Load<T>(out T cache, string filename) where T : class, new()
      {
        DebugController.Log(typeof(T), "Loading external files...");
        cache = JSONController.GetObject<T>(filename, new T());
        return cache;
      }
      private static Ars LoadArs()
      {
        // TODO: Search for a way to remove reflections
        _ars = new Ars();
        DebugController.Log(typeof(Ars), "Loading external files...");
        foreach (FieldInfo folderInfo in typeof(Ars).GetFields())
        {
          if (folderInfo.Name == CONTENTS_FIELD) continue;
          string path = JSONController.JSONPath + folderInfo.Name + "/";
          _ars.contents.Add(folderInfo.Name, new Dictionary<string, object>());
          Directory.CreateDirectory(path);
          var folder = typeof(Ars).GetField(folderInfo.Name).GetValue(_ars);
          foreach (FieldInfo fileInfo in folder.GetType().GetFields())
          {
            string filePath = path + fileInfo.Name;
            ResourceType type = Enum.Parse<ResourceType>(fileInfo.FieldType.Name);
            string resPath = RES_FOLDER + folderInfo.Name + "/" + fileInfo.Name;
            if (type == ResourceType.Sprite)
              fileInfo.SetValue(folder, ImageLoader.LoadSprite(filePath +
                SPRITE_EXTENSION, resPath));
            else if (type == ResourceType.Texture2D)
              fileInfo.SetValue(folder, ImageLoader.LoadTexture2D(filePath +
                SPRITE_EXTENSION, resPath));
            else if (type == ResourceType.AudioClip)
              fileInfo.SetValue(folder, AudioLoader.LoadAudio(filePath +
                AUDIO_EXTENSION, resPath));
            else if (type == ResourceType.Video)
              fileInfo.SetValue(folder, VideoLoader.LoadVideo(filePath +
                VIDEO_EXTENSION, resPath));
            _ars.contents[folderInfo.Name].Add(fileInfo.Name, fileInfo.GetValue(folder));
          }
        }
        return _ars;
      }
    }
  }
}
