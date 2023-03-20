using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Slider slider;

    public void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void UpdateHealthBar(float maxHealth, float currentHealth)
    {
        slider.maxValue = maxHealth;
        slider.minValue = 0f;
        slider.value = currentHealth;
    }
}
