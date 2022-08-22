using UnityEngine;

namespace Solve {
  
  namespace Transitions {

    internal class TransitionObject {
      private static TransitionComponent _transitionComponent;

      public static void AddTransition (LerpTransition transition) {
        if (_transitionComponent == null) {
          GameObject gameObject = new GameObject("Transitions",
                                                 typeof(TransitionComponent));
          _transitionComponent = gameObject.GetComponent<TransitionComponent>();
        }
        _transitionComponent.AddTransition(transition);
      }
    }
  }
}
