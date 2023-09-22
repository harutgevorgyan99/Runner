using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Runner.obstaclesController
{
    public class ObstaclesManager : MonoBehaviour
    {
        private List<Vector3> obstaclesPositions = new List<Vector3>();
        [SerializeField] private List<GameObject> obstacles = new List<GameObject>();

        private void Awake()
        {
            for (int i = 0; i < obstacles.Count; i++)
            {
                obstaclesPositions.Add(obstacles[i].transform.position);
            }
        }
        public void SetObstaclesInRandomPositions()
        {
            ShuffleArray(obstaclesPositions);
            for (int i = 0; i < obstacles.Count; i++)
            {
                obstacles[i].transform.position = obstaclesPositions[i];
            }
        }

        private void ShuffleArray(List<Vector3> array)
        {
            int n = array.Count;
            for (int i = 0; i < n; i++)
            {
                int randomIndex = Random.Range(i, n);
                Vector3 temp = array[i];
                array[i] = array[randomIndex];
                array[randomIndex] = temp;
            }
        }
    }
}