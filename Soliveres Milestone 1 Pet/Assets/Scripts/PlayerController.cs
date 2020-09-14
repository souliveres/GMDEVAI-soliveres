using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 6;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            // Go left
            // Below works because multipling a vector by a scalar
            // Changes the vector's MAG but NOT DIR
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.D))
        {
            // Go right
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.W))
        {
            // Go forwards
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.S))
        {
            // Go backwards
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
    }
}
