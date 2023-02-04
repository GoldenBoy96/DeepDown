using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRoot : MonoBehaviour
{
    public GameObject root;

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(this.tag);
    }

    private void OnMouseDown()
    {
       

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10);
        GameObject newRoot = Instantiate(root, mousePosition, Quaternion.identity);

        //Debug.Log(newRoot);
    }
}
