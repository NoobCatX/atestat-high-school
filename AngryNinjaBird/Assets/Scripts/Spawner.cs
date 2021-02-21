using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obstacle;
    public float minY, maxY;
    public Vector3 obstacleposL;
    public Vector3 obstacleposR;
    public GameObject objRightWall;
    public GameObject objLeftWall;
    public Vector3 RightWall;
    public Vector3 LeftWall;
    
    void Start()
    {
        //setting some positions 
        RightWall.x = 2.50f;
        LeftWall.x = -2.50f;
        obstacleposL.x = -2f;
        obstacleposR.x =2f;
        //formula for start position of _ on click spawn_
        LeftWall.y = Enter.number * 5.6f + Enter.leftrangeWall;
        RightWall.y = Enter.number * 5.6f + Enter.rightrangeWall;
    }
    void Update()
    {
        //spawn pe rand (on click)
        if(Input.GetMouseButtonDown(0))
        {
            obstacleposL.y += Random.Range(minY,maxY);
            Instantiate(obstacle,obstacleposL,Quaternion.Euler(0,0,Random.Range(10f,-10f)));
            obstacleposR.y += Random.Range(minY,maxY);
            Instantiate(obstacle,obstacleposR,Quaternion.Euler(0,180,Random.Range(10f,-10f)));
            LeftWall.y +=5.6f;
            Instantiate(objLeftWall, LeftWall,Quaternion.identity);
            RightWall.y +=5.6f;
            Instantiate(objRightWall, RightWall,Quaternion.identity);
        }
    }
}
