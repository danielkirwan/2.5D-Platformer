using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] private Transform _pointA, _pointB;
    private float _speed = 3f;
    private bool _callElevator;
    public void CallElevator()
    {
        _callElevator = true;
    }

    private void FixedUpdate()
    {
        //down == true
            //move towards point b
        if(_callElevator)
        {
            transform.position = Vector3.MoveTowards(transform.position, _pointB.position, _speed * Time.fixedDeltaTime);
        }

        //else is down is false
            //move towards point a
    }


}
