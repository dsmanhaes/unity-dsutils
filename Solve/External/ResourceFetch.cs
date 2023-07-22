namespace Solve
{
  namespace External
  {
#if UNITY_EDITOR
    using UnityEditor;
#endif
    using UnityEngine;
    using UnityEngine.UI;
    using Impl;
    using Debug;
    using TMPro;
    public class ResourceFetch : MonoBehaviour
    {
      [SerializeField]
      private ResourceType type;
      public string file
      { get { return gameObject.name; } }
      public string folder;
      [HideInInspector]
      public bool autoPlay = false;
      [HideInInspector]
      public bool loop = false;
      public void Start()
      {
        if (type != ResourceType.None && (folder == "" || folder == null))
          DebugController.Error(typeof(ResourceFetch), "The folder name isn't set");
        Load(folder, gameObject.name);
      }
      public void Load(string folder, string file)
      {
        if (type == ResourceType.Sprite)
          LoadSprite(folder, file);
        else if (type == ResourceType.AudioClip)
          LoadAudio(folder, file);
        else if (type == ResourceType.Text)
          LoadText(folder, file);
        gameObject.name = file;
        DebugController.Log(typeof(ResourceFetch), type + " fetched successfully " + folder + "/" + file);
      }
      private void LoadText(string folder, string file)
      {
        // TODO: Search for a way to remove reflections
        var text = GetComponent<TMP_Text>();
        var folderValue = External.texts.GetType().GetField(folder).GetValue(External.texts);
        var fileValue = folderValue.GetType().GetField(file).GetValue(folderValue);
        text.text = (string)fileValue;
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
        GetComponent<AudioSource>().loop = loop;
        if (autoPlay) GetComponent<AudioSource>().Play();
      }
#if UNITY_EDITOR
      [CustomEditor(typeof(ResourceFetch))]
      public class ResourceFetchEditor : Editor
      {
        public override void OnInspectorGUI()
        {
          base.OnInspectorGUI();
          var script = (ResourceFetch)target;
          if (script.type == ResourceType.AudioClip)
          {
            script.autoPlay = EditorGUILayout.Toggle("Auto Play", script.autoPlay);
            script.loop = EditorGUILayout.Toggle("Loop", script.loop);
          }
        }
      }
#endif
    }
  }
}
