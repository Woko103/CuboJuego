using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleGenerator : MonoBehaviour
{ 
    public Transform playerTransform;
    public Transform obstaclePrefab;

    public int timer = 0;

    public int counterMax = 30;
    public int counter = 0;

    public float obstacleLastPosition = 0;

    void FixedUpdate ()
    {
        if (obstacleLastPosition == 0)
        {
            obstacleLastPosition = playerTransform.position.z + 70;
        }
        if (timer == 0)
        {
            if (counter == counterMax)
            {
                Transform obstacle = null;
                int option = Random.Range(0, 4);
                if (option == 0)
                {
                    obstacle = Instantiate(obstaclePrefab, new Vector3(0, 1, obstacleLastPosition), Quaternion.identity);
                    obstacle.localScale = new Vector3(10, 0.8f, 1);
                }
                else if (option == 1)
                {
                    float positionX = playerTransform.position.x;
                    if (positionX < -2)
                    {
                        positionX = -2;
                    }
                    else if (positionX > 2)
                    {
                        positionX = 2;
                    }

                    obstacle = Instantiate(obstaclePrefab, new Vector3(positionX, 1, obstacleLastPosition), Quaternion.identity);
                    obstacle.localScale = new Vector3(5, 4, 1);
                }
                else if (option == 2)
                {
                    obstacle = Instantiate(obstaclePrefab, new Vector3(2, 1, obstacleLastPosition), Quaternion.identity);
                    obstacle.localScale = new Vector3(6, 2, 1);
                }
                else if (option == 3)
                {
                    obstacle = Instantiate(obstaclePrefab, new Vector3(-2, 1, obstacleLastPosition), Quaternion.identity);
                    obstacle.localScale = new Vector3(6, 2, 1);
                }

                obstacleLastPosition = obstacle.position.z + 30;

                counter = 0;
            }
            else ++counter;
        }
        else --timer;
    }
}
