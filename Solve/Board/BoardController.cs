using UnityEngine;

namespace Solve
{
  namespace Board
  {
    using Debug;

    public class BoardController : MonoBehaviour
    {
      public Board firstBoard;
      private static BoardController _controller;
      private Board _actualBoard;
      public void Awake()
      {
        if (firstBoard == null)
          DebugController.Error(typeof(BoardController), "The firstBoard isn't set");
        _controller = this;
      }
      public void Start()
      {
        _actualBoard = firstBoard;
        _actualBoard.Show();
      }
      public static void ChangeTo(Board board)
      {
        _controller._actualBoard.Hide();
        _controller._actualBoard = board;
        _controller._actualBoard.Show();
      }
      public static void Reset()
      {
        ChangeTo(_controller.firstBoard);
      }
    }
  }
}
