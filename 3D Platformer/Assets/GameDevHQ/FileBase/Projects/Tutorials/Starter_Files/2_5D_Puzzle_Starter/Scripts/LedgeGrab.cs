using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeGrab : MonoBehaviour
{
    //[SerializeField] private Vector3 _handPosition, _standPosition;

    [SerializeField] private Transform _hand, _stand;


    private void Start()
    {
        //_handPosition = _hand.transform.position;
        //_standPosition = _stand.transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ledge"))
        {
            PlayerController player = other.transform.parent.GetComponent<PlayerController>();
            player.GrabbingLedge(_hand.transform.position, this);
        }
    }

    //returns the standing position for this ledge
    public Vector3 GetStandingPosition()
    {
        return _stand.transform.position;
    }
}
