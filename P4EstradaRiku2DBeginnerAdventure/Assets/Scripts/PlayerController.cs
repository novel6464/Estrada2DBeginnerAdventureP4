using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    // Variables related to the health system
    public int maxHealth = 5;
    int currentHealth;
    public int health { get { return currentHealth; }}

    // Variables related to player character movement
    public InputAction MoveAction;
    Rigidbody2D rigidbody2D;
    Vector2 move;
    public float Speed = 3.0f;

    // Variables related to temeroraru invincibility
    public float timeInvincible = 2.0f;
    bool isInvincible;
    float damageCooldown;
     

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
        if (isInvincible)
        {
            damageCooldown -= Time.deltaTime;
            if (damageCooldown < 0)
            
                isInvincible = false;
            
        }


    }


    // FixedUpdate has the same call rate as the physics system
    void FixedUpdate()
    {
        Vector2 position = (Vector2)rigidbody2D.position + move * 10.0f * Time.fixedDeltaTime;
        rigidbody2D.MovePosition(position);
    }
    
    public void ChangeHealth (int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
            
                return;
            
            isInvincible = true;
            damageCooldown = timeInvincible;
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        UIHandler.instance.SetHealthValue(currentHealth / (float)maxHealth);
    }
}
