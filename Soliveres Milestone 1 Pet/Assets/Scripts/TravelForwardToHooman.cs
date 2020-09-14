using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelForwardToHooman : MonoBehaviour
{
    public Transform hooman;
    public float speed  = 5;
    public float rotSpeed = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookAtHooman = new Vector3(hooman.position.x,
                                            this.transform.position.y,
                                            hooman.position.z);

        Vector3 direction = lookAtHooman - transform.position;

        
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                                    Quaternion.LookRotation(direction),
                                                    Time.deltaTime * rotSpeed);
        

        //this.transform.position = Vector3.Slerp(lookAtHooman, transform.position, Time.deltaTime * rotSpeed);

        
        if(Vector3.Distance(lookAtHooman, transform.position) > 1)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
        
    }
}
