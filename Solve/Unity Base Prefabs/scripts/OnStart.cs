using UnityEngine;
using UnityEngine.Events;
public class OnStart : MonoBehaviour
{
  [SerializeField]
  private UnityEvent _onStart;
  private void Start() { _onStart?.Invoke(); }
}
