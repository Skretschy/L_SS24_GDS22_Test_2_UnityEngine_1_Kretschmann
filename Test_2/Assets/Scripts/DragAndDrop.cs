using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private Vector3 mousePosition;
    private Color col;
    private bool isDragging = false;

    void Update()
    {
        if(isDragging && Input.GetMouseButtonDown(1))
        {
            RotateObject();
        }
    }
    private Vector3 GetMousePos()
    {
        print("calculate now");
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        mousePosition = Input.mousePosition - GetMousePos();
        col = GetComponent<MeshRenderer>().material.color;
        GetComponent<MeshRenderer>().material.color = Color.yellow;
        GetComponent<Rigidbody>().isKinematic = true;
        isDragging = true;
    }

    private void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
    }

    private void OnMouseUp()
    {
        GetComponent<MeshRenderer>().material.color = col;
        GetComponent<Rigidbody>().isKinematic = false;
        isDragging= false;
    }

    private void RotateObject()
    {
        transform.Rotate(Vector3.forward, 45f);
    }
}