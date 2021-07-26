using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] private Transform _pointA, _pointB;
    private float _speed = 3f;
    private bool _goDown;
    [SerializeField] AudioSource _goingDown;
    [SerializeField] AudioSource _goingUp;
    public void CallElevator()
    {
        _goDown = !_goDown;
        //TODO
        //Add in sounds for going down and going up and remove the colour changes from the panel script
        if (_goDown)
        {
            _goingDown.Play();
        }else if (!_goDown)
        {
            _goingUp.Play();
        }
    }

    private void FixedUpdate()
    {
        if(_goDown)
        {
            transform.position = Vector3.MoveTowards(transform.position, _pointB.position, _speed * Time.fixedDeltaTime);
        }
        else if (!_goDown)
        {
            transform.position = Vector3.MoveTowards(transform.position, _pointA.position, _speed * Time.fixedDeltaTime);
        }
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
