using System.IO;
using UnityEngine;

namespace Solve
{
  namespace ExternalResources
  {
    public class ImageLoader
    {
      public static Texture2D LoadTexture2D(string filePath, string placeholderPath, int width, int height)
      {
        Texture2D texture = new Texture2D(width, height);
        if (File.Exists(filePath))
        {
          byte[] fileData = File.ReadAllBytes(filePath);
          texture.LoadImage(fileData);
        }
        else
        {
          texture = Resources.Load<Texture2D>(placeholderPath);
          byte[] bytes = texture.EncodeToPNG();
          File.WriteAllBytes(filePath, bytes);
          Debug.Log("ExternalResources: Created placeholder at: " + filePath);
        }
        return texture;
      }
      public static Sprite LoadSprite(string filePath, string placeholderPath, int width, int height)
      {
        Texture2D texture = LoadTexture2D(filePath, placeholderPath, width, height);
        Rect rect = new Rect(0, 0, texture.width, texture.height);
        return Sprite.Create(texture, rect, new Vector2(0.5f, 0.5f));
      }
    }
  }
}
