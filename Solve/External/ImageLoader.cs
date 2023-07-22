using System.IO;
using UnityEngine;

namespace Solve
{
  namespace External
  {
    namespace Impl
    {
      using Debug;

      public static class ImageLoader
      {
        public static Texture2D LoadTexture2D(string filePath, string placeholderPath)
        {
          Texture2D texture = new Texture2D(0, 0);
          if (File.Exists(filePath))
          {
            try
            {
              byte[] fileData = File.ReadAllBytes(filePath);
              texture.LoadImage(fileData);
              DebugController.Log(typeof(ImageLoader), "Image loaded at: " + filePath);
            }
            catch
            {
              DebugController.Error(typeof(ImageLoader), "Failed to load image at: " + filePath);
              return null;
            }
          }
          else
          {
            try
            {
              texture = Resources.Load<Texture2D>(placeholderPath);
              byte[] bytes = texture.EncodeToPNG();
              File.WriteAllBytes(filePath, bytes);
              DebugController.Log(typeof(ImageLoader), "Created placeholder at: " + filePath);
            }
            catch
            {
              DebugController.Error(typeof(ImageLoader), "Failed to load image at: Resources/" + placeholderPath);
              return null;
            }
          }
          return texture;
        }
        public static Sprite LoadSprite(string filePath, string placeholderPath)
        {
          Texture2D texture = LoadTexture2D(filePath, placeholderPath);
          Rect rect = new Rect(0, 0, texture.width, texture.height);
          return Sprite.Create(texture, rect, new Vector2(0.5f, 0.5f));
        }
      }
    }
  }
}
