using UnityEngine;
using ZXing;
using ZXing.QrCode;

namespace Solve
{
  namespace QRCode
  {
    using Debug;

    public static class QRCodeGenerator
    {
      public static Texture2D GenerateQR(string text)
      {
        Texture2D encoded = new Texture2D(256, 256);
        Color32[] color32 = Encode(text, encoded.width, encoded.height);
        encoded.SetPixels32(color32);
        encoded.Apply();
        DebugController.Log(typeof(QRCodeGenerator), "QRCode generated");
        return encoded;
      }
      private static Color32[] Encode(string textForEncoding, int width, int height)
      {
        BarcodeWriter writer = new BarcodeWriter
        {
          Format = BarcodeFormat.QR_CODE,
          Options = new QrCodeEncodingOptions
          {
            Height = height,
            Width = width
          }
        };
        return writer.Write(textForEncoding);
      }
    }
  }
}
