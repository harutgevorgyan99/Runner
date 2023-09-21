using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesController : MonoBehaviour
{
    [SerializeField] private ObstaclesData obstaclesData;

    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<CharacterController>() != null)
        {
            CharacterController character = collision.gameObject.GetComponent<CharacterController>();
            float playerDistancFromObst = Vector3.Distance(character.transform.position, obstaclesData.transform.position);
            float speed = obstaclesData.normalJumpingDistance / playerDistancFromObst;
            collision.gameObject.GetComponent<CharacterController>().Jump(speed);
          
            collision.gameObject.GetComponent<CharacterController>().enabled=false;
            Debug.Log(collision.gameObject.transform.position);
            Debug.LogError($" normal = {obstaclesData.normalJumpingDistance} || distance of player = {Vector3.Distance(collision.gameObject.transform.position, transform.position)}");
        }
    }
}
