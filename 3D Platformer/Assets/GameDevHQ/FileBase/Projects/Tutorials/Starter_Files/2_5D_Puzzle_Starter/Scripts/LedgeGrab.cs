using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeGrab : MonoBehaviour
{
    [SerializeField] private Vector3 _handPosition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ledge"))
        {
            PlayerController player = other.transform.parent.GetComponent<PlayerController>();
            player.GrabbingLedge(_handPosition);
        }
    }
}
