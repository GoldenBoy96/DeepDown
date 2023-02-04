using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Slider healthSlider;
    public Image healthFill;
    public float maxHealth = 100;
    public float minHealth = 0;
    public float healthAmount = 0;

    GameData gameData;

    // Start is called before the first frame update
    void Start()
    {
        healthSlider.maxValue = 1;
        healthSlider.minValue = 0;
        healthAmount = maxHealth/2;
        healthSlider.value = healthAmount / maxHealth;

        gameData = DataManager.GetGameData();
        gameData.maxHealth = maxHealth;
        gameData.healthAmount = healthAmount;
        DataManager.SetGameData(gameData);
    }

    // Update is called once per frame
    void Update()
    {
        MinMax();
        UpdateHealth();
        healthSlider.value = healthAmount / maxHealth;
    }

    private void MinMax()
    {
        if (healthAmount < minHealth) healthAmount = minHealth;
        if (healthAmount > maxHealth) healthAmount = maxHealth;
    }

    private void UpdateHealth()
    {
        gameData = DataManager.GetGameData();
        if (healthAmount > gameData.healthAmount)
        {
            healthAmount -= 0.1f;
        }
        if (healthAmount < gameData.healthAmount)
        {
            healthAmount += 0.1f;
        }
    }

    private void EndGame()
    {
        if (healthAmount < 0)
        {
            //Ch? này t?o ra màn hình k?t thúc và nút restart

            
        }
    }
}
