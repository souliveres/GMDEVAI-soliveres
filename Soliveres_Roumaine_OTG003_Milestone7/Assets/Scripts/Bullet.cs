using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public GameObject explosion;
	public float damage = 20f;
	
	void OnCollisionEnter(Collision col)
    {
    	GameObject e = Instantiate(explosion, this.transform.position, Quaternion.identity);
    	Destroy(e,1.5f);
    	Destroy(this.gameObject);
    }

	private void OnTriggerEnter(Collider other) 
	{
		if(other.tag == "TankAI")
        {
            Debug.Log("Shot a tank!");
        }
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
