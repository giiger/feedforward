using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycast : MonoBehaviour
{
    void FixedUpdate()
    {
        Vector2 rDir = Quaternion.AngleAxis(25.0f, Vector3.forward ) * Vector2.up * 3;
        Vector2 lDir = Quaternion.AngleAxis(-25.0f, Vector3.forward ) * Vector2.up * 3;
        Vector2 up = transform.TransformDirection(Vector2.up) * 10;
        Vector2 right = transform.TransformDirection(rDir);
        Vector2 left = transform.TransformDirection(lDir);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up);
        RaycastHit2D hitR = Physics2D.Raycast(transform.position, Vector2.right);
        RaycastHit2D hitL = Physics2D.Raycast(transform.position, Vector2.left);
        
        Debug.DrawRay(transform.position, up, Color.green);
        Debug.DrawRay(transform.position, left, Color.green);
        Debug.DrawRay(transform.position, right, Color.green);

        if (hit.collider != null)
        {
            float distance = Mathf.Abs(hit.point.y - transform.position.y);
            
            if(distance <= 0.25f)
            {
                Debug.Log("Collision!");
                GetComponent<TestMove>().enabled = false;
                Destroy(this.gameObject);
            }
            else if (distance <= 1f)
            {
                Debug.DrawRay(transform.position, up, Color.yellow);
            }
        }
        if (hitR.collider != null)
        {
            float distanceR = Mathf.Abs(hitR.point.x - transform.position.x);
            Debug.Log(rDir + "r");
            if (distanceR <= 0.25f)
            {
                Debug.Log("Collision!");
                GetComponent<TestMove>().enabled = false;
                Destroy(this.gameObject);
            }
            else if (distanceR <= 1f)
            {
                Debug.DrawRay(transform.position, right, Color.yellow);
            }
        }
        if (hitL.collider != null)
        {
            float distanceL = Mathf.Abs(hitL.point.x - transform.position.x);
            Debug.Log(lDir + "l");
            if (distanceL <= 0.25f)
            {
                Debug.Log("Collision!");
                GetComponent<TestMove>().enabled = false;
                Destroy(this.gameObject);
            }
            else if(distanceL <= 1f)
            {
                Debug.DrawRay(transform.position, left, Color.yellow);
            }
        }
    }
}
