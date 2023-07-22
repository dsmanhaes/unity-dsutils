namespace Solve
{
  namespace Utils
  {
    using UnityEngine;
    using UnityEngine.UI;
    using External;
    using Debug;
    using TMPro;
    public class FetchCheck : MonoBehaviour
    {
      private void Start()
      {
        var images = GameObject.FindObjectsOfType<Image>();
        Check(images);
        var texts = GameObject.FindObjectsOfType<TMP_Text>();
        Check(texts);
      }
      private void Check(MonoBehaviour[] array)
      {
        foreach(var item in array)
          if (!item.GetComponent<ResourceFetch>())
            DebugController.LogWarning(typeof(FetchCheck),
                $"Missing ResourceFetch on {item.name}");
      }
    }
  }
}
