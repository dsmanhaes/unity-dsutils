using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ZXing;
using ZXing.QrCode;
using AppAdvisory.VSGIF;

enum State
{
  Idle,
  Counting,
  Shooting,
  Encoding,
  Showing
}

public class ScreenController : MonoBehaviour
{
  public CanvasGroup idle, photo, encode, qrCode;
  public CanvasRenderer picture, code;
  public Transform countdownTransform;
  public Text countdownText;
  public Image countdownFill;
  public LoopFillAnimation loopFillAnimation;
  public Animator RA;
  public float recordTime;
  public int gifWidth;
  public int gifHeight;
  public GIFElement gifElement;
  public static string gifPath = "";
  public KeyCode key = KeyCode.A;
  public int countdownTime;

  private float _inputDelay = 0;
  private float _inputDelayTIme = 0.5f;
  private State _state = State.Idle;
  private float _elapsedTime;
  private int _countdown = 0;
  private List<Texture2D> _photos;
  private int _fps;

  public void Awake ()
  {
    gifElement.OnFileSaved += GifSaved;
    _fps = gifElement.gifSettings.framePerSecond;
    _photos = new List<Texture2D>();
  }

  public void Update ()
  {
    _inputDelay -= Time.deltaTime;
    if (_inputDelay <= 0)
    {
      //if (Input.GetKeyDown(key)) ButtonPressed();
      if (Input.GetMouseButton(0)) ButtonPressed();
    }
    
    _elapsedTime += Time.deltaTime;

    switch (_state)
    {
      case State.Counting:
        //countdownFill.fillAmount = _elapsedTime / _countdown;
        countdownTransform.localScale = Vector3.Lerp(Vector3.zero, new Vector3(2, 2, 2), _elapsedTime);
        countdownText.color = new Color(1, 1, 1, 1 - _elapsedTime);
        
        if (_elapsedTime > 1)
        {
          _countdown--;
          countdownTransform.localScale = Vector3.zero;
          countdownText.color = Color.white;
          countdownText.text = _countdown + "";
          _elapsedTime = 0;
          
          if (_countdown == 0)
          {
            photo.alpha = 0;
            _elapsedTime = 0;
            _state = State.Shooting;
          }
        }
      break;
      case State.Shooting:
        if (_elapsedTime > (float)_photos.Count / (float)_fps)
          StartCoroutine(RecordFrame());
      break;
    }
    
    if (gifPath != "")
    {
      int fileIndex = gifPath.Length - 14;
      string fileName = gifPath.Substring(fileIndex, 10);
      string filePath = PostalController.QRCodePath + fileName + ".gif";
      File.Copy(gifPath, filePath);
      string gifURL = PostalController.QRCodeURL + fileName;
      code.SetTexture(GenerateQR(gifURL));
      gifPath = "";
      loopFillAnimation.StopAnimation();
      RA.SetBool("anim", false);
      RA.Play("Stop", 0, 0);
      _elapsedTime = 0;
      encode.alpha = 0;
      qrCode.alpha = 1;
      _state = State.Showing;
    }
  }

  private void ButtonPressed ()
  {
    _inputDelay = _inputDelayTIme;

    if (_state == State.Idle)
    {
      //countdownFill.fillAmount = 0;
      _countdown = countdownTime;
      countdownTransform.localScale = Vector3.zero;
      countdownText.color = Color.white;
      countdownText.text = _countdown + "";

      _elapsedTime = 0;
      _photos.Clear();

      RA.SetBool("anim", true);
      idle.alpha = 0;
      photo.alpha = 1;
      _state = State.Counting;
    }
    if (_state == State.Showing)
    {
      gifElement.StopAnimtextureAndDestroySprite();
      qrCode.alpha = 0;
      idle.alpha = 1;
      _state = State.Idle;
    }
  }

  IEnumerator RecordFrame()
  {
    Debug.Log(_elapsedTime + " - " + _photos.Count/_fps);
    yield return new WaitForEndOfFrame();
    _photos.Add(ScreenCapture.CaptureScreenshotAsTexture());
    if (_photos.Count >= recordTime * _fps)
    {
      loopFillAnimation.StartAnimation();
      encode.alpha = 1;
      _state = State.Encoding;
      yield return new WaitForSeconds(1f);
      gifElement.Save(GetUnixTime(), _photos.ToArray(), gifWidth, gifHeight);
    }
  }

  string GetUnixTime()
  { return "" + DateTimeOffset.Now.ToUnixTimeSeconds(); }

  private void GifSaved (int id, string path)
  { gifPath = path; }

  private Texture2D GenerateQR(string text)
  {
    Texture2D encoded = new Texture2D(256, 256);
    Color32[] color32 = Encode(text, encoded.width, encoded.height);
    encoded.SetPixels32(color32);
    encoded.Apply();
    return encoded;
  }

  private static Color32[] Encode(string textForEncoding, 
                                  int width, int height)
  {
    BarcodeWriter writer = new BarcodeWriter {
      Format = BarcodeFormat.QR_CODE,
      Options = new QrCodeEncodingOptions {
        Height = height,
        Width = width
      }
    };
    return writer.Write(textForEncoding);
  }
}
