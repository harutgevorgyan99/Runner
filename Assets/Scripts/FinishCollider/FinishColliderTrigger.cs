using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Runner.Game;
using UnityEngine.Events;

namespace Runner.FinishCollider
{
    public class FinishColliderTrigger : MonoBehaviour
    {
        //Actions added by the inspector
        public UnityEvent FinishLinePassed;
        private void OnTriggerEnter(Collider other)
        {
            var character = other.gameObject.GetComponent<CharacterProperties.Character>();
            if (character != null)
            {
                GameEventsManager.Instance.PassingFinishLine(character);
                FinishLinePassed?.Invoke();
            }

        }

    }
}