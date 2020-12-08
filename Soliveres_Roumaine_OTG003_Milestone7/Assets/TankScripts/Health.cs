using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float CurrHealth {get; set;}
    public float MaxHealth{get {return maxHealth;}}
    private float maxHealth;

    public void Init(float nMaxHealth)
    {
        maxHealth = nMaxHealth;
        CurrHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        CurrHealth -= damage;
    }

    public void CheckStatus()
    {
        if(CurrHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
