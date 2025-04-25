using UnityEngine;
using UnityEngine.UI;

public class View : MonoBehaviour
{
    [SerializeField] PlayerStats myStats;
    [SerializeField] Image healthBarImage;
    void Update()
    {
        healthBarImage.fillAmount = (1.0f * myStats.currentHealth) / (float)myStats.maxHealth;
    }
}
