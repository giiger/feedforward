using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycast : MonoBehaviour
{
    void Update()
    {
        RaycastHit hit;
        float theDistance;

        Vector3 up = transform.TransformDirection(Vector3.up) * 10;
        Debug.DrawRay(transform.position, up, Color.green);

        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up),out hit, Mathf.Infinity))
        {
            theDistance = hit.distance;
            Debug.Log("hit");
            Debug.Log(theDistance);
        }
    }
}
