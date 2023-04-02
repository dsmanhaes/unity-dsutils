using UnityEngine;

namespace Solve
{
  namespace Audio
  {
    using Debug;

    public class AudioPlayerObject : MonoBehaviour
    {
      private AudioSource _source;
      public void Start()
      {
        _source = gameObject.GetComponent<AudioSource>();
        DebugController.Log(typeof(AudioPlayerObject), "Audio player created " + _source.clip.name);
      }
      public void Update()
      {
        if (!_source.isPlaying)
        {
          DebugController.Log(typeof(AudioPlayerObject), "Audio player finalizing " + _source.clip.name);
          Destroy(gameObject);
        }
      }
    }
  }
}
