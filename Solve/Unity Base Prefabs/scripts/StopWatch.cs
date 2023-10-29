using UnityEngine;
using UnityEngine.Events;
using TMPro;
public abstract class StopWatch : MonoBehaviour
{
  public UnityEvent OnTimePassed;
  public TMP_Text timeText;
  private float initialTime = 0;
  protected float totalTime;
  private void Start() { SetTimer(); }
  protected abstract void SetTimer();
  public void StartClock() { initialTime = Time.time; }
  private void Update()
  {
    if (initialTime != 0)
    {
      if (Time.time - initialTime > totalTime)
      {
        initialTime = 0;
        OnTimePassed?.Invoke();
      }
      else if (timeText != null)
        timeText.text = (totalTime - (Time.time - initialTime)).ToString("0");
    }
  }
}
