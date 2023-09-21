using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RestartPageView : MonoBehaviour
{
    [SerializeField] private Text gamesCount;
    [SerializeField] private Text rightPredictionsCount;
    [SerializeField] private Text resultTxt;
    [SerializeField] private GameObject restartPage;
    public RawImage winnerImage;
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
