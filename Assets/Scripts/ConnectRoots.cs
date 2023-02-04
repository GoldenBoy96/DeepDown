using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectRoots : MonoBehaviour
{
    private bool isAbleToPlace = false;
    private Collider2D parentRoot;

    void OnMouseDown()
    {
        if (isAbleToPlace)
        {
            transform.position = parentRoot.transform.position;
            transform.SetParent(parentRoot.transform.parent);
            
            //Resource consume code put here


        } 
        else
        {
            Destroy(gameObject);
        }
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
