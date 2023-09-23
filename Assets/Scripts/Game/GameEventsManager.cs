using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Runner.CharacterProperties;
using Runner.Obstacles;
using Runner.Player;
using Runner.RestartPage;
using UnityEngine.Events;

namespace Runner.Game
{
    public class GameEventsManager : MonoBehaviour
    {
        private static GameEventsManager instance;
        public static GameEventsManager Instance
        {
            get
            {

                if (instance == null)
                {
                    instance = new GameEventsManager();
                }

                return instance;
            }
        }

        public int playerPredictedCharacterID;
        public GameStartActions gameStartActions;
        public RestartPageUI restartPageUi;
        public PlayerStatistics playerStatistics;
        public ObstaclesPositions obstaclesPositions;

        public List<Character> playingCharacters = new List<Character>();
        public List<Character> finishLinePassedCharacters = new List<Character>();

        [Space(15)]
        [Header("Game Events")]

        // Some actions added by the inspector
        public UnityEvent StartGame;
        public UnityEvent EndGame;
        public UnityEvent RestartGame;
        public UnityEvent RunCharacters;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }

            EndGame.AddListener(() =>
            {

                finishLinePassedCharacters.Clear();
            });

          
        }
        public async void PassingFinishLine(CharacterProperties.Character character)
        {
            if (finishLinePassedCharacters.Contains(character))
                return;


            if (finishLinePassedCharacters.Count == 0)// For first character who passed finish line
            {
                gameStartActions.isWiner = (character.ID == playerPredictedCharacterID);
                character.ShowIconInWinnerView();
            }
            finishLinePassedCharacters.Add(character);
            character.StopRunning();
            if (finishLinePassedCharacters.Count == playingCharacters.Count)
            {
                playerStatistics.SetResults(gameStartActions.isWiner);
                await System.Threading.Tasks.Task.Delay(1000);
                EndGame?.Invoke();
            }
        }
    }
}