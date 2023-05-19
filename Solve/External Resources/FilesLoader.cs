namespace Solve
{
  namespace ExternalResources
  {
    using System;
    using System.IO;
    using System.Collections.Generic;
    using Debug;
    public static class FilesLoader
    {
      private static string placeholderPath = "External Resources/Placeholders/";
      public static Dictionary<string, Dictionary<string, object>> LoadAllFolders(ResourcesFolder[] folders, string path, MetaData meta)
      {
        Dictionary<string, Dictionary<string, object>> contents = new Dictionary<string, Dictionary<string, object>>();
        foreach (ResourcesFolder folder in folders)
        {
          string folderPath = path + folder.name;
          Directory.CreateDirectory(folderPath);
          contents.Add(folder.name, LoadFilesFromFolder(folder, meta, folderPath));
        }
        return contents;
      }
      private static Dictionary<string, object> LoadFilesFromFolder(ResourcesFolder folder, MetaData meta, string folderPath)
      {
        Dictionary<string, object> fileList = new Dictionary<string, object>();
        // TODO: Look for a way to remove the reflections
        try
        {
          object folderProp = typeof(MetaData).GetField(folder.name).GetValue(meta);
          foreach (string file in folder.files)
          {
            object fileProp = folderProp.GetType().GetField(file).GetValue(folderProp);
            string filePath = folderPath + "/" + (string)fileProp;
            object objectLoaded = null;
            ResourceType type = Enum.Parse<ResourceType>(folder.fileType);
            if (type == ResourceType.Sprite)
              objectLoaded = ImageLoader.LoadSprite(filePath, placeholderPath + "sprite");
            else if (type == ResourceType.Texture2D)
              objectLoaded = ImageLoader.LoadTexture2D(filePath, placeholderPath + "texture2d");
            else if (type == ResourceType.Video)
              objectLoaded = VideoLoader.LoadVideo(filePath, placeholderPath + "video");
            else if (type == ResourceType.Audio)
              objectLoaded = AudioLoader.LoadAudio(filePath, placeholderPath + "audio");
            fileList.Add(file, objectLoaded);
          }
        }
        catch
        {
          DebugController.Error(typeof(FilesLoader), "Error while loading files in folder " + folder.name);
          DebugController.Error(typeof(FilesLoader), "FolderPath " + folderPath);
        }
        return fileList;
      }
    }
  }
}
