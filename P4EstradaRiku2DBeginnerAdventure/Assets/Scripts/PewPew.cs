using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.InputSystem;


public class PewPew : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    // Awake is called when the projectile GameObject is instantiated
    void Awake()
    {
        rigidbody2d = GetComponent<rigidbody2d>();
    }
    
    void Update()
    { 
    
    }

    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }

    void OnTriggerEnter2D
