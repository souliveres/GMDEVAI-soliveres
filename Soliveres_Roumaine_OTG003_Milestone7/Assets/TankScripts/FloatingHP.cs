using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FloatingHP : MonoBehaviour
{
    public GameObject floatingHP;
    public void UpdatePos(float x, float y, float z, string hp)
    {
        floatingHP.GetComponent<TextMesh>().text = hp;
        floatingHP.transform.position = new Vector3(x, y, z);
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
