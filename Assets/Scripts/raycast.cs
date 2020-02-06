using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycast : MonoBehaviour
{
    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up);
        RaycastHit2D hitR = Physics2D.Raycast(transform.position, Vector2.right);
        RaycastHit2D hitL = Physics2D.Raycast(transform.position, Vector2.left);
        Vector2 up = transform.TransformDirection(Vector2.up) * 10;
        Vector2 right = transform.TransformDirection(Vector2.right) * 10;
        Vector2 left = transform.TransformDirection(Vector2.left) * 10;
        Debug.DrawRay(transform.position, up, Color.green);
        Debug.DrawRay(transform.position, right, Color.green);
        Debug.DrawRay(transform.position, left, Color.green);

        if (hit.collider != null)
        {
            float distance = Mathf.Abs(hit.point.y - transform.position.y);
            Debug.Log(distance);
            if(distance <= 0.1f)
            {
                Debug.Log("Collision!");
                GetComponent<TestMove>().enabled = false;
            }
        }
        if (hitR.collider != null)
        {
            float distanceR = Mathf.Abs(hitR.point.x - transform.position.x);
            Debug.Log(distanceR);
            if (distanceR <= 0.1f)
            {
                Debug.Log("Collision!");
                GetComponent<TestMove>().enabled = false;
            }
        }
        if (hitL.collider != null)
        {
            float distanceL = Mathf.Abs(hitL.point.x - transform.position.x);
            Debug.Log(distanceL);
            if (distanceL <= 0.1f)
            {
                Debug.Log("Collision!");
                GetComponent<TestMove>().enabled = false;
            }
        }
    }
}
