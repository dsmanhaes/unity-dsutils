using System.Collections.Generic;
using UnityEngine;

namespace Solve {
  
  namespace Transitions {
    
    internal class TransitionComponent : MonoBehaviour {
      private List<LerpTransition> _transitions = new List<LerpTransition>();

      public void Awake () {
        DontDestroyOnLoad(gameObject);
      }

      public void Update () {
        var transitions = new List<LerpTransition>(_transitions);
        foreach (LerpTransition transition in transitions)
        {
          float actual = transition.UpdateTransition(Time.deltaTime);
          transition.Target?.Invoke(actual);
          if (actual >= transition.End)
          { _transitions.Remove(transition); }
        }
      }

      public void AddTransition (LerpTransition transition) {
        _transitions.Add(transition);
      }
    }
  }
}
