using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector3 Origin;
    private Vector3 Difference;
    private Vector3 ResetCamera;

    private int cooldown = 10;

    private bool drag = false;



    private void Start()
    {
        ResetCamera = Camera.main.transform.position;
    }

    void OnMouseDrag()
    {
        if (cooldown > 0)
        {
            cooldown--;
        }
        else
        {
            Difference = (Camera.main.ScreenToWorldPoint(Input.mousePosition)) - Camera.main.transform.position;
            if (drag == false)
            {
                drag = true;
                Origin = Camera.main.transform.position;
            }
        }

    }

    private void OnMouseUp()
    {
        drag = false;
        cooldown = 10;
    }

    private void Update()
    {


        if (drag)
        {
            Camera.main.transform.position = Origin - Difference;
        }

        if (Input.GetMouseButton(2))
            Camera.main.transform.position = ResetCamera;

    }
}
