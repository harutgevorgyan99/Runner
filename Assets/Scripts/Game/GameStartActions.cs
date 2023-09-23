using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Runner.CharacterProperties;
namespace Runner.Game
{
    public class GameStartActions : MonoBehaviour
    {
        public Text timerTxt;
        public bool isWiner;
        public CharacterPrediction characterPrediction;
        private void Start()
        {
          
            GameEventsManager.Instance.StartGame.AddListener(() => StartingGameWithPrediction(characterPrediction.playerPredictedCharacterID));
        }

        public void StartingGameWithPrediction(int prediction)
        {
            GameEventsManager.Instance.playerPredictedCharacterID = prediction;
            StartCoroutine(TimerForStartGame());
        }
        public void StartingGame()
        {
            GameEventsManager.Instance.StartGame?.Invoke();
        }
        public void RestartingGame()
        {
            GameEventsManager.Instance.RestartGame?.Invoke();
        }

        IEnumerator TimerForStartGame()
        {
            timerTxt.gameObject.SetActive(true);
            for (int i = 3; i > 0; i--)
            {
                timerTxt.text = i.ToString();
                yield return new WaitForSeconds(1);
            }
            timerTxt.gameObject.SetActive(false);
            GameEventsManager.Instance.RunCharacters?.Invoke();
        }
    }
}