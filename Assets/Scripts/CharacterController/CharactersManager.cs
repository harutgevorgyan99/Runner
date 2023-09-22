using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Runner.CharacterController
{
    public class CharactersManager : MonoBehaviour
    {
        public List<CharacterController> characterControllers = new List<CharacterController>();

        public void StartRunning()
        {
            foreach (var item in characterControllers)
            {
                item.StartRunning();
            }
        }
        public void SetCharactersInStartPose()
        {
            foreach (var item in characterControllers)
            {
                item.MoveCharacterToStartPose();
            }
        }
        public void SetCharactersSpeeed()
        {
            foreach (var item in characterControllers)
            {
                item.SetSpeedToCharacter();
            }
        }
        public void CHangeCharactersAnimaatorStatus(bool status)
        {
            foreach (var item in characterControllers)
            {
                item.ChangeAnimatorStatus(status);
            }
        }
    }
}