namespace Solve
{
  namespace Utils
  {
    using UnityEngine;
    using UnityEngine.SceneManagement;
    public class SceneLoader : MonoBehaviour
    {
      public string nextScene;
      public void LoadScene()
      {
        int sceneIndex;
        if (int.TryParse(nextScene, out sceneIndex))
          SceneManager.LoadScene(sceneIndex);
        else
          SceneManager.LoadScene(nextScene);
      }
    }
  }
}
