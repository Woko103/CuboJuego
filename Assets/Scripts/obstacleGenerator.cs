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

    //The center of the ground
    public float CenterXPosition = 0;

    void FixedUpdate ()
    {
        //For the first obstacle
        if (obstacleLastPosition == 0)
        {
            //Saves the new obstacle's Z position
            obstacleLastPosition = playerTransform.position.z + 70;
        }
        //Waits for create the first obstacle
        if (timer == 0)
        {
            //Waits for create a new obstacle
            if (counter == counterMax)
            {
                Transform obstacle = null;
                int option = Random.Range(0, 4); //4 types of obstacle
                switch(option)
                {
                    case 0:
                        //Low obstacle
                        obstacle = Instantiate(obstaclePrefab, new Vector3(CenterXPosition, 1, obstacleLastPosition), Quaternion.identity);
                        obstacle.localScale = new Vector3(10, 0.8f, 1);

                        break;

                    case 1:
                        //Obstacle in front of the player
                        float positionX = playerTransform.position.x;
                        if (positionX < -2)
                        {
                            positionX = -2;
                        }
                        else if (positionX > 2)
                        {
                            positionX = 2;
                        }

                        obstacle = Instantiate(obstaclePrefab, new Vector3(CenterXPosition+positionX, 1, obstacleLastPosition), Quaternion.identity);
                        obstacle.localScale = new Vector3(5, 4, 1);

                        break;

                    case 2:
                        //Right obstacle
                        obstacle = Instantiate(obstaclePrefab, new Vector3(CenterXPosition+2, 1, obstacleLastPosition), Quaternion.identity);
                        obstacle.localScale = new Vector3(6, 2, 1);

                        break;
                    
                    case 3:
                        //Left obstacle
                        obstacle = Instantiate(obstaclePrefab, new Vector3(CenterXPosition-2, 1, obstacleLastPosition), Quaternion.identity);
                        obstacle.localScale = new Vector3(6, 2, 1);

                        break;
                }

                obstacleLastPosition = obstacle.position.z + 30;

                counter = 0;
            }
            else ++counter;
        }
        else --timer;
    }
}
