using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishColiderController : MonoBehaviour
{
    public bool isThereWinner = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CharacterController>() != null)
        {
            CharacterController characterController = other.gameObject.GetComponent<CharacterController>();
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
