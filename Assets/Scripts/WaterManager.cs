using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterManager : MonoBehaviour
{
    public Slider waterSlider;
    public float maxWater = 100;
    public float minWater = 0;
    public Gradient gradient;
    public Image waterFill;

   GameData gameData;

    private float waterAmount;
    // Start is called before the first frame update
    void Start()
    {
        waterSlider.maxValue = 1;
        waterSlider.minValue = 0;
        waterAmount = maxWater * 2 / 3;
        waterSlider.value = waterAmount / maxWater;
        waterFill.color = gradient.Evaluate(1f);

        

    }

    // Update is called once per frame
    void Update()
    {
        MinMax();
        WaterComsume();
        waterSlider.value = waterAmount / maxWater;
        waterFill.color = gradient.Evaluate(waterSlider.normalizedValue);
    }

    private void MinMax()
    {
        if (waterAmount < minWater) waterAmount = minWater;
        if (waterAmount > maxWater) waterAmount = maxWater;
        
    }

    private int consumeCooldown = 30;
    private void WaterComsume()
    {
        if (consumeCooldown > 0) consumeCooldown--;
        else
        {
            waterAmount -= maxWater / 1000;
            consumeCooldown = 12;
            if (waterAmount >= 0 && waterAmount <= maxWater)
            {
                gameData = DataManager.GetGameData();
                gameData.healthAmount += gameData.maxHealth / 1000;
                DataManager.SetGameData(gameData);
            }
            else 
            {
                gameData = DataManager.GetGameData();
                gameData.healthAmount -= gameData.maxHealth / 1000;
                DataManager.SetGameData(gameData);
            }
            
        }
    }
}
