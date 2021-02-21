using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enter : MonoBehaviour
{
    public GameObject obstacle;
    public float minY, maxY;
    public static int number = 10;
    public Vector3 ObstacleL;
    public Vector3 ObstacleR;
    Vector3 LeftWall;
    Vector3 RightWall;
    public GameObject objLeftWall;
    public GameObject objRightWall;
    public static float rightrangeWall;
    public static float leftrangeWall;

    void Awake()
    {   
        //first spwan 
        leftrangeWall = Random.Range(-2.5f,-4f); 
        rightrangeWall = Random.Range(-2.5f,-4f);
        Vector3 LeftWall = new Vector3(-2.5f,leftrangeWall,0);
        Instantiate(objLeftWall, LeftWall,Quaternion.identity);
        Vector3 RightWall = new Vector3(2.5f,rightrangeWall,0);
        Instantiate(objRightWall, RightWall,Quaternion.identity);
        ObstacleL.x = -2f;
        ObstacleR.x = 2f;
        //only left side
        ObstacleL.y = Random.Range(-3f,0);
        Instantiate(obstacle,ObstacleL,Quaternion.Euler(0,0,Random.Range(-10f,10f)));
       

        // x10 spawn

        for(int i=1;i<=number;i++)
        {
            LeftWall.y +=5.6f;
            Instantiate(objLeftWall, LeftWall,Quaternion.identity);
            RightWall.y +=5.6f;
            Instantiate(objRightWall, RightWall,Quaternion.identity);
            ObstacleL.y += Random.Range(minY,maxY);
            ObstacleR.y += Random.Range(minY,maxY);
            Instantiate(obstacle,ObstacleL,Quaternion.Euler(0,0,Random.Range(-10f,10f)));
            Instantiate(obstacle,ObstacleR,Quaternion.Euler(0,180,Random.Range(-10f,10f)));

        }
    }


}