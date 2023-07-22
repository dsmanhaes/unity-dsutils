namespace Solve
{
  namespace Utils
  {
    using UnityEngine;
    public class DisplayController : MonoBehaviour
    {
      void Start()
      { foreach (Display display in Display.displays) display.Activate(); }
    }
  }
}
