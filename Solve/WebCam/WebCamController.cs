using UnityEngine;

namespace Solve
{
  namespace WebCam
  {
    public class WebCamController : MonoBehaviour
    {
      public int camWidth;
      public int camHeight;
      public int camFPS;
      void Start()
      {
        WebCamTexture webcamTexture = new WebCamTexture(camWidth, camHeight, camFPS);
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = webcamTexture;
        webcamTexture.Play();
      }
    }
  }
}
