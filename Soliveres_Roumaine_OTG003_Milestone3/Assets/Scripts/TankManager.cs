using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankManager : MonoBehaviour
{
    public GameObject GreenTank;
    public GameObject RedTank;
    public GameObject BlueTank;
    
    public void EnableGreenTank()
    {
        GreenTank.SetActive(!GreenTank.activeSelf);
    }
    public void EnableRedTank()
    {
        RedTank.SetActive(!RedTank.activeSelf);
    }
    public void EnableBlueTank()
    {
        BlueTank.SetActive(!BlueTank.activeSelf);
    }
}
