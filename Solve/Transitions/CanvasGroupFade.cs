using UnityEngine;
using UnityEngine.Events;

namespace Solve {
  
  namespace Transitions {

    public class CanvasGroupFade {
      private CanvasGroup _canvasGroup;

      public CanvasGroupFade (float start, float end, float time, ref CanvasGroup target){
        _canvasGroup = target;
        LerpTransition transition = new LerpTransition(start, end, time, UpdateTransition);
        TransitionObject.AddTransition(transition);
      }

      public void UpdateTransition (float moment) {
        _canvasGroup.alpha = moment;
      }
    }
  }
}
