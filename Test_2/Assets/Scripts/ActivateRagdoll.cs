using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateRagdoll : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Trump"))
        {
            GameObject.Find("trump_rigCharRoot").SetActive(true);
        }
    }
}
