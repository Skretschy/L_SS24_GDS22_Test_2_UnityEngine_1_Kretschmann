using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplePieces : MonoBehaviour
{
    private Vector3 rightPosition;
    public bool inRightPosition = false;
    private Quaternion rightRotation;
    public bool inRightRotation = false;

    private Vector3 initialPosition;
    private Quaternion initialRotation;

    private void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;

        rightPosition = transform.position;
        transform.position = new Vector3(Random.Range(-3f, -6.5f), Random.Range(2.5f, -2.5f));

        rightRotation = transform.rotation;
        RotateRandomly();
    }
    void Update()
    {
        if (Vector3.Distance(transform.position, rightPosition) < 0.5f && Quaternion.Angle(transform.rotation, rightRotation) < 1f)
        {
            transform.position = rightPosition;
            inRightPosition = true;
            transform.rotation = rightRotation;
            inRightRotation = true;

            Logic.Instance.CheckAllPieces();
        }
        else
        {
            inRightPosition = false;
            inRightRotation = false;
        }
    }

    void RotateRandomly()
    {
        int randomRotation = Random.Range(0, 8);
        float angle = randomRotation * 45f;

        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
