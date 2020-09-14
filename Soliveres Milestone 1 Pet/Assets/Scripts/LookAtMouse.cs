using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    float rotSpeed = 3;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookAtMouse = new Vector3(Input.mousePosition.x,
                                        this.transform.position.y,
                                        Input.mousePosition.z);

        Vector3 direction = lookAtMouse - transform.position;

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, 
                                                Quaternion.LookRotation(direction),
                                                Time.deltaTime * rotSpeed);

    }
}
