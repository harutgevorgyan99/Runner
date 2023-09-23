using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Runner.RestartPage
{
    public class RestartPageUI : MonoBehaviour
    {
        [SerializeField] private Text gamesCount;
        [SerializeField] private Text rightPredictionsCount;
        [SerializeField] private Text resultTxt;
        [SerializeField] private GameObject restartPage;
        public RawImage winnerImage;

        private void Start()
        {
            Game.GameEventsManager.Instance.EndGame.AddListener(() => ShowRestartPage(Game.GameEventsManager.Instance.gameStartActions.isWiner));
        }
        public void ShowRestartPage(bool forWinner)
        {
            gamesCount.text = PlayerPrefs.GetInt("gamesCount").ToString();
            rightPredictionsCount.text = PlayerPrefs.GetInt("rightPredictionsCount").ToString();
            if (forWinner)
            {
                resultTxt.text = "You Win!!!";
            }
            else
                resultTxt.text = "You Lose";

            restartPage.SetActive(true);
        }
    }
}