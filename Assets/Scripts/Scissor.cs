using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scissor : MonoBehaviour
{
    private bool isAbleToCut = false;
    Collider2D selectionRoot;

    // Start is called before the first frame update
    void Start()
    {
        isAbleToCut = false;
    }



    void OnMouseDown()
    {
        CutRoots();
        Destroy(gameObject);
    }

    void CutRoots()
    {
        if (isAbleToCut)
        {
            gameObject.transform.parent = selectionRoot.transform.parent;
            gameObject.transform.parent.transform.position = new Vector3(0, 4000, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wood"))
        {
            isAbleToCut = true;
            selectionRoot = collision;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Wood"))
        {
            isAbleToCut = false;
        }
    }
}
