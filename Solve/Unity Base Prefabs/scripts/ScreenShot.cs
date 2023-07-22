using System;
using System.IO;
using System.Collections;
using UnityEngine;
[RequireComponent(typeof(Camera))]
public class ScreenShot : MonoBehaviour
{
  private static ScreenShot _instance;
  public int shotWidth = 1920;
  public int shotHeight = 1080;
  private void Awake() { _instance = this; }
  public static string TakeScreenShot(string path)
  {
    string name = DateTimeOffset.Now.ToUnixTimeSeconds().ToString();
    _instance.StartCoroutine(_instance.SaveScreenShot(path + name + ".png"));
    return name;
  }
  public static Texture2D GetScreenShot()
  {
    var texture = _instance.RTImage(_instance.GetComponent<Camera>());
    return texture;
  }
  private IEnumerator SaveScreenShot(string fileName)
  {
    yield return new WaitForSeconds(1);
    var camera = GetComponent<Camera>();
    var texture = RTImage(camera);
    string path = fileName;
    byte[] bytes = texture.EncodeToPNG();
    File.WriteAllBytes(path, bytes);
  }
  private Texture2D RTImage(Camera camera)
  {
    int width = Screen.width;
    int height = Screen.height;
    Rect rect = new Rect(0, 0, width, height);
    var renderTexture = new RenderTexture(width, height, 24);
    var screenShot = new Texture2D(width, height, TextureFormat.RGBA32, false);

    camera.targetTexture = renderTexture;
    camera.Render();

    RenderTexture.active = renderTexture;
    screenShot.ReadPixels(rect, 0, 0);

    camera.targetTexture = null;
    RenderTexture.active = null;

    var shot = new Texture2D(shotWidth, shotHeight, TextureFormat.RGBA32, false);
    var startX = (width / 2) - (shotWidth / 2);
    for (int i = 0; i < shotWidth; i++)
      for (int j = 0; j < shotHeight; j++)
        shot.SetPixel(i, j, screenShot.GetPixel(i + startX, j));

    shot.Apply();
    return shot;
  }
}
