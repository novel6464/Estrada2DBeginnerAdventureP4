using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    // Variables related to player character health
    public int maxHealth = 5;
    int currentHealth;
    public int health { get { return currentHealth; }}

    // Variables related to player character movement
    public InputAction MoveAction;
    Rigidbody2D rigidbody2D;
    Vector2 move;
    public float Speed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        MoveAction.Enable();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()

    {
        move = MoveAction.ReadValue<Vector2>();
        

    }

    // FixedUpdate has the same call rate as the physics system
    void FixedUpdate()
    {
        Vector2 position = (Vector2)rigidbody2D.position + move * 10.0f * Time.fixedDeltaTime;
        rigidbody2D.MovePosition(position);
    }
    
    public void ChangeHealth (int amount)
    {
        
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }
}
