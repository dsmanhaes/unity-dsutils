using System.Collections.Generic;
using UnityEngine.Events;

namespace Solve {

  namespace Keyboard {
  
    internal class KeyboardEvents {
      private Dictionary<KeyboardInputType, UnityEvent> _keyboardEvents;

      public KeyboardEvents () {
        _keyboardEvents = new Dictionary<KeyboardInputType, UnityEvent>();
      }

      public UnityEvent GetEvent (KeyboardInputType keyboardInputType) {
        if (!_keyboardEvents.ContainsKey(keyboardInputType)) {
          UnityEvent unityEvent = new UnityEvent();
          _keyboardEvents.Add(keyboardInputType, unityEvent);
        }

        return _keyboardEvents[keyboardInputType];
      }
    }
  }
}
