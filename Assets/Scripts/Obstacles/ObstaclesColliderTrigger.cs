using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Runner.CharacterProperties;
namespace Runner.Obstacles
{
    public class ObstaclesColliderTrigger : MonoBehaviour
    {
        public JumpPositionData jumpPositionData;


        private void OnTriggerEnter(Collider collision)
        {
            var character = collision.gameObject.GetComponent<Character>();
            if (character != null)
            {
                character.Jump(this);
            }
           
        }
    }
}