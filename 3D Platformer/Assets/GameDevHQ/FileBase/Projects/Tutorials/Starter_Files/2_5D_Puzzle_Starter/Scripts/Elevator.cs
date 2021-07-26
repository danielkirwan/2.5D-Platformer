using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] private Transform _pointA, _pointB;
    private float _speed = 3f;
    private bool _goDown;
    public void CallElevator()
    {
        _goDown = !_goDown;
    }

    private void FixedUpdate()
    {
        //down == true
            //move towards point b
        if(_goDown)
        {
            transform.position = Vector3.MoveTowards(transform.position, _pointB.position, _speed * Time.fixedDeltaTime);
        }
        else if (!_goDown)
        {
            transform.position = Vector3.MoveTowards(transform.position, _pointA.position, _speed * Time.fixedDeltaTime);
        }

        //else is down is false
            //move towards point a
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.parent = null;
        }
    }

}
