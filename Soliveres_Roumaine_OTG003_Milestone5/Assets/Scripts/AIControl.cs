using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIControl : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent agent;
    public GameObject target;
    public WASDMovement playerMovement;
    Vector3 wanderTarget;
    float range = 5.0f;
    [SerializeField] float aiID = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
        playerMovement = target.GetComponent<WASDMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(aiID)
        {
            case 1:
                DoAgent1Simulation();
                break;
            case 2:
                DoAgent2Simulation();
                break;
            case 3:
                DoAgent3Simulation();
                break;
            default:
                break;
        }
        // if(canSeeTarget())
        // {
        //     Debug.Log("AI " + aiID + " can see you!");
        //     switch(aiID)
        //     {
        //         case 1:
        //             Pursuit();
        //             break;
        //         case 2:
        //             CleverHide();
        //             break;
        //         case 3:
        //             Evade();    
        //             break;
        //         default:
        //             break;
        //     }
    }

    /*
        Use a switch case inside update that includes a specific functional behavior for each agent
        e.g. 
        switch(id)
            case 1: 
                DoAgent1Simulation();
                break;
            ....

        DoAgent1Simulation()
        {
            if(canSeeTarget())
                ...
        }

        bool IsWithinRange(Vec3 target, float maxDist)
        {
            // Find the distance between yourself and target 
            // Check if it's less than your specified maxDist/ range
            return Vector3.Distance(target, this.transform.position) < maxDist;
            
        if(Vector3.Distance(target, this.transform.position) <= range)
        { 
            return Vector3.Distance(target, this.transform.position) <= range;
        }
    */

    bool canSeeTarget(float maxDist)
    {
        RaycastHit raycastInfo;
        
        Vector3 rayForward = this.transform.TransformDirection(Vector3.forward) * maxDist;

        if(Physics.Raycast(this.transform.position, rayForward, out raycastInfo))
        {
            if(raycastInfo.distance <= maxDist)
            {
                Debug.DrawRay(this.transform.position, rayForward, Color.yellow);
                return raycastInfo.transform.gameObject.tag == "Player";
            }
            
        }

        return false;
    }

    bool IsTargetInRange(float maxDist)
    {
        RaycastHit raycastInfo;
        Vector3 rayToTarget = target.transform.position - this.transform.position;

        if(Physics.Raycast(this.transform.position, rayToTarget, out raycastInfo))
        {
            if(raycastInfo.distance <= maxDist)
            {
                Debug.DrawRay(this.transform.position, rayToTarget, Color.blue);
                return raycastInfo.transform.gameObject.tag == "Player";
            }
        }

        return false;
    }

    void Seek(Vector3 location)
    {
        agent.SetDestination(location);
    }

    void Flee(Vector3 location)
    {
        Vector3 fleeDirection = location - this.transform.position;
        agent.SetDestination(this.transform.position - fleeDirection);
    }

    void Pursuit()
    {
        // Anticipating where target should go and SEEKing
        Vector3 targetDirection = target.transform.position - this.transform.position;
        
        float lookAhead = targetDirection.magnitude/(agent.speed + playerMovement.currentSpeed);
        
        Seek(target.transform.position + target.transform.forward * lookAhead);
    }

    void Evade()
    {
        // Anticipating where target should go and FLEEing
        Vector3 targetDirection = target.transform.position - this.transform.position;
        
        float lookAhead = targetDirection.magnitude/(agent.speed + playerMovement.currentSpeed);
        
        Flee(target.transform.position + target.transform.forward * lookAhead);
    }

    void Wander()

    {
        float wanderRadius = 20f;
        float wanderDistance = 10f;
        float wanderJitter = 1f; //how often this agent deviates current direction to wander to another direction

        wanderTarget += new Vector3(Random.Range(-1.0f, 1.0f) * wanderJitter,
                                    0,
                                    Random.Range(-1.0f, 1.0f) * wanderJitter);
        wanderTarget.Normalize();
        wanderTarget *= wanderRadius;
        
        Vector3 targetLocal = wanderTarget + new Vector3(0, 0, wanderDistance);
        Vector3 targetWorld = this.gameObject.transform.InverseTransformVector(targetLocal);        // transforms local vector to world space vector
        Seek(targetWorld);

    }
    void CleverHide()
    {
        float distance = Mathf.Infinity;
        Vector3 chosenSpot = Vector3.zero;
        Vector3 chosenDir = Vector3.zero;
        GameObject chosenGameObject = World.Instance.GetHidingSpots()[0];

        int hidingSpotsCount = World.Instance.GetHidingSpots().Length;
        
        for(int i = 0; i <hidingSpotsCount; i++)
        {
            Vector3 hideDirection = World.Instance.GetHidingSpots()[i].transform.position - target.transform.position;
            Vector3 hidePosition = World.Instance.GetHidingSpots()[i].transform.position + hideDirection.normalized * 5;   //distance offset

            float spotDistance = Vector3.Distance(this.transform.position, hidePosition);
            if(spotDistance < distance)
            {
                chosenSpot = hidePosition;
                chosenDir = hideDirection;
                chosenGameObject = World.Instance.GetHidingSpots()[i];
                distance = spotDistance;
            }
        }

        Collider hideCol = chosenGameObject.GetComponent<Collider>();
        Ray back = new Ray(chosenSpot, - chosenDir.normalized);
        RaycastHit info;
        float rayDistance = 100.0f;
        hideCol.Raycast(back, out info, rayDistance);

        Seek(info.point + chosenDir.normalized * 5);
    }

    void DoAgent1Simulation()
    {
        if(IsTargetInRange(range))
        {
            Pursuit();
        }
        else
        {
            Wander();
        }
    }

    void DoAgent2Simulation()
    {
        if(IsTargetInRange(range) && canSeeTarget(range))
        {
            CleverHide();
        }
        else
        {
            Wander();
        }
    }

    void DoAgent3Simulation()
    {
        if(IsTargetInRange(range))
        {
            Evade();
        }
        else
        {
            Wander();
        }
    } 
}
