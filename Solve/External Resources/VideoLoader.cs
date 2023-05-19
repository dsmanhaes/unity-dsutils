namespace Solve
{
  namespace ExternalResources
  {
    using System.IO;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Video;
    using Debug;
    public static class VideoLoader
    {
      public static KeyValuePair<VideoSource, object> LoadVideo(string filePath, string placeholderPath)
      {
        if (File.Exists(filePath))
        {
          DebugController.Log(typeof(ResourceFetch), "Video loaded at: " + filePath);
          return new KeyValuePair<VideoSource, object>(VideoSource.Url, "file://" + filePath);
        }
        else
        {
          VideoPlayer player = new VideoPlayer();
          VideoClip clip = Resources.Load<VideoClip>(placeholderPath);
          RenderTexture render = new RenderTexture((int)clip.width, (int)clip.height, 24, RenderTextureFormat.ARGB32);
          player.targetTexture = render;
          Texture2D texture = new Texture2D(render.width, render.height, TextureFormat.RGB24, false);
          byte[] bytes = texture.EncodeToPNG();
          File.WriteAllBytes(filePath, bytes);
          DebugController.Log(typeof(ResourceFetch), "Created placeholder at: " + filePath);
          return new KeyValuePair<VideoSource, object>(VideoSource.VideoClip, clip);
        }
      }
    }
  }
}
