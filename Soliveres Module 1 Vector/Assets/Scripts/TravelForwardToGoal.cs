using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelForwardToGoal : MonoBehaviour
{
    public Transform goal;
    public float speed = 5;
    public float rotSpeed = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Make new vector with goal's x and z pos but 
        // has current y pos (keeps character on ground)
        Vector3 lookAtGoal = new Vector3(goal.position.x,
                                        this.transform.position.y,
                                        goal.position.z);

        Vector3 direction = lookAtGoal - transform.position;

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, 
                                                Quaternion.LookRotation(direction),
                                                Time.deltaTime * rotSpeed);

        // Below translates character FORWARD the goal
        // IF the distance between the two vectors is greater than 1
        // Char rotates because of the code above to look at the goal

        if (Vector3.Distance(lookAtGoal, transform.position) > 1)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }

    }
}
