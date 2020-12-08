using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Health health;
    public GameObject bullet;
    public GameObject turret;
    public Image HP;

    // Start is called before the first frame update
    void Start()
    {
        health = this.GetComponent<Health>();
        health.Init(100f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
        if(health.CurrHealth <= 0)
        {
            Dying();
        }
        HP.fillAmount = health.CurrHealth/ health.MaxHealth;
    }

    void Fire()
    {
        GameObject b = Instantiate(bullet, turret.transform.position, turret.transform.rotation);
        b.GetComponent<Rigidbody>().AddForce(turret.transform.forward * 500);
    }

    private void OnCollisionEnter(Collision col) 
    {
        float damage = 0f;
        if(col.gameObject.CompareTag("Bullet"))
        {
            damage = col.collider.GetComponent<Bullet>().damage;
            Debug.Log("Player got shot with " + damage + " damage!");
            health.TakeDamage(damage);
        }
    }

    void Dying()
    {
        Debug.Log("Player has run out of HP!");
        SceneManager.LoadScene("GameOver");
    }
}
