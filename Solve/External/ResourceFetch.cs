namespace Solve
{
  namespace External
  {
    namespace Impl
    {
      using UnityEngine;
      using UnityEngine.UI;
      using Debug;
      public class ResourceFetch : MonoBehaviour
      {
        [SerializeField]
        private ResourceType type;
        public string file
        { get { return gameObject.name; } }
        public string folder;
        public void Start()
        {
          if (folder == "" || folder == null)
            DebugController.Error(typeof(ResourceFetch), "The folder name isn't set");
          Load(folder, gameObject.name);
        }
        public void Load(string folder, string file)
        {
          if (type == ResourceType.Sprite)
            LoadSprite(folder, file);
          else if (type == ResourceType.AudioClip)
            LoadAudio(folder, file);
          gameObject.name = file;
          DebugController.Log(typeof(ResourceFetch), type + " fetched successfully " + folder + "/" + file);
        }
        private void LoadSprite(string folder, string file)
        {
          Sprite sprite = (Sprite)External.ars.contents[folder][file];
          GetComponent<Image>().sprite = sprite;
          Vector2 size = new Vector2(sprite.texture.width, sprite.texture.height);
          GetComponent<RectTransform>().sizeDelta = size;
        }
        private void LoadAudio(string folder, string file)
        {
          AudioClip clip = (AudioClip)External.ars.contents[folder][file];
          GetComponent<AudioSource>().clip = clip;
          GetComponent<AudioSource>().Play();
        }
      }
    }
  }
}
