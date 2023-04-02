using UnityEngine;

namespace Solve
{
  namespace Audio
  {
    using Debug;

    public static class AudioController
    {
      private static Transform _transform;
      private static Transform _controller
      {
        get
        {
          if (_transform == null)
          {
            DebugController.Log(typeof(AudioController), "Creating Audio Object");
            GameObject gameObject = new GameObject("AudioController", typeof(AudioControllerObject));
            _transform = gameObject.transform;
          }
          return _transform;
        }
      }
      private static AudioSource CreateAudioSource()
      {
        GameObject gameObject = new GameObject("AudioPlayer", typeof(AudioPlayerObject), typeof(AudioSource));
        gameObject.transform.parent = _controller;
        return gameObject.GetComponent<AudioSource>();
      }
      public static AudioSource Play(AudioClip clip)
      {
        DebugController.Log(typeof(AudioController), "Creating Audio player " + clip.name);
        AudioSource source = CreateAudioSource();
        source.clip = clip;
        source.Play();
        return source;
      }
      public static AudioSource Play(AudioClip clip, bool loop)
      {
        AudioSource source = Play(clip);
        source.loop = loop;
        return source;
      }
    }
  }
}
