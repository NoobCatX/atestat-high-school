using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform bird;
    float smoothSpeed = .3f;
    void FixedUpdate()
    {
        if(bird.position.y > transform.position.y)
        {
            Vector3 newPos = new Vector3(transform.position.x, bird.position.y, transform.position.z);
            Vector3 smooth = Vector3.Lerp(transform.position, newPos, smoothSpeed);
            transform.position = smooth;
         }

    }

}
