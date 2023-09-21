using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameActionController : MonoBehaviour
{
    public UnityEvent EndGame;
    public UnityEvent RestartGame;
    public Text timerTxt;
    public bool isWiner;
    private void Start()
    {
        EndGame.AddListener(() => GameManagerr.Instance.playerController.SetResults(isWiner));
        EndGame.AddListener(() => ShowRestartPage());

        RestartGame.AddListener(() => GameManagerr.Instance.obstaclesManager.SetObstaclesInRandomPositions());
        RestartGame.AddListener(() => GameManagerr.Instance.charactersManager.SetCharactersInStartPose());
        RestartGame.AddListener(() => GameManagerr.Instance.charactersManager.SetCharactersSpeeed());
    }

    public void StartingGameWithPrediction(int prediction)
    {
        GameManagerr.Instance.playerPredictedCharacterID = prediction;
        StartCoroutine(TimerForStartGame());
    }
    public void RestartingGame()
    {
        RestartGame?.Invoke();
    }
    public async void ShowRestartPage()
    {
        await System.Threading.Tasks.Task.Delay(1000);
        GameManagerr.Instance.restartPage.ShowRestartPage(isWiner);
        GameManagerr.Instance.charactersManager.CHangeCharactersAnimaatorStatus(false);
    }
    IEnumerator TimerForStartGame()
    {
        timerTxt.gameObject.SetActive(true); 
        for (int i = 3; i >0; i--)
        {
            timerTxt.text = i.ToString();
            yield return new WaitForSeconds(1);
        }
        timerTxt.gameObject.SetActive(false);
        GameManagerr.Instance.charactersManager.StartRunning();
    }
}
 