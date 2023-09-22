using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Runner.GameController;

namespace Runner.FinishColiderController
{
    public class FinishColiderController : MonoBehaviour
    {
        public bool isThereWinner = false;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<Runner.CharacterController.CharacterController>() != null)
            {
                Runner.CharacterController.CharacterController characterController = other.gameObject.GetComponent<Runner.CharacterController.CharacterController>();
                characterController.StopRunning();
                if (!isThereWinner)
                {
                    GameManagerr.Instance.gameActionController.isWiner = characterController.ID == GameManagerr.Instance.playerPredictedCharacterID;
                    isThereWinner = true;
                    characterController.ShowIconInWinnerView();
                    GameManagerr.Instance.gameActionController.EndGame?.Invoke();
                }
            }
        }
        public void Reset()
        {
            isThereWinner = false;
        }
    }
}