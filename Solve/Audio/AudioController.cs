using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solve {

  namespace Audio {

    public static class AudioController {
      private class AudioControllerObject: MonoBehaviour {
        public void Awake () {
          DontDestroyOnLoad(this);
        }
      }

      private class AudioPlayerObject: MonoBehaviour {
        private AudioSource _source;

        public void Start () {
          _source = gameObject.GetComponent<AudioSource>();
        }

        public void Update () {
          if (!_source.isPlaying) {
            Destroy(gameObject);
          }
        }
      }

      private static Transform _transform;
      
      private static Transform _controller {
        get {
          if (_transform == null) {
            GameObject gameObject = new GameObject("Audio Controller Sources", typeof(AudioControllerObject));
            _transform = gameObject.transform;
          }
          return _transform;
        }
      }

      private static AudioSource CreateAudioSource () {
        GameObject gameObject = new GameObject("Audio Player", typeof(AudioPlayerObject), typeof(AudioSource));
        gameObject.transform.parent = _controller;
        return gameObject.GetComponent<AudioSource>();
      }

      public static AudioSource Play (AudioClip clip) {
        AudioSource source = CreateAudioSource();
        source.clip = clip;
        source.Play();
        return source;
      }

      public static AudioSource Play (AudioClip clip, bool loop) {
        AudioSource source = Play(clip);
        source.loop = loop;
        return source;
      }
    }
  }
}
