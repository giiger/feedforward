using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove : MonoBehaviour
{
    public GameObject car;
    //change velocity to vector
    float velocity;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            Vector2 position = car.transform.position;
            velocity += 0.001f;
            position.y += velocity;
            position.x -= 0.03f;
            car.transform.position = position;
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            Vector2 position = car.transform.position;
            velocity += 0.001f;
            position.y += velocity;
            position.x += 0.03f;
            car.transform.position = position;
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            Vector2 position = car.transform.position;
            velocity -= 0.001f;
            position.y += velocity;
            position.x -= 0.03f;
            car.transform.position = position;
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            Vector2 position = car.transform.position;
            velocity -= 0.001f;
            position.y += velocity;
            position.x += 0.03f;
            car.transform.position = position;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            Vector2 position = car.transform.position;
            velocity += 0.001f;
            position.y += velocity;
            car.transform.position = position;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Vector2 position = car.transform.position;
            position.x -= 0.03f;
            car.transform.position = position;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Vector2 position = car.transform.position;
            velocity -= 0.001f;
            position.y += velocity;
            car.transform.position = position;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Vector2 position = car.transform.position;
            position.x += 0.03f;
            car.transform.position = position;
        }
        else if(velocity != 0)
        {
            Vector2 position = car.transform.position;
            position.y += velocity;
            velocity -= 0.002f;
            car.transform.position = position;
        }
    }
}
