using UnityEngine;

namespace Solve
{
  namespace WebCam
  {
    using Debug;

    public class WebCamController : MonoBehaviour
    {
      public int camWidth;
      public int camHeight;
      public int camFPS;
      public bool mirrored;
      void Start()
      {
        if (camWidth == 0 || camHeight == 0 || camFPS == 0)
          DebugController.Error(typeof(WebCamController), "Some parameter isn't set");
        float aspect = (float)camWidth / (float)camHeight * ((mirrored)? -1: 1);
        Vector3 scale = new Vector3(aspect, 1, 1);
        transform.localScale = scale;
        WebCamTexture webcamTexture = new WebCamTexture(camWidth, camHeight, camFPS);
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = webcamTexture;
        webcamTexture.Play();
        DebugController.Log(typeof(WebCamController), "Webcam initialized");
      }
    }
  }
}
