using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSource : MonoBehaviour
{
    public float waterAmount;

    // Start is called before the first frame update
    [System.Obsolete]
    void Awake()
    {
        waterAmount = Random.RandomRange(50, 300);
        //Debug.Log(waterAmount);
        gameObject.transform.localScale = new Vector3(waterAmount / 100, waterAmount / 100, 0);
        
    }

    private void Update()
    {
        
        if (waterAmount >= 0) {
            gameObject.transform.localScale = new Vector3(waterAmount / 100, waterAmount / 100, 0);
        }
    }


}
