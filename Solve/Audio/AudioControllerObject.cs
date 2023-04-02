using UnityEngine;

namespace Solve
{
  namespace Audio
  {
    using Debug;

    public class AudioControllerObject : MonoBehaviour
    {
      public void Awake()
      {
        DebugController.Log(typeof(AudioControllerObject), "Audio Object created");
        DontDestroyOnLoad(this);
      }
    }
  }
}
