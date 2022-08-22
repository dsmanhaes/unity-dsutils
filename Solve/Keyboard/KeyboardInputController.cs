using UnityEngine;
using UnityEngine.Events;

namespace Solve {

  namespace Keyboard {
  
    public static class KeyboardInputController {
      private static KeyboardInputEvents _keyboardInputEvents = new KeyboardInputEvents();
      private static KeyboardInputObject _keyboardInputObject = 
          KeyboardInputObject.CreateListener(_keyboardInputEvents);
      
      public static void StartListen () {
        _keyboardInputObject.IsListening = true;
      }
      
      public static void StopListen () {
        _keyboardInputObject.IsListening = false;
      }

      public static void AddListener (KeyCode[] keyCodes,
                                      KeyboardInputType keyboardInputType,
                                      UnityAction unityAction) {
        foreach (KeyCode keyCode in keyCodes) {
          AddListener(keyCode, keyboardInputType, unityAction);
        }
      }

      public static void AddListener (KeyCode keyCode,
                                      KeyboardInputType keyboardInputType,
                                      UnityAction unityAction) {
        UnityEvent unityEvent = GetUnityEvent(keyCode, keyboardInputType);
        unityEvent.AddListener(unityAction);
      }

      public static void RemoveListener (KeyCode[] keyCodes,
                                         KeyboardInputType keyboardInputType,
                                         UnityAction unityAction) {
        foreach (KeyCode keyCode in keyCodes) {
          RemoveListener(keyCode, keyboardInputType, unityAction);
        }
      }

      public static void RemoveListener (KeyCode keyCode,
                                         KeyboardInputType keyboardInputType,
                                         UnityAction unityAction) {
        UnityEvent unityEvent = GetUnityEvent(keyCode, keyboardInputType);
        unityEvent.RemoveListener(unityAction);
      }

      private static UnityEvent GetUnityEvent (KeyCode keyCode,
                                               KeyboardInputType keyboardInputType) {
        Debug.Log ("Keyboard: returning listener: " + keyboardInputType +
                   " to key: " + keyCode);
        return _keyboardInputEvents.GetEvent(keyCode, keyboardInputType);
      }
    }
  }
}
