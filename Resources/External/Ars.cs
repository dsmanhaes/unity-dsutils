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
        public class General 
        {
          public Sprite bgIdle;
          public Sprite bgChoices;
          public Sprite bgEnd;
        }
        public class Choices 
        {
          public Sprite background01;
          public Sprite background02;
          public Sprite background03;
          public Sprite background04;
          public Sprite background05;
          public Sprite background06;
        }
        public class Audios 
        {
          public AudioClip trilha;
        }
        public General general = new General();
        public Choices choices = new Choices();
        public Audios audios = new Audios();
      }
    }
  }
}
