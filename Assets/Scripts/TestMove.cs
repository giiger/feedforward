using UnityEngine;

public class TestMove: MonoBehaviour
{
    public float power = 3;
    public float maxspeed = 5;
    public float turnpower = 2;
    public float friction = 2;
    private Vector2 curspeed;
    private Vector3 myVel;
    Rigidbody2D rigidbody2D;
    
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        myVel = new Vector3(0,0,0);
    }


    void FixedUpdate()
    {
        curspeed = new Vector2(rigidbody2D.velocity.x, rigidbody2D.velocity.y);

        if (curspeed.magnitude > maxspeed)
        {
            curspeed = curspeed.normalized;
            curspeed *= maxspeed;
        }

        if (Input.GetKey(KeyCode.W))
        {
            float currentspeed = myVel.magnitude;
            myVel.Normalize();
            myVel *= currentspeed + power;

            rigidbody2D.drag = friction;
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (curspeed.x > 0)
            {
                rigidbody2D.AddForce(-(transform.up) * (power / 2));
            }
            rigidbody2D.drag = friction;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * turnpower);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.forward * -turnpower);
        }

        transform.position += myVel;
    }
    

}