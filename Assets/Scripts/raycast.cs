using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class raycast : MonoBehaviour
{
    public float FrontRaycastLength = 2, SideRaycastLength = 1, numOfRays = 3, startDirection = 80;

    private Vector2[] vectors;

    private RaycastHit2D[] hits;

    private float rotateBy;

    void Start() {
        vectors = new Vector2[(int) numOfRays];
        hits = new RaycastHit2D[(int) numOfRays];

        rotateBy = (180 - 2 * (90 - startDirection)) / (numOfRays - 1);
    }

    void FixedUpdate()
    {
        //int currentCheckpoint = 0;
        //bool cleared = false;
        //int clearedOnce = 0;
        if (numOfRays % 2 == 1) {
            for (int i = 0; i < numOfRays; i++) {

                if (i < numOfRays / 2) {
                    vectors[i] = Quaternion.Euler(0, 0, transform.rotation.z + i * rotateBy - startDirection) * transform.up * (SideRaycastLength + i * (FrontRaycastLength - SideRaycastLength) / ((int) numOfRays / 2));
                } else {
                    vectors[i] = Quaternion.Euler(0, 0, transform.rotation.z + i * rotateBy - startDirection) * transform.up * (FrontRaycastLength + (((int) numOfRays / 2) - i) * (FrontRaycastLength - SideRaycastLength) / ((int)numOfRays / 2));
                }

                print(vectors[i].magnitude);
            }
        }
        print("");
        for (int i = 0; i < numOfRays; i++) {
            hits[i] = Physics2D.Raycast(transform.position, vectors[i]);
            if (hits[i].collider.gameObject.name == "Road Outline(outer)" || hits[i].collider.gameObject.name == "Road Outline(inner)") {
                //print("Hit! Ray: " + (i + 1).ToString() + " Dist: " + hits[i].distance.ToString());
                Debug.DrawRay(transform.position, vectors[i], Color.red);
            } else {
                Debug.DrawRay(transform.position, vectors[i], Color.green);
            }
        }


        //float distance = Mathf.Abs(hitF.point.y - transform.position.y);

        //if (hitF.collider != null && hitF.collider.name.Equals(checkpoints)) {
        //    if (distance <= 0.15f) {
        //        Debug.Log("Collision!");
        //        GetComponent<TestMove>().enabled = false;
        //        Destroy(this.gameObject);
        //    } else if (distance <= 1f) {
        //        Debug.DrawRay(transform.position, up, Color.yellow);
        //    }
        //}
        //if (hitR.collider != null) {
        //    float distanceR = Mathf.Abs(hitR.point.x - transform.position.x);

        //    if (distanceR <= 0.15f) {
        //        Debug.Log("Collision!");
        //        GetComponent<TestMove>().enabled = false;
        //        Destroy(this.gameObject);
        //    } else if (distanceR <= 1f) {
        //        Debug.DrawRay(transform.position, right, Color.yellow);
        //    }
        //}
        //if (hitL.collider != null) {
        //    float distanceL = Mathf.Abs(hitL.point.x - transform.position.x);

        //    if (distanceL <= 0.15f) {
        //        Debug.Log("Collision!");
        //        GetComponent<TestMove>().enabled = false;
        //        Destroy(this.gameObject);
        //    } else if (distanceL <= 1f) {
        //        Debug.DrawRay(transform.position, left, Color.yellow);
        //    }
        //}

    }
    //List<string> checkpoints = new List<string> { "checkpoint 1", "checkpoint 2", "checkpoint 3", "checkpoint 4", "checkpoint 5", "checkpoint 6", "checkpoint 7", "checkpoint 8", "checkpoint 9", "checkpoint 10", "checkpoint 11", "checkpoint 12", "checkpoint 13", "checkpoint 14", "checkpoint 15", "checkpoint 16", "checkpoint 17", "checkpoint 18", "checkpoint 19", "checkpoint 20", "checkpoint 21", "checkpoint 22", "checkpoint 23" };

    //foreach (string chpnt in checkpoints)
    //{
    //    if (hit.collider.name.Equals(chpnt))
    //    {
    //        if (distance <= 0.25f)
    //        {

    //            cleared = true;
    //            if (cleared == true && clearedOnce == 0)
    //            {
    //                currentCheckpoint += 1;
    //            }

    //            Debug.Log("cleared" + hit.collider.name);
    //            clearedOnce += 1;
    //        }
    //        cleared = false;
    //        break;
    //    }   
    //}
}
