using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.PlayerControllers
{
    public class PlayerController : MonoBehaviour
    {
        private int gamesCount = 0;
        private int rightPredictionCount = 0;

        private void Awake()
        {
            if (PlayerPrefs.HasKey("gamesCount"))
                gamesCount = PlayerPrefs.GetInt("gamesCount");
            else
                PlayerPrefs.SetInt("gamesCount", 0);

            if (PlayerPrefs.HasKey("rightPredictionsCount"))
                rightPredictionCount = PlayerPrefs.GetInt("rightPredictionsCount");
            else
                PlayerPrefs.SetInt("rightPredictionsCount", 0);
        }

        public void SetResults(bool isWin)
        {
            gamesCount++;

            if (isWin)
                rightPredictionCount++;

            PlayerPrefs.SetInt("gamesCount", gamesCount);
            PlayerPrefs.SetInt("rightPredictionsCount", rightPredictionCount);
        }
    }
}