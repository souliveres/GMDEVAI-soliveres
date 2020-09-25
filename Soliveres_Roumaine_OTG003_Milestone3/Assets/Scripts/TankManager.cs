using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankManager : MonoBehaviour
{
    public GameObject GreenTank;
    public GameObject RedTank;
    public GameObject BlueTank;

    FollowPath followPath;

    void Start() 
    {
        followPath = GetComponent<FollowPath>();
    }
    
    public void EnableGreenTank()
    {
        followPath.speed = 0f;
        followPath.rotSpeed = 0f;
        //GreenTank.SetActive(!GreenTank.activeSelf);
    }
    public void EnableRedTank()
    {
        followPath.speed = 0f;
        followPath.rotSpeed = 0f;
        //RedTank.SetActive(!RedTank.activeSelf);
    }
    public void EnableBlueTank()
    {
        followPath.speed = 0f;
        followPath.rotSpeed = 0f;
        //BlueTank.SetActive(!BlueTank.activeSelf);
    }
}
