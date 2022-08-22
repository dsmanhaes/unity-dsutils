using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Solve {

  namespace Keyboard {
  
    internal class KeyboardInputEvents {
      private Dictionary<KeyCode, KeyboardEvents> _keyboardInputEvents;

      public KeyboardInputEvents () {
        _keyboardInputEvents = new Dictionary<KeyCode, KeyboardEvents>();
      }

      public Dictionary<KeyCode, KeyboardEvents> GetDictionary () {
        return _keyboardInputEvents;
      }

      public UnityEvent GetEvent (KeyCode keyCode,
                                  KeyboardInputType keyboardInputType) {
        if (!_keyboardInputEvents.ContainsKey(keyCode)) {
          KeyboardEvents events = new KeyboardEvents();
          _keyboardInputEvents.Add(keyCode, events);
        }

        return _keyboardInputEvents[keyCode].GetEvent(keyboardInputType);
      }
    }
  }
}
