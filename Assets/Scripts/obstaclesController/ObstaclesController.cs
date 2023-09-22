using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Runner.CharacterController;
namespace Runner.obstaclesController
{
    public class ObstaclesController : MonoBehaviour
    {
        [SerializeField] private ObstaclesData obstaclesData;


        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.GetComponent<Runner.CharacterController.CharacterController>() != null)
            {
                Runner.CharacterController.CharacterController character = collision.gameObject.GetComponent<Runner.CharacterController.CharacterController>();
                float playerDistancFromObst = Vector3.Distance(character.transform.position, obstaclesData.transform.position);
                float speed = obstaclesData.normalJumpingDistance / playerDistancFromObst;
                collision.gameObject.GetComponent<Runner.CharacterController.CharacterController>().Jump(speed);

                collision.gameObject.GetComponent<Runner.CharacterController.CharacterController>().enabled = false;
                Debug.Log(collision.gameObject.transform.position);
                Debug.LogError($" normal = {obstaclesData.normalJumpingDistance} || distance of player = {Vector3.Distance(collision.gameObject.transform.position, transform.position)}");
            }
        }
    }
}