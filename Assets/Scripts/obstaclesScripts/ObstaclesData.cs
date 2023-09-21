using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesData : MonoBehaviour
{
    [SerializeField] Transform normalJumpingPosition;
    public float normalJumpingDistance;

    private void Awake()
    {
        normalJumpingDistance = Vector3.Distance(transform.position, normalJumpingPosition.position);
       // Debug.Log(transform.position);
        Debug.Log($"normal jumping distance = {normalJumpingDistance}");
    }
}
