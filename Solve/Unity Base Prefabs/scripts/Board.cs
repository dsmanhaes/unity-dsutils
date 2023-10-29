using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
[RequireComponent(typeof(CanvasGroup))]
public class Board : MonoBehaviour
{
  public bool isFirst;
  public UnityEvent onAwake;
  public UnityEvent onShow;
  public UnityEvent onHide;
  private CanvasGroup canvasGroup;
  private void Awake()
  {
    canvasGroup = GetComponent<CanvasGroup>();
    canvasGroup.alpha = (isFirst) ? 1 : 0;
    canvasGroup.blocksRaycasts = isFirst;
    canvasGroup.interactable = isFirst;
    onAwake?.Invoke();
  }
  public void Show()
  {
    canvasGroup.blocksRaycasts = true;
    canvasGroup.interactable = true;
    canvasGroup.alpha = 0;
    canvasGroup.DOFade(1, 0.5f);
    onShow?.Invoke();
  }
  public void Hide()
  {
    canvasGroup.blocksRaycasts = false;
    canvasGroup.interactable = false;
    canvasGroup.DOFade(0, 0.5f);
    onHide?.Invoke();
  }
}
