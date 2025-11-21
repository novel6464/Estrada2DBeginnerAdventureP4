using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PewPew : MonoBehaviour
{
    Rigidbody2D rigidbody2d;

    // Awake is called when the projectile GameObject is instantiated
    void Awake()
    {
       rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }

    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        EnemyController enemy = other.GetComponent<EnemyController>();
        if (enemy != null)
        {
            enemy.Fix();
        }
        Destroy(gameObject);
    }


}