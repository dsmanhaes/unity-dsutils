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
        public static Video LoadVideo(string filePath, string placeholderPath)
        {
          // TODO: Buscar forma de funcionar em android
          // pois em android, o streamingassets retorna uma url
          // então não funciona o File.ReadAllBytes
          if (!File.Exists(filePath))
          {
            var uri = Path.Combine(Application.streamingAssetsPath, placeholderPath + ".mp4");
            var bytes = File.ReadAllBytes(uri);
            File.WriteAllBytes(filePath, bytes);
            DebugController.Log(typeof(ResourceFetch), "Created placeholder at: " + filePath);
          }
          DebugController.Log(typeof(VideoLoader), "Video loaded at: " + filePath);
          var video = new Video();
          video.uri = "file://" + filePath;
          return video;
        }
      }
    }
  }
}
