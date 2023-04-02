using UnityEngine;

namespace Solve
{
  namespace Board
  {
    public abstract class Board : MonoBehaviour
    {
      protected delegate void In();
      protected In OnIn;
      protected delegate void Out();
      protected Out OnOut;
      public delegate void End();
      public End OnEnd;
      public void Show()
      {
        OnIn?.Invoke();
      }
      public void Hide()
      {
        OnOut?.Invoke();
      }
      protected void Finish(Board nextBoard)
      {
        OnEnd?.Invoke();
        BoardController.ChangeTo(nextBoard);
      }
    }
  }
}
