namespace Solve
{
  namespace External
  {
    namespace Impl
    {
      using System.IO;
      using UnityEngine;
      using UnityEngine.Video;
      using Debug;
      public static class VideoLoader
      {
        public static string LoadVideo(string filePath, string placeholderPath)
        {
          if (!File.Exists(filePath))
          {
            VideoPlayer player = new VideoPlayer();
            VideoClip clip = Resources.Load<VideoClip>(placeholderPath);
            RenderTexture render = new RenderTexture((int)clip.width, (int)clip.height, 24, RenderTextureFormat.ARGB32);
            player.targetTexture = render;
            Texture2D texture = new Texture2D(render.width, render.height, TextureFormat.RGB24, false);
            byte[] bytes = texture.EncodeToPNG();
            File.WriteAllBytes(filePath, bytes);
            DebugController.Log(typeof(VideoLoader), "Created placeholder at: " + filePath);
          }
          DebugController.Log(typeof(VideoLoader), "Video loaded at: " + filePath);
          return "file://" + filePath;
        }
      }
    }
  }
}
