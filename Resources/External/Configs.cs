using UnityEngine;

namespace Solve
{
  namespace External
  {
    namespace Impl
    {
      public class Configs
      {
        [System.Serializable]
        public class Button
        { public Color cor; }
        public float idleTime = 60.0f;
        public float feedbackTime = 5.0f;
        public Button[] botoes;
        public Configs()
        {
          botoes = new Button[] {
            new Button() { cor = new Color(1, 0, 0, 1) },
            new Button() { cor = new Color(0, 1, 0, 1) },
            new Button() { cor = new Color(0, 0, 1, 1) },
            new Button() { cor = new Color(1, 1, 0, 1) },
            new Button() { cor = new Color(1, 0, 1, 1) },
            new Button() { cor = new Color(0, 1, 1, 1) },
          };
        }
      }
    }
  }
}
