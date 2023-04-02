using UnityEngine;

namespace Solve
{
  namespace Reset
  {
    using Board;
    using Debug;
    using ExternalResources;

    public class ResetController : MonoBehaviour
    {
      public delegate void Reset();
      public Reset OnReset;
      private int _resetTime;
      private float _elapsedTime = 0;
      public void Awake()
      {
        _resetTime = ExternalResources.config.idleResetTime;
        if (_resetTime == 0)
          DebugController.Error(typeof(ResetController), "Couldn't load idleResetTime in config");
      }
      public void Update()
      {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime > _resetTime)
          onReset();
      }
      private void onReset ()
      {
        BoardController.Reset();
        OnReset?.Invoke();
      }
      public void OnMouseDown()
      {
        _elapsedTime = 0;
      }
    }
  }
}
