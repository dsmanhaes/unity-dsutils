using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
public class InputPerformed : MonoBehaviour
{
  public UnityEvent<InputAction> onPerform;
  public void onEvent(InputAction.CallbackContext context)
  {
    if (context.performed)
      onPerform?.Invoke(context.action);
  }
}
