using UnityEngine;

public class VictoryTrigger : MonoBehaviour
{
    public GameManager gameManager;
    [SerializeField ]void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.Victory();
        }
    }
}
