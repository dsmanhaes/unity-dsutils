using UnityEngine;
using UnityEngine.UI;

namespace Solve
{
  namespace QRCode
  {
    public static class QRCodeController
    {
      public static void ShowQR(Image image, string text)
      {
        Rect rect = image.rectTransform.rect;
        Vector2 pivot = image.rectTransform.pivot;
        image.sprite = GetQRSprite(text, rect, pivot);
      }
      public static void ShowQR(CanvasRenderer renderer, string text)
      {
        renderer.SetTexture(GetQRTexture2D(text));
      }
      public static Sprite GetQRSprite(string text, Rect rect, Vector2 pivot)
      {
        return Sprite.Create(GetQRTexture2D(text), rect, pivot);
      }
      public static Texture2D GetQRTexture2D(string text)
      {
        return QRCodeGenerator.GenerateQR(text);
      }
    }
  }
}
