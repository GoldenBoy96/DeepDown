using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectRoots : MonoBehaviour
{
    private bool isAbleToPlace = false;
    private Collider2D parentRoot;
    private GameData gameData;

    void OnMouseDown()
    {
        gameData = DataManager.GetGameData();
        if (isAbleToPlace)
        {
            transform.position = parentRoot.transform.position;
            transform.SetParent(parentRoot.transform.parent);

            //Resource consume code put here
            if (gameObject.name.Equals("storage_wood(Clone)") && gameData.healthAmount > 10)
            {
                gameData.healthAmount -= 10;
            };
            if (gameObject.name.Equals("expand_wood(Clone)") && gameData.healthAmount > 2)
            {
                gameData.healthAmount -= 2;
            };
            if (gameObject.name.Equals("collector_wood(Clone)") && gameData.healthAmount > 5) 
            {
                gameData.healthAmount -= 5;
            };

        }
        else
        {
            Destroy(gameObject);
        }
        DataManager.SetGameData(gameData);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("ConnectionB"))
        {
            isAbleToPlace = true;
            parentRoot = collision;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("ConnectionB"))
        {
            isAbleToPlace = false;
        }
    }
}
