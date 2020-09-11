using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelToGoal : MonoBehaviour
{
    // To travel to goal:
    // Finding a direction: resulting vector of Goal Pos - Character Pos

    public Transform goal;
    float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 direction = goal.position - this.transform.position;

        transform.LookAt(goal);

        // if the magnitude (or distance) between the goal and the character is greater than 1
        // Keep moving the character
        // Else, stop the character
        // "1" - A distance near the object

        if(direction.magnitude > 1) 
        {
            // Using Space.World to translate the character relative to World coordinates
            transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        }

    }
}
