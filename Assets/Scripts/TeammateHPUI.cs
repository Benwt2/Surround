using UnityEngine;
using UnityEngine.UI;

public class TeammateHPUI : MonoBehaviour
{
    public Slider slider;
    public TeammateHealth Health;

    void Start()
    {
        slider.maxValue = Health.maxHP;
        slider.value = Health.currentHP;
    }

    void Update()
    {
        slider.value = Health.currentHP;
    }
}

