using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeFoodSpawn : MonoBehaviour
{
    public GameObject freeFood;
    GameObject[] agents;

    void Start()
    {
        agents = GameObject.FindGameObjectsWithTag("agent");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray.origin, ray.direction, out hit))
            {
                Instantiate(freeFood, hit.point, freeFood.transform.rotation);
                foreach(GameObject a in agents)
                {
                    a.GetComponent<AIControl>().DetectFreeFood(hit.point);
                }
            }
        }
    }
}
