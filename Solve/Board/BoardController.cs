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
      private static Board _actualBoard;
      public static Board actualBoard
      { get { return _actualBoard; } }
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
        _actualBoard.Hide();
        _actualBoard = board;
        _actualBoard.Show();
      }
      public static void Reset()
      {
        ChangeTo(_controller.firstBoard);
      }
    }
  }
}
