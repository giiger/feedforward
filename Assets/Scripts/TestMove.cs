using UnityEngine;

public class TestMove: MonoBehaviour
{
    public float turnpower = 2;
    private Vector3 myVel;
    private Vector3 acceleration;
    private float maxSpeed = 0.1f;
    void Start()
    {
        myVel = new Vector3(0, 0, 0);
        acceleration = new Vector3(0, 0, 0);
    }


    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.W))
        {
            float currentspeed = myVel.magnitude;
            myVel.Normalize();
            transform.Translate(0, acceleration.y, 0);
            if (myVel.magnitude <= maxSpeed)
            {
                acceleration.y += 0.001f;
            }
        }
            
            
        
        if (Input.GetKey(KeyCode.S))
        {
            
            float currentspeed = myVel.magnitude;
            myVel.Normalize();
            transform.Translate(0, acceleration.y, 0);
            if(acceleration.y >= -2 *maxSpeed)
            {
                acceleration.y -= 0.001f;
            }
            
            
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
        gas();
    }
    void gas()
    {
        if(!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            if(acceleration.y >= 0)
            {
                transform.Translate(0, acceleration.y, 0);
                acceleration.y -= 0.0005f;
            }
            else if (acceleration.y <= 0)
            {
                transform.Translate(0, acceleration.y, 0);
                acceleration.y += 0.0005f;
            }

        }
    }
    

}