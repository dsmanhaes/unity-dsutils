using UnityEngine;

namespace Solve
{
  namespace Reset
  {
    using UnityEngine.Events;
    using Debug;
    using External;
    public class ResetController : MonoBehaviour
    {
      public UnityEvent OnReset;
      private float _resetTime;
      private float _elapsedTime = 0;
      public void Awake()
      {
        _resetTime = External.configs.resetTime;
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
        OnReset?.Invoke();
      }
      public void OnMouseDown()
      {
        _elapsedTime = 0;
      }
    }
  }
}
