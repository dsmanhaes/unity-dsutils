namespace Solve
{
  namespace External
  {
    namespace Impl
    {
      // TODO: Look for a better way to treat videos
      public struct Video
      {
        public string uri;
      }
      // TODO: Implements other formats importation
      [System.Serializable]
      public enum ResourceType
      {
        None = 0,
        Sprite = 1,
        Texture2D = 2,
        Video = 3,
        AudioClip = 4,
        Text = 5
      }
    }
  }
}

