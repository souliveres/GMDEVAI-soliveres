using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    public Transform goal;
    public float speed = 0f;
    public float rotSpeed = 15f;
    public float acceleration = 5f;
    public float deceleration = 5f;
    public float minSpeed = 0f;
    public float maxSpeed = 20f;
    public float brakeAngle = 20f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 LookAtGoal = new Vector3(goal.position.x,
                                        this.transform.position.y,
                                        goal.position.z);

        Vector3 direction = LookAtGoal - this.transform.position;

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                                    Quaternion.LookRotation(direction),
                                                    rotSpeed * Time.deltaTime);
        
        if(Vector3.Angle(goal.forward, this.transform.forward) > brakeAngle && speed > 2)
        {
            Debug.Log("DECELERATE");
            speed = Mathf.Clamp(speed - (deceleration * Time.deltaTime), minSpeed, maxSpeed);
        }
        else
        {
            Debug.Log("ACCELERATE");
            speed = Mathf.Clamp(speed + (acceleration * Time.deltaTime), minSpeed, maxSpeed);
        }

        this.transform.Translate(0, 0, speed);
    }
}
