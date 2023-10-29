using UnityEngine;

namespace Solve
{
  namespace External
  {
    namespace Impl
    {
      public class Levels
      {
        [System.Serializable]
        public class Cor
        {
          public Color cor;
          public Dyno[] dynos;
        }
        public Cor[] cores;
        public Levels()
        {
          cores = new Cor[] {
            new Cor() {
              cor = new Color(1, 0, 0, 1),
              dynos = new Dyno[] {
                new Dyno() {
                  species = "dyno01",
                  questionText = "Tem dyno e tem 01",
                  mistakeText = "dessa vez era o dyno01.",
                  rightText = "É o dyno01! Viu como ele é?"
                },
                new Dyno() {
                  species = "dyno02",
                  questionText = "Tem dyno e tem 02",
                  mistakeText = "dessa vez era o dyno02.",
                  rightText = "É o dyno02! Viu como ele é?"
                },
              },
            },
            new Cor() {
              cor = new Color(0, 1, 0, 1),
              dynos = new Dyno[] {
                new Dyno() {
                  species = "dyno03",
                  questionText = "Tem dyno e tem 03",
                  mistakeText = "dessa vez era o dyno03.",
                  rightText = "É o dyno03! Viu como ele é?"
                },
                new Dyno() {
                  species = "dyno04",
                  questionText = "Tem dyno e tem 04",
                  mistakeText = "dessa vez era o dyno04.",
                  rightText = "É o dyno04! Viu como ele é?"
                },
              },
            },
            new Cor() {
              cor = new Color(0, 0, 1, 1),
              dynos = new Dyno[] {
                new Dyno() {
                  species = "dyno05",
                  questionText = "Tem dyno e tem 05",
                  mistakeText = "dessa vez era o dyno05.",
                  rightText = "É o dyno05! Viu como ele é?"
                },
                new Dyno() {
                  species = "dyno06",
                  questionText = "Tem dyno e tem 06",
                  mistakeText = "dessa vez era o dyno06.",
                  rightText = "É o dyno06! Viu como ele é?"
                },
              },
            },
            new Cor() {
              cor = new Color(1, 1, 0, 1),
              dynos = new Dyno[] {
                new Dyno() {
                  species = "dyno07",
                  questionText = "Tem dyno e tem 07",
                  mistakeText = "dessa vez era o dyno07.",
                  rightText = "É o dyno07! Viu como ele é?"
                },
                new Dyno() {
                  species = "dyno08",
                  questionText = "Tem dyno e tem 08",
                  mistakeText = "dessa vez era o dyno08.",
                  rightText = "É o dyno08! Viu como ele é?"
                },
              },
            },
            new Cor() {
              cor = new Color(1, 0, 1, 1),
              dynos = new Dyno[] {
                new Dyno() {
                  species = "dyno09",
                  questionText = "Tem dyno e tem 09",
                  mistakeText = "dessa vez era o dyno09.",
                  rightText = "É o dyno09! Viu como ele é?"
                },
                new Dyno() {
                  species = "dyno10",
                  questionText = "Tem dyno e tem 10",
                  mistakeText = "dessa vez era o dyno10.",
                  rightText = "É o dyno10! Viu como ele é?"
                },
              },
            },
            new Cor() {
              cor = new Color(0, 1, 1, 1),
              dynos = new Dyno[] {
                new Dyno() {
                  species = "dyno11",
                  questionText = "Tem dyno e tem 11",
                  mistakeText = "dessa vez era o dyno11.",
                  rightText = "É o dyno11! Viu como ele é?"
                },
                new Dyno() {
                  species = "dyno12",
                  questionText = "Tem dyno e tem 12",
                  mistakeText = "dessa vez era o dyno12.",
                  rightText = "É o dyno12! Viu como ele é?"
                },
              },
            },
          };
        }
      }
    }
  }
}
