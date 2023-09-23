using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Runner.CharacterProperties
{
    public class CharacterPrediction : MonoBehaviour
    {
        [SerializeField] private List<CharacterData> characters = new List<CharacterData>();
        public int playerPredictedCharacterID;
        [SerializeField] private Button playBt;
        public void SelectCharacter(CharacterData character)
        {
            foreach (var item in characters)
            {
                item.icon.color = Color.white;
            }
            character.icon.color = new Color(1, 1, 1, 0.5f);
            playerPredictedCharacterID = character.ID;

            if (!playBt.interactable)
                playBt.interactable = true;
        }
    }
}