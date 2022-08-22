using System.Collections.Generic;
using UnityEngine;

namespace Solve {

  namespace Keyboard {
    
    internal class KeyboardInputObject : MonoBehaviour {
      private static KeyboardInputEvents _keyboardInputEvents;

      public bool IsListening = true;

      public static KeyboardInputObject CreateListener (
          KeyboardInputEvents keyboardInputEvents) {
        _keyboardInputEvents = keyboardInputEvents;
        GameObject gameObject = new GameObject("Keyboard Listener", 
                                               typeof(KeyboardInputObject));
        DontDestroyOnLoad(gameObject);
        return gameObject.GetComponent<KeyboardInputObject>();
      }
      
      public void Update () {
        if (IsListening) {
          var events = _keyboardInputEvents.GetDictionary();
          foreach (KeyValuePair<KeyCode, KeyboardEvents> keyboardInput in events) {
            if (Input.GetKeyDown(keyboardInput.Key))
            { keyboardInput.Value.GetEvent(KeyboardInputType.OnKeyDown)?.Invoke(); }
            if (Input.GetKey(keyboardInput.Key))
            { keyboardInput.Value.GetEvent(KeyboardInputType.OnKey)?.Invoke(); }
            if (Input.GetKeyUp(keyboardInput.Key))
            { keyboardInput.Value.GetEvent(KeyboardInputType.OnKeyUp)?.Invoke(); }
          }
        }
      }
    }
  }
}
