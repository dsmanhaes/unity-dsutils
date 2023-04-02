using UnityEngine;
using UnityEngine.UI;

namespace Solve
{
  namespace ExternalResources
  {
    using Debug;

    public class ResourceFetch : MonoBehaviour
    {
      private static ResourceType _resourceType;
      private static string _resourceFolder;
      private static string _resourceFile;
      public ResourceType type;
      public string folder;
      public string file;
      public static void Prepare(ResourceType resourceType, string resourceFolder, string resourceFile)
      {
        _resourceFile = resourceFile;
        _resourceFolder = resourceFolder;
        _resourceFile = resourceFile;
      }
      public void Awake()
      {
        if (_resourceFolder != null && _resourceFile != null)
        {
          type = _resourceType;
          folder = _resourceFolder;
          file = _resourceFile;
        }
      }
      public void Start()
      {
        if (folder == "" || folder == null)
          DebugController.Error(typeof(ResourceFetch), "The folder name isn't set");
        if (file == "" || file == null)
          DebugController.Error(typeof(ResourceFetch), "The file name isn't set");
        if (type == ResourceType.Sprite)
          GetComponent<Image>().sprite = (Sprite)ExternalResources.contents[folder][file];
        DebugController.Log(typeof(ResourceFetch), "Resource fetched successfully " + folder + "/" + file);
      }
    }
  }
}
