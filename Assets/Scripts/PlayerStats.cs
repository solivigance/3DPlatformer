using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public float moveSpeed = 5f;
    public float jumpForce = 8f;
    public float gravity = -9.81f;

    void Start()
    {
        InitializeHealth();
    }

    public void InitializeHealth()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log("Player Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Debug.Log("You died!");
        }
    }
}
