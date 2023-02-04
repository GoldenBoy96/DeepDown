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
    private int numberOfRoot = 1;

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
        gameData = DataManager.GetGameData();
        gameData.waterAmount = waterAmount;
        gameData.maxWater = maxWater;
        DataManager.SetGameData(gameData);


    }

    // Update is called once per frame
    void Update()
    {
        MinMax();
        WaterComsume();
        waterSlider.value = waterAmount / maxWater;
        waterFill.color = gradient.Evaluate(waterSlider.normalizedValue);
        gameData = DataManager.GetGameData();
        waterAmount = gameData.waterAmount;
        RootCount();
    }

    private void RootCount()
    {
        numberOfRoot = GameObject.FindGameObjectsWithTag("Wood").Length;
    }

    private void WaterTank()
    {
        int numberOfWaterTank = GameObject.FindGameObjectsWithTag("WaterTank").Length;
        gameData = DataManager.GetGameData();
        gameData.maxWater = 100 + numberOfWaterTank * 10;
        DataManager.SetGameData(gameData);
    }

    private void MinMax()
    {
        if (waterAmount < minWater) waterAmount = minWater;
        if (waterAmount > maxWater) waterAmount = maxWater;



    }

    private int consumeCooldown = 15;
    private void WaterComsume()
    {
        gameData = DataManager.GetGameData();
        if (consumeCooldown > 0) consumeCooldown--;
        else
        {
            //Debug.Log(waterAmount);
            waterAmount -= maxWater / 1000 + numberOfRoot / 200;
            consumeCooldown = 15;
            if (waterAmount > 0 && waterAmount < maxWater - 1)
            {
                gameData.healthAmount += gameData.maxHealth / 1000  ;             
            }
            else
            {
                gameData.healthAmount -= gameData.maxHealth / 500  ;
            }
            gameData.waterAmount = waterAmount;

        }
        DataManager.SetGameData(gameData);
    }
}
