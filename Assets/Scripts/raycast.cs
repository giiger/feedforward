using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class raycast : MonoBehaviour
{
    void FixedUpdate()
    {
        
        int currentCheckpoint = 0;
        bool cleared = false;
        int clearedOnce = 0;
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

        float distance = Mathf.Abs(hit.point.y - transform.position.y);
        List<string> checkpoints = new List<string> { "checkpoint 1", "checkpoint 2", "checkpoint 3", "checkpoint 4", "checkpoint 5", "checkpoint 6", "checkpoint 7", "checkpoint 8", "checkpoint 9", "checkpoint 10", "checkpoint 11", "checkpoint 12", "checkpoint 13", "checkpoint 14", "checkpoint 15", "checkpoint 16", "checkpoint 17", "checkpoint 18", "checkpoint 19", "checkpoint 20", "checkpoint 21", "checkpoint 22", "checkpoint 23" };

        foreach (string chpnt in checkpoints)
        {
            if (hit.collider.name.Equals(chpnt))
            {
                if (distance <= 0.25f)
                {
                    
                    cleared = true;
                    if (cleared == true && clearedOnce == 0)
                    {
                        currentCheckpoint += 1;
                    }
                    
                    Debug.Log("cleared" + hit.collider.name);
                    clearedOnce += 1;
                }
                cleared = false;
                break;
            }   
        }
        if (hit.collider != null && hit.collider.name.Equals(checkpoints))
        {
            
            
            
            if(distance <= 0.15f)
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
            
            if (distanceR <= 0.15f)
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
            
            if (distanceL <= 0.15f)
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
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("cleared" + collision);
    }
}
