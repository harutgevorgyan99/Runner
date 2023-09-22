using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Runner.AnimatorrController;
using Runner.CharacterController;
using Runner.obstaclesController;
using Runner.PlayerControllers;
using Runner.UIcontroller;

namespace Runner.GameController
{
    public class GameManagerr : MonoBehaviour
    {
        private static GameManagerr instance;
        public static GameManagerr Instance
        {
            get
            {

                if (instance == null)
                {
                    instance = new GameManagerr();
                }

                return instance;
            }
        }

        public int playerPredictedCharacterID;
        public CharactersManager charactersManager;
        public GameActionController gameActionController;
        public RestartPageView restartPage;
        public PlayerController playerController;
        public ObstaclesManager obstaclesManager;
        public AnimatorController animatorController;
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }

        }
        private void Start()
        {
            charactersManager.SetCharactersSpeeed();
        }
    }
}