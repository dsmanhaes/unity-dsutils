using System.IO;
using System.Collections.Generic;

namespace Solve
{
  namespace ExternalResources
  {
    public static class FilesLoader
    {
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
        object folderProp = typeof(MetaData).GetField(folder.name).GetValue(meta);
        foreach (ResourcesFile file in folder.files)
        {
          object fileProp = folderProp.GetType().GetField(file.name).GetValue(folderProp);
          ExternalFile externalFile = (ExternalFile)fileProp;
          string placeholderPath = "External Resources/Placeholders/" + file.placeholder;
          string filePath = folderPath + "/" + externalFile.fileName;
          object objectLoaded = null;
          if (folder.fileType == ResourceType.Sprite)
            objectLoaded = ImageLoader.LoadSprite(filePath, placeholderPath, externalFile.width, externalFile.height);
          else if (folder.fileType == ResourceType.Texture2D)
            objectLoaded = ImageLoader.LoadTexture2D(filePath, placeholderPath, externalFile.width, externalFile.height);
          fileList.Add(file.name, objectLoaded);
        }
        return fileList;
      }
    }
  }
}
