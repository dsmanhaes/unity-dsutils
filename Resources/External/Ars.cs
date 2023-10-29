namespace Solve
{
  namespace External
  {
    namespace Impl
    {
      using System.Collections.Generic;
      using UnityEngine;
      public class Ars
      {
        public Dictionary<string, Dictionary<string, object>> contents =
            new Dictionary<string, Dictionary<string, object>>();
        public class Audios
        {
          public AudioClip click;
        }
        public class Base
        {
          public Sprite base01;
        }
        public class TelaIdle 
        {
          public Sprite bg;
        }
        public Audios audios = new Audios();
        public Base base = new Base();
        public TelaIdle telaIdle = new TelaIdle();
      }
    }
  }
}
