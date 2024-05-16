using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplePieces : MonoBehaviour
{
    private Vector3 RightPosition;
    public bool InRightPosition;
    private Quaternion rightRotation;
    public bool inRightRotation;

    private void Start()
    {
        RightPosition = transform.position;
        transform.position = new Vector3(Random.Range(-3f, -6.5f), Random.Range(2.5f, -2.5f));

        rightRotation = transform.rotation;
        RotateRandomly();
    }
    void Update()
    {
        if (Vector3.Distance(transform.position, RightPosition) < 0.5f && Quaternion.Angle(transform.rotation, rightRotation) < 1f)
        {
            transform.position = RightPosition;
            InRightPosition = true;
            transform.rotation = rightRotation;
            inRightRotation = true;
        }
    }

    void RotateRandomly()
    {
        int randomRotation = Random.Range(0, 8);
        float angle = randomRotation * 45f;

        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
