using UnityEngine;
using UnityEngine.Events;

public class InputController : MonoBehaviour
{
    public KeyCode key;
    public UnityEvent OnKeyDown;
    public UnityEvent OnKey;
    public UnityEvent OnKeyUp;
    
    public void Update ()
    {
        if (Input.GetKeyDown(key)) OnKeyDown?.Invoke();
        if (Input.GetKey(key)) OnKey?.Invoke();
        if (Input.GetKeyUp(key)) OnKeyUp?.Invoke();
    }
}
