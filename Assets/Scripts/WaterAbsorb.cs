using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterAbsorb : MonoBehaviour
{
    private bool isAbsorbing = false;
    private Collider2D waterSource;
    private bool isPlaced = false;

    // Start is called before the first frame update
    void Start()
    {
        isAbsorbing = false;
    }

    int count = 0;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            count++;
            if (count == 2)
            {
                isPlaced = true;
            }
        }
        AbsordWater();
        
    }

    private int absorbCooldown = 15;
    private GameData gameData;

    private void AbsordWater()
    {
        gameData = DataManager.GetGameData();
        if (isAbsorbing && waterSource.GetComponent<WaterSource>().waterAmount >= 0)
        {
            if (absorbCooldown > 0)
            {
                absorbCooldown--;
            }
            else
            {
                absorbCooldown = 15;               

                gameData.waterAmount += gameData.maxWater / 1000 ;
                waterSource.GetComponent<WaterSource>().waterAmount -= gameData.maxWater / 200;
                //Debug.Log(isAbsorbing);
            }
        }
        DataManager.SetGameData(gameData);

    }

    

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Water") && isPlaced)
        {
            isAbsorbing = true;
            waterSource = collision;
        }
    }

    

    private void OnDestroy()
    {
        isAbsorbing = false;
    }


}
