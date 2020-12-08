using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAI : MonoBehaviour
{
    Animator animator;
    public GameObject player;
    public Health health;
    public FloatingHP floatingHP;
    public GameObject bullet;
    public GameObject turret;

    public GameObject GetPlayer()
    {
        return player;
    }
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        health = this.GetComponent<Health>();
        health.Init(100f);
    }

    // Update is called once per frame
    void Update()
    {
        floatingHP.UpdatePos(this.transform.position.x, 
                            this.transform.position.y,
                            transform.position.z,
                            health.CurrHealth.ToString());
        animator.SetFloat("distance", Vector3.Distance(transform.position, player.transform.position));
        animator.SetFloat("HP", health.CurrHealth);
        if(health.CurrHealth <= 0)
        {
            Destroy(this.gameObject);
            floatingHP.Destroy();
        }
    }

    void Fire()
    {
        GameObject b = Instantiate(bullet, turret.transform.position, turret.transform.rotation);
        b.GetComponent<Rigidbody>().AddForce(turret.transform.forward * 500);
    }

    public void StopFiring()
    {
        CancelInvoke("Fire");
    }

    public void StartFiring()
    {
        InvokeRepeating("Fire", 0.5f, 0.5f);
    }

    private void OnCollisionEnter(Collision col) 
    {
        float damage = 0f;
        if(col.gameObject.CompareTag("Bullet"))
        {
            damage = col.collider.GetComponent<Bullet>().damage;
            Debug.Log("Tank got shot with " + damage + " damage!");
            health.TakeDamage(damage);
        }
    }
}
