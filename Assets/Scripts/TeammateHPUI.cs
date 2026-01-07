using UnityEngine;
using UnityEngine.UI;

public class TeammateHPUI : MonoBehaviour
{
    public Slider slider;
    public Health health;

    void Start()
    {
        slider.maxValue = health.maxHP;
        slider.value = health.currentHP;

        health.onHealthChanged.AddListener(UpdateHP);
    }

    void UpdateHP(int current, int max)
    {
        slider.maxValue = max;
        slider.value = current;
    }
}

