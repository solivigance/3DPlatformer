using UnityEngine;

public class ResetHealth : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;

    void Start()
    {
        if (playerStats != null)
        {
            playerStats.currentHealth = playerStats.maxHealth;
        }
    }
}
