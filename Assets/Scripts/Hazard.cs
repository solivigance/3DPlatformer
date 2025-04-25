using UnityEngine;

public class Hazard : MonoBehaviour
{
    [SerializeField] int damageAmount = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player hit!");
            CharacterMovement characterMovement = other.GetComponent<CharacterMovement>();

            if (characterMovement != null)
            {
                characterMovement.TakeDamage(damageAmount);
            }
        }
    }
}
