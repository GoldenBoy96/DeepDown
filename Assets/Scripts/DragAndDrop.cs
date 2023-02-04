using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private bool isDragging = false;


    private void Awake()
    {
        isDragging = true;
    }

    // Start is called before the first frame update
    void OnMouseDown()
    {
        isDragging = false;
        
    }

    //void OnMouseUp()
    //{
    //    if (isAbleToPlace)
    //    {

    //        isDragging = false;
    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        if (isDragging)
        {
            Drag();
            Rotate();
            Cancel();
        }
        //Debug.Log(isDragging);
    }

    void Cancel()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Destroy(gameObject);
        }
        
    }
    void Drag()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        transform.Translate(mousePosition);

    }

    void Rotate()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.rotation.z <= 0.4f)
            {
                Vector3 rotationToAdd = new Vector3(0, 0, 0.4f);
                transform.Rotate(rotationToAdd);

            } 
            
                
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.rotation.z >= -0.4f)
            {
                Vector3 rotationToAdd = new Vector3(0, 0, -0.4f);
                transform.Rotate(rotationToAdd, Space.Self);
                
            }
            
            
        }

        //Debug.Log(transform.rotation);
    }


}
