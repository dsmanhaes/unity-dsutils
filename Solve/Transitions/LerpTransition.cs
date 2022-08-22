using UnityEngine;
using UnityEngine.Events;

namespace Solve {
  
  namespace Transitions {
    
    internal class LerpTransition {
      public float Start;
      public float End;
      public float Duration;
      public float Moment;
      public UnityAction<float> Target;

      public LerpTransition (float start, float end, float duration, UnityAction<float> target) {
        Start = start;
        End = end;
        Duration = duration;
        Moment = Start;
        Target = target;
      }

      public float UpdateTransition (float deltaTime) {
        Moment += deltaTime;
        return Mathf.Lerp(Start, End, (Moment - Start) / Duration);
      }
    }
  }
}
